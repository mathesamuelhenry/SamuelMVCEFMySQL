using EFMVCTestMySQL.DBContext;
using EFMVCTestMySQL.Models;
using EFMVCTestMySQL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFMVCTestMySQL.Controllers
{
    public class CustomerController : Controller
    {
        private EFMVCMySqlDBContext _dbContext;

        public CustomerController()
        {
            _dbContext = new EFMVCMySqlDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        // NewCustomerViewModel - model binding in action
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _dbContext.Customers.Add(customer);
            else
            {
                // Using Single since if given customer is not found it should throw an exception
                var customerInDb = _dbContext.Customers.Single(c => c.Id == customer.Id);
                // two ways
                // way 1 - it opens up security holes, it updates every form field
                // TryUpdateModel(customerInDb);
                // way 2 
                // or you can use AutoMapper library (Mapper.Map(customer, customerInDb) 
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            // persist the changes
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customer
        public ViewResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name = "Samuel Mathe", Id = 1 },
                new Customer { Name = "Sarah Solomon", Id = 2 }
            };
        }
    }
}