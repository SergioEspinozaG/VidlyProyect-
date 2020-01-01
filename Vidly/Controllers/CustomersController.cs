using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataAccess;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Data data;

        public CustomersController()
        {
            data = new Data();
        }

        public ActionResult ReadCustomers()
        {
            var vm = new RandomMovieViewModel();
            vm.Customers = data.GetCustomers();

            return View(vm);
        }
    }
}