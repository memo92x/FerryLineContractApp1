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
    public class RouteController : Controller
    {
        private FerryLineModelContext db = new FerryLineModelContext();
        AdminstrationManager repository = new AdminstrationManager();
        //
        // GET: /Route/

        public ActionResult Index()
        {
            var viewRoute = new RouteDTO
            {
                RouteList = repository.GetAllRoutes(),
            };
            return View(viewRoute);
        }

        //
        // GET: /Route/Details/5

        public ActionResult Details(int id)
        {
            var route = repository.GetRoute(id);

            var routeView = new RouteDTO
            {
                Depature = route.Depature,
                Destination = route.Destination,
                Duration = route.Duration,
            };

            if (routeView == null)
            {
                return HttpNotFound();
            }
            return View(routeView);
        }

        //
        // GET: /Route/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Route/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RouteDTO routeDTO)
        {
            var route = repository.CreateRoute(routeDTO);
            if (ModelState.IsValid)
            {
                db.Routes.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(route);
        }

        //
        // GET: /Route/Edit/5

        public ActionResult Edit(int id)
        {
            Route route = repository.GetRoute(id);
            var routeView = new RouteDTO
            {
                RouteId = route.RouteId,
                Depature = route.Depature,
                Destination = route.Destination,
                Duration = route.Duration
            };
            if (routeView == null)
            {
                return HttpNotFound();
            }
            return View(routeView);
        }

        //
        // POST: /Route/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RouteDTO routeDTO)
        {
            var route = repository.UpdateRoute(routeDTO);
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(route);
        }

        //
        // GET: /Route/Delete/5

        public ActionResult Delete(int id)
        {
            Route route = repository.GetRoute(id);

            var routeView = new RouteDTO
            {
                Depature = route.Depature,
                Destination = route.Destination,
                Duration = route.Duration
            };

            if (routeView == null)
            {
                return HttpNotFound();
            }
            return View(routeView);
        }

        //
        // POST: /Route/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = repository.GetRoute(id);
            db.Routes.Attach(route);
            db.Routes.Remove(route);
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