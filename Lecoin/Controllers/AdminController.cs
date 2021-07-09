using System;
using System.Collections.Generic;
using System.Linq;
using Lecoin.DAL;
using Lecoin.Models;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class AdminController : Controller
    {
        LecoinContext db = new LecoinContext();
        // GET: Admin
        public ActionResult Clients()
        {
            var model = db.Clients.ToList();
            return View(model);
        }
        public ActionResult DeleteClients(int id)
        {
            var model = db.Clients.Where(s=>s.IdClient == id).SingleOrDefault();
            db.Clients.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Clients");
        }
        public ActionResult Paniers()
        {
            var model = db.Paniers.ToList();
            return View(model);
        }
        public ActionResult DeletePaniers(int id)
        {
            var model = db.Paniers.Where(s => s.IdPanier == id).SingleOrDefault();
            db.Paniers.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Paniers");
        }

    }
}