﻿using SeminarskiRad.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SeminarskiRad.Models.ViewModels;
using PagedList;

namespace SeminarskiRad.Controllers
{
    public class SeminarController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Seminar/Index
        [HttpGet]
        public ActionResult Index(string opcija, string pretraga)
        {
            if (opcija == "Naziv")
            {
                return View(_db.Seminar.Where(n => n.Naziv.Contains(pretraga) || pretraga == null).ToList());
            }
            else if (opcija == "Opis")
            {
                return View(_db.Seminar.Where(o => o.Opis.Contains(pretraga) || pretraga == null).ToList());
            }
            else
            {
                return View(_db.Seminar.ToList());
            }
        }


        // GET: Seminar/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seminar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                _db.Seminar.Add(seminar);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(seminar);
        }


        // GET: Seminar/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Seminar seminar = _db.Seminar.Find(id);

            if (seminar == null)
            {
                return HttpNotFound();
            }

            return View(seminar);
        }

        // POST: Seminar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(seminar).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(seminar);
        }

        // GET: Seminar/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var seminar = _db.Seminar.Find(id);

            if (seminar == null)
            {
                return HttpNotFound();
            }

            return View(seminar);
        }

        // GET: Seminar/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var seminar = _db.Seminar.Find(id);

            if (seminar == null)
            {
                return HttpNotFound();
            }

            return View(seminar);
        }

        // POST: Seminar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var seminar = _db.Seminar.Find(id);

            if (seminar == null)
            {
                return View();
            }

            _db.Seminar.Remove(seminar);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
