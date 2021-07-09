using System;
using System.Collections.Generic;
using System.Linq;
using Lecoin.Models;
using Lecoin.DAL;
using Lecoin.VM;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    [Authorize]
    public class NegociationsController : Controller
    {
        LecoinContext db = new LecoinContext();
        // GET: Negociations
        public ActionResult Mes_negociations()
        {
            NegoViewModel model = new NegoViewModel();
            model.NegociationsRecues = db.Negociations.Where(s => s.NomVendeur == User.Identity.Name).ToList();
            model.NegociationsEnvoye = db.Negociations.Where(s => s.NomClient == User.Identity.Name).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Mes_negociations(Commande commande)
        {
           
            
            return RedirectToAction("Mes_negociations");
        }
        public ActionResult Accept_Nego(int id)
        {
            var model = db.Negociations.Where(s => s.IdNegociation == id).SingleOrDefault();
            model.Issuccess = true;
            db.Negociations.Update(model);
            db.SaveChanges();
            return RedirectToAction("Mes_negociations");
        }
        public ActionResult Refuse_Nego(int id)
        {
            var model = db.Negociations.Where(s => s.IdNegociation == id).SingleOrDefault();
            model.Issuccess = false;
            db.Negociations.Update(model);
            db.SaveChanges();
            return RedirectToAction("Mes_negociations");
        }
        public ActionResult Ajouter_au_panier(int id)
        {
            Panier panier = new Panier();
            var modelexist = db.Paniers.Where(s => s.IdArticle == id && s.NomClient == User.Identity.Name && s.IsActif == false).SingleOrDefault();
            var vendeur = db.Articles.Where(s => s.IdArticle == id).SingleOrDefault();
            var nego = db.Negociations.Where(s => s.IdArticle == id).SingleOrDefault();
            if (modelexist == null)
            {
                panier.IsActif = false;
                panier.NomVendeur = vendeur.NomVendeur;
                panier.NomArticle = vendeur.NomArticle;
                panier.IdArticle = id;
                if (panier.Quantité == 0)
                {
                    panier.Quantité += 1;
                }
                panier.Quantité += 1;
                panier.NomClient = User.Identity.Name;
                panier.SommeTotale += nego.PrixPropose;
                panier.PhotoArticle = vendeur.PhotoArticle;
                db.Negociations.Remove(nego);
                db.Paniers.Add(panier);
                db.SaveChanges();
            }
            else
            {
                modelexist.Quantité += 1;
                modelexist.SommeTotale += nego.PrixPropose;
                panier.PhotoArticle = vendeur.PhotoArticle;
                db.Paniers.Update(modelexist);
                db.Negociations.Remove(nego);
                db.SaveChanges();
            }
            return RedirectToAction("Mon_panier", "Commandes");
        }
    }
}