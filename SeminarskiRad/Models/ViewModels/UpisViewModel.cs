using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SeminarskiRad.Models.Predbiljezba;

namespace SeminarskiRad.Models.ViewModels
{
    public class UpisViewModel
    {
        public int IdSeminar { get; set; }
        [Display(Name = "Seminar")]
        public string NazivSeminara { get; set; }
        public string OpisSeminara { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime PocetakSeminara { get; set; }
        
        [Required(ErrorMessage ="Unos imena je obavezan")]
        public string Ime { get; set; }
        
        [Required(ErrorMessage = "Unos prezimena je obavezan")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Unos adrese je obavezan")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Unos e-mail adrese je obavezan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unos broja telefona/mobitela je obavezan")]
        public string Telefon { get; set; }
        
        [Display(Name = "Status Prijave")]
        public Status StatusPrijave { get; set; }

    }
}