using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataAccess;
using Vidly.Models;
using System.Data.Entity;


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

        public ActionResult ReadCustomers()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult DetailCustomers(int id)
        {

            var customers = _context.Customers.Include(d => d.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }
    }
}