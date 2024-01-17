using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoggingOperationsAssembly;
using ProiectMIPFinal.Models;

namespace ProiectMIPFinal.Controllers
{
    public class PartiController : Controller
    {
        private PartiDbContext partidbctx= new PartiDbContext();
       
        public ActionResult Index()
        {
            return View(partidbctx.PartiSet.ToList());
        }

        [HttpGet]

        public ActionResult Create() 
        {
            PartiModel parte= new PartiModel();
            return View(parte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartiModel parte)
        {
            if (ModelState.IsValid)
            {
                partidbctx.PartiSet.Add(parte);
                partidbctx.SaveChanges();
                bool log = LoggingOps.WriteLog(LoggingOps.filePath, "S-a adaugat o parte. " + parte.Name + " " + parte.Description + " " + parte.Price + " " + parte.Amount);
                return RedirectToAction("Index");
            }
            return View(parte);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            PartiModel parte = partidbctx.PartiSet.Find(id);
            if (null == parte)
            {
                return HttpNotFound();
            }
            return View(parte);
        }

        [HttpPost]
        public ActionResult Edit(PartiModel parte)
        {
            if (ModelState.IsValid)
            {
                partidbctx.Entry(parte).State = System.Data.Entity.EntityState.Modified;
                partidbctx.SaveChanges();
                bool log = LoggingOps.WriteLog(LoggingOps.filePath, "S-a editat o parte. " + parte.Name + " " + parte.Description + " " + parte.Price + " " + parte.Amount);
                return RedirectToAction("Index");
            }
            return View(parte);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            PartiModel parte = partidbctx.PartiSet.Find(id);
            if (null == parte)
            {
                return HttpNotFound();
            }
            return View(parte);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                PartiModel parte = partidbctx.PartiSet.Find(id);
                partidbctx.PartiSet.Remove(parte);
                partidbctx.SaveChanges();
                bool log = LoggingOps.WriteLog(LoggingOps.filePath, "S-a eliminat o parte. " + parte.Name + " " + parte.Description + " " + parte.Price + " " + parte.Amount );
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            PartiModel msg = partidbctx.PartiSet.Find(id);
            if (null == msg)
            {
                return HttpNotFound();
            }

            return View(msg);
        }
    }
}