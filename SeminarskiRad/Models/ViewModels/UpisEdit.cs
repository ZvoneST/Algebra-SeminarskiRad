using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SeminarskiRad.Models.Predbiljezba;

namespace SeminarskiRad.Models.ViewModels
{
    public class UpisEdit
    {
        public int IdSeminar { get; set; }
        public string NazivSeminara { get; set; }
        public int IdPredbiljezba { get; set; }
        public DateTime? DatumUpisa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        [Display(Name = "Status Prijave")]
        public Status StatusPrijave { get; set; }
        // public DateTime Datum { get; internal set; }
    }
}