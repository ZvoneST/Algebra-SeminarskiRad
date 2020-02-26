﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeminarskiRad.Models
{
    [Table("Predbiljezbas")]
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }

        [Display(Name = "Datum prijave")]
        public DateTime? Datum { get; set; }

        [Required(ErrorMessage = "Obavezan unos imena")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezan unos prezimena")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezan unos adrese polaznika")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Obavezan unos e-mail adrese polaznika")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Tel/Mob")]
        public string Telefon { get; set; }

        [ForeignKey("Seminar")]
        public int IdSeminar { get; set; }

        public Seminar Seminar { get; set; }

        [Display(Name = "Status prijave")]
        public Status StatusPrijave { get; set; }

        public enum Status
        {
            [Display(Name = "Neobrađena prijava")]
            neobrađena = 0,

            [Display(Name = "Prihvaćena prijava")]
            prihvacena = 1,

            [Display(Name = "Odbijena prijava")]
            odbijena = 2

        }
    }
}