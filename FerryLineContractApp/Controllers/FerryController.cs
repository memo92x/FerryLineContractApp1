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
    public class FerryController : Controller
    {
        private FerryLineModelContext db = new FerryLineModelContext();
        AdminstrationManager repository = new AdminstrationManager();

        //
        // GET: /Ferry/

        public ActionResult Index()
        {
            var viewFerry = new FerryDTO
            {
                FerryList = repository.GetAllFerries(),
            };
            return View(viewFerry);
        }

        //
        // GET: /Ferry/Details/5

        public ActionResult Details(int id)
        {
            var ferry = repository.GetFerry(id);

            var ferryView = new FerryDTO
            {
                FerryName = ferry.FerryName,
                FerrySize = ferry.FerrySize,
                PassengerCapacity = ferry.PassengerCapacity,
                VehicleCapacity = ferry.VehicleCapacity,
                Municipality = ferry.Municipality,
                DockId = ferry.DockId,
            };

            if (ferryView == null)
            {
                return HttpNotFound();
            }
            return View(ferryView);
        }

        //
        // GET: /Ferry/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ferry/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FerryDTO ferryDTO)
        {
           var ferry = repository.CreateFerry(ferryDTO);

            if (ModelState.IsValid)
            {
                db.Ferrys.Add(ferry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        //
        // GET: /Ferry/Edit/5

        public ActionResult Edit(int id)
        {
            var ferry = repository.GetFerry(id);

            var FerryView = new FerryDTO
            {
                FerryId = ferry.FerryId,
                FerryName = ferry.FerryName,
                FerrySize = ferry.FerrySize,
                PassengerCapacity = ferry.PassengerCapacity,
                VehicleCapacity = ferry.VehicleCapacity,
                Municipality = ferry.Municipality,
                DockId = ferry.DockId,
            };

            if (FerryView == null)
            {
                return HttpNotFound();
            }
            return View(FerryView);
        }

        //
        // POST: /Ferry/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FerryDTO ferryDTO)
        {
            var ferry = repository.UpdateFerry(ferryDTO);
            if (ModelState.IsValid)
            {
                db.Entry(ferry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ferry);
        }

        //
        // GET: /Ferry/Delete/5

        public ActionResult Delete(int id)
        {
            var ferry = repository.GetFerry(id);

            var ferryDTO = new FerryDTO
            {
                FerryId = ferry.FerryId,
                FerryName = ferry.FerryName,
                FerrySize = ferry.FerrySize,
                PassengerCapacity = ferry.PassengerCapacity,
                VehicleCapacity = ferry.VehicleCapacity,
                Municipality = ferry.Municipality,
                DockId = ferry.DockId,
            };

            if (ferryDTO == null)
            {
                return HttpNotFound();
            }
            return View(ferryDTO);
        }

        //
        // POST: /Ferry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ferry = repository.DeleteFerry(id);
            db.Ferrys.Attach(ferry);
            db.Ferrys.Remove(ferry);
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