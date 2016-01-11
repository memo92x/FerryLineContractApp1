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
    public class DockController : Controller
    {
        private FerryLineModelContext db = new FerryLineModelContext();
        AdminstrationManager repository = new AdminstrationManager();

        //
        // GET: /Dock/

        public ActionResult Index()
        {
            var viewDock = new DockDTO
            {
                DockList = repository.GetAllDocks(),
            };
            return View(viewDock);
        }

        //
        // GET: /Dock/Details/5

        public ActionResult Details(int id )
        {
            //Dock dock = db.Docks.Find(id);
            var dock = repository.GetDock(id);  // .DockDetail(id);
            //Customer customer = db.Customers.Find(id);
            var dockView = new DockDTO
            {
                DockName = dock.DockName,
                FerryCapacity = dock.FerryCapacity,
            };

            if (dockView == null)
            {
                return HttpNotFound();
            }
            return View(dockView);
        }

        //
        // GET: /Dock/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Dock/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DockDTO dockDTO)
        {
            var dock = repository.CreateDock(dockDTO);
            if (ModelState.IsValid)
            {
                db.Docks.Add(dock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dock);
        }

        //
        // GET: /Dock/Edit/5

        public ActionResult Edit(int id)
        {
            var dock = repository.GetDock(id);
            var dockView = new DockDTO
            {
                DockId = dock.DockId,
                DockName = dock.DockName,
                FerryCapacity = dock.FerryCapacity,

            };
            if (dock == null)
            {
                return HttpNotFound();
            }
            return View(dock);
        }

        //
        // POST: /Dock/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DockDTO dockDTO) // same as update dock
        {
            var dock = new Dock
            {
                 DockId = dockDTO.DockId,
                 DockName  = dockDTO.DockName,
                 FerryCapacity = dockDTO.FerryCapacity,
            };

            if (ModelState.IsValid)
            {
                db.Entry(dock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dock);
        }

        //
        // GET: /Dock/Delete/5

        public ActionResult Delete(int id)
        {
            var dock = repository.GetDock(id);
            if (dock == null)
            {
                return HttpNotFound();
            }
            return View(dock);
        }

        //
        // POST: /Dock/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteDock(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}