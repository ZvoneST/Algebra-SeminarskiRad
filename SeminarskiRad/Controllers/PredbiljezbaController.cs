using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeminarskiRad.Models;
using SeminarskiRad.Models.ViewModels;

namespace SeminarskiRad.Controllers
{
    public class PredbiljezbaController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        
        // Početna - Ponuda seminara
        [HttpGet]
        public ActionResult Index()
        {
            var seminariPonuda = _db.Seminar.ToList();

            return View(seminariPonuda);
        }
        
        // Pregled predbilježbi
        [HttpGet]
        public ActionResult Predbiljezbe()
        {
            var predbiljezba = _db.Predbiljezba.Include(s => s.Seminar).ToList();

            return View(predbiljezba);
        }

        [HttpGet]
        public ActionResult UpisPolaznika(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            UpisViewModel upisPolaznika = new UpisViewModel()
            {
                IdSeminar = _db.Seminar.Find(id).IdSeminar,
                NazivSeminara = _db.Seminar.Find(id).Naziv,
                OpisSeminara = _db.Seminar.Find(id).Opis,
                PocetakSeminara = _db.Seminar.Find(id).Datum
            };

            if (upisPolaznika == null)
            {
                return HttpNotFound();
            }

            return View(upisPolaznika);
        }

        [HttpPost, ActionName("UpisPolaznika")]
        [ValidateAntiForgeryToken]
        public ActionResult UpisPolaznikaPotvrda(UpisViewModel upis)
        {
            if (ModelState.IsValid)
            {
                Predbiljezba upisPolaznika = new Predbiljezba()
                {
                    IdSeminar = upis.IdSeminar,
                    Datum = DateTime.Now,
                    Ime = upis.Ime,
                    Prezime = upis.Prezime,
                    Adresa = upis.Adresa,
                    Email = upis.Email,
                    Telefon = upis.Telefon,
                    StatusPrijave = upis.Status
                };

                _db.Predbiljezba.Add(upisPolaznika);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));

            }

            return View(upis);
        }
    }
}