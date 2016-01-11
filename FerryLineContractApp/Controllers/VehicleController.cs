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
    public class VehicleController : Controller
    {
        private FerryLineModelContext db = new FerryLineModelContext();
        AdminstrationManager repository = new AdminstrationManager();

        //
        // GET: /Vehicle/

        public ActionResult Index()
        {
            var viewVehicle = new VehicleDTO
            {
                VehicleList = repository.GetAllVehicles(),
            };
            return View(viewVehicle);
        }

        //
        // GET: /Vehicle/Details/5

        public ActionResult Details(int id)
        {
            Vehicle vehicle = repository.GetVehicle(id);

            var vehicleView = new VehicleDTO
            {
                VehiclePrice = vehicle.VehiclePrice,
                VehicleSize = vehicle.VehicleSize,
                VehicleType = vehicle.VehicleType,
            };

            if (vehicleView == null)
            {
                return HttpNotFound();
            }
            return View(vehicleView);
        }

        //
        // GET: /Vehicle/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vehicle/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleDTO vehicleDTO)
        {
            Vehicle vehicle = repository.CreateVehicle(vehicleDTO);

            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        //
        // GET: /Vehicle/Edit/5

        public ActionResult Edit(int id)
        {
            Vehicle vehicle = repository.GetVehicle(id);

            var vehicleView = new VehicleDTO
            {
                VehicleId = vehicle.VehicleId,
                VehiclePrice = vehicle.VehiclePrice,
                VehicleSize = vehicle.VehicleSize,
                VehicleType = vehicle.VehicleType,
            };

            if (vehicleView == null)
            {
                return HttpNotFound();
            }
            return View(vehicleView);
        }

        //
        // POST: /Vehicle/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleDTO vehicleDTO)
        {
            Vehicle vehicle = repository.UpdateVehicle(vehicleDTO);

            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        //
        // GET: /Vehicle/Delete/5

        public ActionResult Delete(int id)
        {
            Vehicle vehicle = repository.GetVehicle(id);

            var vehicleView = new VehicleDTO
            {
                VehicleId = vehicle.VehicleId,
                VehiclePrice = vehicle.VehiclePrice,
                VehicleSize = vehicle.VehicleSize,
                VehicleType = vehicle.VehicleType,
            };

            if (vehicleView == null)
            {
                return HttpNotFound();
            }
            return View(vehicleView);
        }

        //
        // POST: /Vehicle/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = repository.GetVehicle(id);
            db.Vehicles.Attach(vehicle);
            db.Vehicles.Remove(vehicle);
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