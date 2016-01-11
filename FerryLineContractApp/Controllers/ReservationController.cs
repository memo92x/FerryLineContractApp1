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
    public class ReservationController : Controller
    {
        private FerryLineModelContext db = new FerryLineModelContext();
        AdminstrationManager repository = new AdminstrationManager();

        //
        // GET: /Reservation/

        public ActionResult Index()
        {
            var viewReserv = new ReservationDTO
            {
                ReservationList = repository.GetAllReservations(),
            };
            return View(viewReserv);
        }

        //
        // GET: /Reservation/Details/5

        public ActionResult Details(int id)
        {
            var reservation = repository.GetReservation(id);

            var reservView = new ReservationDTO
            {
                TotalPrice = reservation.TotalPrice,
                NumberOfPeople = reservation.NumberOfPeople,
            };

            if (reservView == null)
            {
                return HttpNotFound();
            }
            return View(reservView);
        }

        //
        // GET: /Reservation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reservation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationDTO reservationDTO)
        {

            var reserv = repository.CreateReservation(reservationDTO);

            if (ModelState.IsValid)
            {
                db.Reservations.Add(reserv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserv);
        }

        //
        // GET: /Reservation/Edit/5

        public ActionResult Edit(int id)
        {
            var reservation = repository.GetReservation(id);

            var reservView = new ReservationDTO
            {
                TotalPrice = reservation.TotalPrice,
                NumberOfPeople = reservation.NumberOfPeople,

            };

            if (reservView == null)
            {
                return HttpNotFound();
            }
            return View(reservView);
        }

        //
        // POST: /Reservation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationDTO reservationDTO)
        {
            var editReserv = repository.UpdateReservation(reservationDTO);

            if (ModelState.IsValid)
            {
                db.Entry(editReserv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editReserv);
        }

        //
        // GET: /Reservation/Delete/5

        public ActionResult Delete(int id)
        {
            var reservation = repository.GetReservation(id);
            var reservDTO = new ReservationDTO
            {
                TotalPrice = reservation.TotalPrice,
                NumberOfPeople = reservation.NumberOfPeople,
            };

            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservDTO);
        }

        //
        // POST: /Reservation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var reservation = repository.GetReservation(id);
            db.Reservations.Attach(reservation);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}