using System;
using System.Collections.Generic;
using Lecoin.Models;
using Lecoin.DAL;
using Lecoin.VM;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class ProfilVendeurController : Controller
    {
        LecoinContext db = new LecoinContext();
        // GET: ProfilVendeur
        public ActionResult Vendeur(string id)
        {
            var client = db.Clients.Where(s => s.Pseudo_Client == id).SingleOrDefault();
            VendeurVM vendeur = new VendeurVM();
            vendeur.Clients = client;
            vendeur.Articles = db.Articles.Where(s => s.NomVendeur == client.Pseudo_Client).ToList();
            return View(vendeur);
        }
    }
}