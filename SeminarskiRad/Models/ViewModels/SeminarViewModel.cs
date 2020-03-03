using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SeminarskiRad.Models;

namespace SeminarskiRad.Models.ViewModels
{
    public class SeminarViewModel
    {
        public int IdSeminar { get;  set; }

        [Display(Name = "Naziv seminara")]
        public string NazivSeminara { get; set; }
        public string OpisSeminara { get; set; }

        [Display(Name = "Početak seminara")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DatumSeminara { get; set; }

        [Display(Name = "Broj polaznika")]
        public int BrojPolaznika { get; set; }

        [Display(Name = "Broj upisanih polaznika")]
        public int ZauzetaMjesta { get; set; }

        [Display(Name = "Popunjen")]
        public bool Popunjen { get; set; }

        public int IdPredbiljezba { get; set; }
    }
}