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
    public class TripController : Controller
    {
        private FerryLineModelContext db = new FerryLineModelContext();
        AdminstrationManager repository = new AdminstrationManager();

        //
        // GET: /Trip/

        public ActionResult Index()
        {
            var viewTrip = new TripDTO
            {
                TripList = repository.GetAllTrips(),
            };
            return View(viewTrip);
        }

        //
        // GET: /Trip/Details/5

        public ActionResult Details(int id)
        {
            Trip trip = repository.GetTrip(id);

            var tripView = new TripDTO
            {
                DepatureTime = trip.DepatureTime,
                TripPrice = trip.TripPrice,
            };

            if (tripView == null)
            {
                return HttpNotFound();
            }
            return View(tripView);
        }

        //
        // GET: /Trip/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trip/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TripDTO tripDTO)
        {
            Trip trip = repository.CreateTrip(tripDTO);
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        //
        // GET: /Trip/Edit/5

        public ActionResult Edit(int id)
        {
            Trip trip = repository.GetTrip(id);

            var tripView = new TripDTO
            {
                TripId = trip.TripId,
                DepatureTime = trip.DepatureTime,
                TripPrice = trip.TripPrice,
            };

            if (tripView == null)
            {
                return HttpNotFound();
            }
            return View(tripView);
        }

        //
        // POST: /Trip/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TripDTO tripDTO)
        {
            Trip trip = repository.UpdateTrip(tripDTO);
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        //
        // GET: /Trip/Delete/5

        public ActionResult Delete(int id)
        {
            Trip trip = repository.GetTrip(id);

            var tripView = new TripDTO
            {
                TripId = trip.TripId,
                DepatureTime = trip.DepatureTime,
                TripPrice = trip.TripPrice,
            };

            if (tripView == null)
            {
                return HttpNotFound();
            }
            return View(tripView);
        }

        //
        // POST: /Trip/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = repository.GetTrip(id);
            db.Trips.Attach(trip);
            db.Trips.Remove(trip);
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