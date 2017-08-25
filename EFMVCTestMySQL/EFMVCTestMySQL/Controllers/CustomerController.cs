using EFMVCTestMySQL.DBContext;
using EFMVCTestMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFMVCTestMySQL.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ViewResult Index()
        {
            var customers = GetCustomers().ToList(); 

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            
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