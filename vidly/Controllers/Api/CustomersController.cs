using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;
using vidly.Dtos;
using AutoMapper;

namespace vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        
        private ApplicationDbContext _context;
        public CustomersController()
        {

            _context = new ApplicationDbContext();
        }
        //get /api/customers
        public IHttpActionResult GetCustomers()
        {

            //return _context.Customers.ToList();
            var customerDtos= _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        //get /api/customers/1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
                
            
            
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        //POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {

            if (!ModelState.IsValid)
               // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            
                _context.Customers.Add(customer);
                _context.SaveChanges();
            
            //return customer;
             return (Created(new Uri(Request.RequestUri + customer.Id.ToString()), customer));

        }

        //;put /api/customers/1
        [HttpPut]
        public void  UpdateCustomer(Int16 id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            Mapper.Map(customerDto, customerInDB);
            // customerInDB.Name = customer.Name;
            //customerInDB.Birthdate = customer.Birthdate;
            //customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDB.MembershipTypeID = customer.MembershipTypeID;
            _context.SaveChanges();

        }

        //Delete /api /Customers/1
        [HttpDelete]
        public void DeleteCustoemr(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();

        }

    }
}
