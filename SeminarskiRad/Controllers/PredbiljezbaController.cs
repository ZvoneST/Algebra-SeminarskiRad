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

        
        // GET Početna - Ponuda seminara
        [HttpGet]
        public ActionResult Index()
        {
            var seminariPonuda = _db.Seminar.ToList();

            return View(seminariPonuda);
        }
        
        // GET Pregled predbilježbi
        [HttpGet]
        public ActionResult Predbiljezbe()
        {
            var predbiljezba = _db.Predbiljezba.Include(s => s.Seminar).ToList();

            return View(predbiljezba);
        }

        // GET Upis polanika
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

        //POST Upis polaznika
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
                    StatusPrijave = upis.StatusPrijave
                };

                _db.Predbiljezba.Add(upisPolaznika);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));

            }

            return View(upis);
        }

        // GET Uređivanje predbilježbe
        [HttpGet]
        public ActionResult Uredi(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var predbiljezba = _db.Predbiljezba.Include(s => s.Seminar).FirstOrDefault(p => p.IdPredbiljezba == id);

            UpisEdit upisEdit = new UpisEdit()
            {
                IdSeminar = predbiljezba.IdSeminar,
                NazivSeminara = predbiljezba.Seminar.Naziv,
                IdPredbiljezba = predbiljezba.IdPredbiljezba,
                Ime = predbiljezba.Ime,
                Prezime = predbiljezba.Prezime,
                DatumUpisa = predbiljezba.Datum,
                Adresa = predbiljezba.Adresa,
                Email = predbiljezba.Email,
                Telefon = predbiljezba.Telefon,
                StatusPrijave = predbiljezba.StatusPrijave
            };

            if (upisEdit == null)
            {
                return HttpNotFound();
            }

            return View(upisEdit);
        }

        // POST Spremanje izmijenjene predbilježbe
        [HttpPost, ActionName("Uredi")]
        [ValidateAntiForgeryToken]
        public ActionResult SpremiUredeno(UpisEdit upisModel)
        {
            if (ModelState.IsValid)
            {
                var editUpis = _db.Predbiljezba.Include(s => s.Seminar).Where(p => p.IdPredbiljezba == upisModel.IdPredbiljezba).FirstOrDefault();

                editUpis.IdPredbiljezba = upisModel.IdPredbiljezba;
                editUpis.Datum = upisModel.DatumUpisa;
                editUpis.IdSeminar = upisModel.IdSeminar;
                editUpis.Ime = upisModel.Ime;
                editUpis.Prezime = upisModel.Prezime;
                editUpis.Adresa = upisModel.Adresa;
                editUpis.Email = upisModel.Email;
                editUpis.Telefon = upisModel.Telefon;
                editUpis.StatusPrijave = upisModel.StatusPrijave;

                _db.SaveChanges();

                return RedirectToAction(nameof(Predbiljezbe));                
            }

            return View(upisModel);

        }

        // GET Detalji predbilježbe
        [HttpGet]
        public ActionResult Detalji(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var predbiljezba = _db.Predbiljezba.Include(s => s.Seminar).SingleOrDefault(p => p.IdPredbiljezba == id);

            if (predbiljezba == null)
            {
                return HttpNotFound();
            }

            return View(predbiljezba);
        }

        // GET brisanje predbilježbe
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var predbiljezba = _db.Predbiljezba.Include(s => s.Seminar).FirstOrDefault(p => p.IdPredbiljezba == id);

            UpisEdit upisEdit = new UpisEdit()
            {
                IdSeminar = predbiljezba.IdSeminar,
                NazivSeminara = predbiljezba.Seminar.Naziv,
                IdPredbiljezba = predbiljezba.IdPredbiljezba,
                Ime = predbiljezba.Ime,
                Prezime = predbiljezba.Prezime,
                DatumUpisa = predbiljezba.Datum,
                Adresa = predbiljezba.Adresa,
                Email = predbiljezba.Email,
                Telefon = predbiljezba.Telefon,
                StatusPrijave = predbiljezba.StatusPrijave
            };

            if (upisEdit == null)
            {
                return HttpNotFound();
            }

            return View(upisEdit);
        }

        // POST brisanje predbilježbe
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predbiljezba predbiljezba = _db.Predbiljezba.Find(id);

            _db.Predbiljezba.Remove(predbiljezba);
            _db.SaveChanges();

            return RedirectToAction(nameof(Predbiljezbe));
        }
    }
}