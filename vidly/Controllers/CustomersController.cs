using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using System.Data.Entity;
using vidly.ViewModels;
using System.Data.Entity.Validation;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {

            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }

        
        public ViewResult Index()
        {

           // var customer = _context.Customers.Include(c=>c.MembershipType).ToList();
           // return View(customer);
            return View();
        }
        public ActionResult Details(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer=new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
           if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()


                };

                return View("CustomerForm", viewModel);


            } 

            //var errors = ModelState.Values.SelectMany(v => v.Errors);
           
                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);

                }
                else
                {

                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.MembershipTypeID = customer.MembershipTypeID;
                    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

                }

                _context.SaveChanges();
            
           

                return RedirectToAction("Index", "Customers");
            
            
            //return View();
        }

        public ActionResult Edit(int id)
        {
            var customer=_context.Customers.SingleOrDefault(c => c.Id== id);
            
            if(customer==null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
             return View("CustomerForm", viewModel);
        }
       
        
       
    }
}