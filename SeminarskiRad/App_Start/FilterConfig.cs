using System;
using System.Web;
using System.Web.Mvc;

namespace SeminarskiRad
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // pri pokretanju aplikacije odmah nas baca na LogIn page
        }
    }
}
