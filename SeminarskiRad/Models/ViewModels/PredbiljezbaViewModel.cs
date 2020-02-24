using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarskiRad.Models.ViewModels
{
    public class PredbiljezbaViewModel
    {
        public IEnumerable<Seminar> Seminar { get; set; }
        public IEnumerable<Predbiljezba> Predbiljezba { get; set; }
    }
}