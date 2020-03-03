using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Unos datuma početka seminara je obavezan!")]
        [Display(Name = "Početak seminara")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Unos broja polaznika je obavezan!")]
        [Display(Name = "Broj slobodnih mjesta")]
        public int BrojPolaznika { get; set; }

        [Display(Name = "Popunjen")]
        public bool Popunjen { get; set; }
        public DbSet<Seminar> Seminari { get; internal set; }
    }
}