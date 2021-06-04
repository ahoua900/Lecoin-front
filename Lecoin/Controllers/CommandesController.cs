using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class CommandesController : Controller
    {
        // GET: Commandes
        public ActionResult Mes_commandes()
        {
            return View();
        }
        public ActionResult Mon_panier()
        {
            return View();
        }
    }
}