using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class AchatsController : Controller
    {
        // GET: Achats
        public ActionResult All_Shop()
        {
            return View();
        }
        public ActionResult Shop_article()
        {
            return View();
        }
    }
}