using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Acceuil()
        {
            return View();
        }
        public ActionResult Mes_annonces()
        {
            return View();
        }

    }
}