using EFMVCTestMySQL.DBContext;
using EFMVCTestMySQL.Models;
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
        // GET: Customer
        public ViewResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            
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