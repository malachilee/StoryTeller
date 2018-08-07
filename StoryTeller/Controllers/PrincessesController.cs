using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoryTeller;
using Microsoft.AspNet.Identity;
using StoryTeller.Models;

namespace StoryTeller.Controllers
{
    public class PrincessesController : Controller
    {
        private StoryTellerDBEntities db = new StoryTellerDBEntities();

        // GET: Princesses
        public ActionResult Index()
        {
            return View(db.Princesses.ToList());
        }

        // GET: Princesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Princesse princesse = db.Princesses.Find(id);
            if (princesse == null)
            {
                return HttpNotFound();
            }
            return View(princesse);
        }

        // GET: Princesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Princesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrincessID,Text")] Princesse princesse)
        {
            var username = HttpContext.User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                princesse.Author = username;

                db.Princesses.Add(princesse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(princesse);
        }

        // GET: Princesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Princesse princesse = db.Princesses.Find(id);
            if (princesse == null)
            {
                return HttpNotFound();
            }
            return View(princesse);
        }

        // POST: Princesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrincessID,Text")] Princesse princesse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(princesse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var prvw = new PrincessViewModel();
            prvw.PrincessID = princesse.PrincessID;
            prvw.Text = princesse.Text;
            return View(prvw);
        }

        // GET: Princesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Princesse princesse = db.Princesses.Find(id);
            if (princesse == null)
            {
                return HttpNotFound();
            }
            return View(princesse);
        }

        // POST: Princesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Princesse princesse = db.Princesses.Find(id);
            db.Princesses.Remove(princesse);
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
