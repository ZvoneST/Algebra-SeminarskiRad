﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeminarskiRad.Models
{
    [Table("Seminars")]
    public class Seminar
    {
        [Key]
        public int IdSeminar { get; set; }

        [Required(ErrorMessage = "Naziva seminara je obavezan!")]
        [Display(Name = "Naziv seminara")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Opis seminara je obavezan!")]
        [Display(Name = "Opis seminara")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Unos datuma početka seminara je obavezan!")]
        [Display(Name = "Početak seminara")]
        public DateTime? Datum { get; set; }

        [Required(ErrorMessage = "Unos broja polaznika je obavezan!")]
        [Display(Name = "Broj polaznika")]
        public int BrojPolaznika { get; set; }

        [Display(Name = "Popunjen")]
        public bool Popunjen { get; set; }
    }
}