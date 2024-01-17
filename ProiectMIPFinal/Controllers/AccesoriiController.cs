using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoggingOperationsAssembly;
using ProiectMIPFinal.Models;

namespace ProiectMIPFinal.Controllers
{
    public class AccesoriiController : Controller
    {
        private AccesoriiDbContext accesoriidbctx = new AccesoriiDbContext();
        // GET: Accesorii
        public ActionResult Index()
        {
            return View(accesoriidbctx.AccesoriiSet.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {
            Accesorii accesoriu = new Accesorii();
            return View(accesoriu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Accesorii accesoriu)
        {
            if (ModelState.IsValid)
            {
                accesoriidbctx.AccesoriiSet.Add(accesoriu);
                accesoriidbctx.SaveChanges();
                bool log = LoggingOps.WriteLog(LoggingOps.filePath, "S-a adaugat o accesoriu. " + accesoriu.Name + " " + accesoriu.Type + " " + accesoriu.Manufacturer);
                return RedirectToAction("Index");
            }
            return View(accesoriu);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Accesorii accesoriu = accesoriidbctx.AccesoriiSet.Find(id);
            if (null == accesoriu)
            {
                return HttpNotFound();
            }
            return View(accesoriu);
        }

        [HttpPost]
        public ActionResult Edit(Accesorii accesoriu)
        {
            if (ModelState.IsValid)
            {
                accesoriidbctx.Entry(accesoriu).State = System.Data.Entity.EntityState.Modified;
                accesoriidbctx.SaveChanges();
                bool log = LoggingOps.WriteLog(LoggingOps.filePath, "S-a editat o accesoriu. " + accesoriu.Name + " " + accesoriu.Type + " " + accesoriu.Manufacturer);
                return RedirectToAction("Index");

            }
            return View(accesoriu);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            Accesorii accesoriu = accesoriidbctx.AccesoriiSet.Find(id);
            if (null == accesoriu)
            {
                return HttpNotFound();
            }
            return View(accesoriu);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                Accesorii accesoriu = accesoriidbctx.AccesoriiSet.Find(id);
                accesoriidbctx.AccesoriiSet.Remove(accesoriu);
                accesoriidbctx.SaveChanges();
                bool log = LoggingOps.WriteLog(LoggingOps.filePath, "S-a eliminat o accesoriu. " + accesoriu.Name + " " + accesoriu.Type + " " + accesoriu.Manufacturer);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Accesorii msg = accesoriidbctx.AccesoriiSet.Find(id);
            if (null == msg)
            {
                return HttpNotFound();
            }

            return View(msg);
        }
    }
}