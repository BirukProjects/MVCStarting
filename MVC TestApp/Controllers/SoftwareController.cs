using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Data;
using Services;

namespace MVC_TestApp.Controllers
{
    public class SoftwareController : Controller
    {
        private SoftDevContext db = new SoftDevContext();

        private readonly ISoftwareService _softwareService;
        private readonly IDeveloperService _developerService;
        public SoftwareController(ISoftwareService softwareService, IDeveloperService developerService)
        {
            _softwareService = softwareService;
            _developerService = developerService;
        }

        // GET: /Software/
        public ActionResult Index()
        {
            //var software = db.Software.Include(s => s.developer);
            var software = _softwareService.GetAllSoftware();
            return View(software);
        }

        // GET: /Software/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software software = db.Software.Find(id);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // GET: /Software/Create
        public ActionResult Create()
        {
            ViewBag.dev_id = new SelectList(db.Developers, "id", "Name");
            ViewBag.developers = _developerService.GetAllDeveloper();            
            return View();
        }

        // POST: /Software/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,dev_id,Price")] Software software)
        {
            if (ModelState.IsValid)
            {
                _softwareService.AddSoftware(software);
                return RedirectToAction("Index");
            }

            ViewBag.dev_id = new SelectList(db.Developers, "id", "Name", software.dev_id);
            return View(software);
        }

        // GET: /Software/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software software = db.Software.Find(id);
            if (software == null)
            {
                return HttpNotFound();
            }
            ViewBag.dev_id = new SelectList(db.Developers, "id", "Name", software.dev_id);
            return View(software);
        }

        // POST: /Software/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,dev_id,Price")] Software software)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dev_id = new SelectList(db.Developers, "id", "Name", software.dev_id);
            return View(software);
        }

        // GET: /Software/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software software = db.Software.Find(id);
            if (software == null)
            {
                return HttpNotFound();
            }
            return View(software);
        }

        // POST: /Software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Software software = db.Software.Find(id);
            db.Software.Remove(software);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
