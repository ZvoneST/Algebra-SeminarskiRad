using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SeminarskiRad.Models;
using SeminarskiRad.Models.ViewModels;

namespace SeminarskiRad.Controllers
{
    public class PredbiljezbaController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        
        // GET Početna - Ponuda seminara
        [HandleError]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string opcija, string pretraga, int? pageNumber)
        {
            // search functionality implementation https://www.c-sharpcorner.com/UploadFile/219d4d/implement-search-paging-and-sort-in-mvc-5/

            if (opcija == "Naziv")
            {
                return View(_db.Seminar.Where(n => n.Naziv.Contains(pretraga) || pretraga == null).ToList().ToPagedList(pageNumber ?? 1, 4));
            }
            else if (opcija == "Opis")
            {
                return View(_db.Seminar.Where(o => o.Opis.Contains(pretraga) || pretraga == null).ToList().ToPagedList(pageNumber ?? 1, 4));
            }
            else
            {
                return View(_db.Seminar.ToList().ToPagedList(pageNumber ?? 1, 4));
            }
        }
        
        // GET Pregled predbilježbi
        [HttpGet]
        public ActionResult Predbiljezbe(string opcija, string pretraga)
        {
            if (opcija == "Naziv")
            {
                return View(_db.Predbiljezba.Include(s => s.Seminar).Where(n => n.Seminar.Naziv.Contains(pretraga) || pretraga == null).ToList());

            }
            return View(_db.Predbiljezba.Include(s => s.Seminar).Where(i => i.Ime.Contains(pretraga) || i.Prezime.Contains(pretraga) || pretraga == null).ToList());
        }

        // GET Upis polanzika
        [HandleError]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult UpisPolaznika(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
        [HandleError]
        [HttpPost, ActionName("UpisPolaznika")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
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

                return View("EnrollComplete");

            }

            return View(upis);
        }

        // GET Uređivanje predbilježbe
        [HttpGet]
        public ActionResult Uredi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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