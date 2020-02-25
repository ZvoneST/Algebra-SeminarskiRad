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
            var seminariPonuda = from s in _db.Seminar
                                 select s;

            return View(seminariPonuda);
        }
        
        // Pregled predbilježbi
        [HttpGet]
        public ActionResult Predbiljezbe()
        {
            var predbiljezba = _db.Predbiljezba.Include(s => s.Seminar).ToList();

            return View(predbiljezba);
        }

        [HttpPost, ActionName("Predbiljezbe")]
        public ActionResult PrijavaPolaznika()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}