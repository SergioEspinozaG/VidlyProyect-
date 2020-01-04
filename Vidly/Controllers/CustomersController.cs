using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataAccess;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult ReadCustomers()
        {

            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult DetailCustomers(int id)
        {

            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }
    }
}