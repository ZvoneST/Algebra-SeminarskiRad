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

        public ActionResult Index()
        {
            var predbiljezba = _db.Predbiljezba.Include(s => s.Seminar).ToList();

            return View(predbiljezba);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}