using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarskiRad.Models.ViewModels
{
    public class UpisViewModel
    {
        public List<Seminar> Seminar { get; set; }
        public List<Predbiljezba> Predbiljezba { get; set; }
    }
}