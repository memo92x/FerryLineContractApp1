using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FerryLineContractApp.Models;
using FerryLineContractApp.Repository;
using FerryLineContractApp.DTO;

namespace FerryLineContractApp.Controllers
{
    public class CustomerController : Controller
    {
        private FerryLineModelContext db = new FerryLineModelContext();

        AdminstrationManager repository = new AdminstrationManager();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var viewCustomer = new CustomerDTO
            {
                CustomerList = repository.GetAllCustomer(),
            };
            return View(viewCustomer);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id )
        {
            var customer = repository.DetailsCustomer(id);
            //Customer customer = db.Customers.Find(id);

            var customerView = new CustomerDTO
            {
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Phone = customer.Phone,
                Mail = customer.Mail,
                Street = customer.Street,
                HouseNumber= customer.HouseNumber,
                PostalCode= customer.PostalCode,
                City= customer.City,
                Native= customer.Native,
                AmountOfFreeRides = customer.AmountOfFreeRides,

            };

            if (customerView == null)
            {
                return HttpNotFound();
            }
            return View(customerView);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CustomerDTO customerDTO)
        //{

        //    //var customer = new Customer
        //    //{
        //    //    Firstname = customerDTO.Firstname,
        //    //    Lastname = customerDTO.Lastname,
        //    //    Phone = customerDTO.Phone,
        //    //    Mail = customerDTO.Mail,
        //    //    Street = customerDTO.Street,
        //    //    HouseNumber = customerDTO.HouseNumber,
        //    //    PostalCode = customerDTO.PostalCode,
        //    //    City = customerDTO.City,
        //    //    Native = customerDTO.Native,
        //    //    AmountOfFreeRides = customerDTO.AmountOfFreeRides,
        //    //};

        //    var customer = repository.CreateCustomer(customerDTO);

        //    if (ModelState.IsValid)
        //    {
        //        db.Customers.Add(customer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(customer);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDTO customerDTO)
        {

          var customer = repository.CreateCustomer(customerDTO);
          //repository.CreateCustomer(customerDTO);

          if (ModelState.IsValid)
          {
              db.Customers.Add(customer);
              db.SaveChanges();
          }

            //return View();
          return RedirectToAction("Index");
        }


        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id )
        {
            var customer = repository.UpdateCustomer(id);

            var customerView = new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Phone = customer.Phone,
                Mail = customer.Mail,
                Street = customer.Street,
                HouseNumber = customer.HouseNumber,
                PostalCode = customer.PostalCode,
                City = customer.City,
                Native = customer.Native,
                AmountOfFreeRides = customer.AmountOfFreeRides,

            };

            if (customerView == null)
            {
                return HttpNotFound();
            }
            return View(customerView);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                CustomerId = customerDTO.CustomerId,
                Firstname = customerDTO.Firstname,
                Lastname = customerDTO.Lastname,
                Phone = customerDTO.Phone,
                Mail = customerDTO.Mail,
                Street = customerDTO.Street,
                HouseNumber = customerDTO.HouseNumber,
                PostalCode = customerDTO.PostalCode,
                City = customerDTO.City,
                Native = customerDTO.Native,
                AmountOfFreeRides = customerDTO.AmountOfFreeRides,
            };

            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerDTO);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            //Customer customer = db.Customers.Find(id);
            var customer = repository.getCustomerToDelete(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Customer customer = db.Customers.Find(id);
            //db.Customers.Remove(customer);
            //db.SaveChanges();
            repository.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}