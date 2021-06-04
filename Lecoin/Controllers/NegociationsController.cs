using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class NegociationsController : Controller
    {
        // GET: Negociations
        public ActionResult Mes_negociations()
        {
            return View();
        }
    }
}