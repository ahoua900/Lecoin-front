using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecoin.VM;
using Lecoin.DAL;
using Lecoin.Models;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    [Authorize]
    public class CommandesController : Controller
    {
        LecoinContext db = new LecoinContext();
        public List<Panier> GetArticlesOfPanier()
        {
            var data = db.Paniers.Where(s => s.NomClient == User.Identity.Name && s.IsActif == false).ToList();
            return data;
        }
        // GET: Commandes
        [Authorize]
        public ActionResult Mes_commandes()
        {
            ComViewModel model = new ComViewModel();
            model.CommandeRecues = db.Commandes.Where(s => s.NomVendeur == User.Identity.Name).ToList();
            model.CommandeEnvoye = db.Commandes.Where(s => s.Nomclient == User.Identity.Name).ToList();
            model.Paniers = db.Paniers.ToList();
            return View(model);
        }
        [Authorize]
        public ActionResult Mon_panier()
        {
            ComViewModel comView = new ComViewModel();
            comView.Paniers = GetArticlesOfPanier();
            comView.Clients = db.Clients.Where(s => s.Pseudo_Client == User.Identity.Name).SingleOrDefault();
            return View(comView);
        }
        public ActionResult Ajouter_au_panier(int id)
        {
            Panier panier = new Panier();
            var modelexist = db.Paniers.Where(s => s.IdArticle == id && s.NomClient == User.Identity.Name && s.IsActif == false).SingleOrDefault();
            var vendeur = db.Articles.Where(s => s.IdArticle == id).SingleOrDefault();
            if (modelexist == null)
            {
                panier.IsActif = false;
                panier.NomArticle = vendeur.NomArticle;
                panier.NomVendeur = vendeur.NomVendeur;
                panier.IdArticle = id;
                panier.Quantité += 1;
                panier.NomClient = User.Identity.Name;
                panier.SommeTotale += vendeur.Prix;
                panier.PhotoArticle = vendeur.PhotoArticle;
                db.Paniers.Add(panier);
                db.SaveChanges();
            }
            else
            {
                modelexist.Quantité += 1;
                modelexist.SommeTotale += vendeur.Prix;
                panier.PhotoArticle = vendeur.PhotoArticle;
                db.Paniers.Update(modelexist);
                db.SaveChanges();
            }
            return RedirectToAction("Mon_panier","Commandes");
        }
        public ActionResult Delete_Article(int id)
        {
            var model = db.Paniers.Where(s => s.IdPanier == id).SingleOrDefault();
            db.Paniers.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Mon_panier", "Commandes");
        }
        public ActionResult Delivred(int id)
        {
            var model = db.Commandes.Where(s => s.IdCommande == id).SingleOrDefault();
            var models = db.Paniers.Where(s => s.IdPanier == model.IdPanier).SingleOrDefault();
            model.IsDelivred = true;
            db.Commandes.Update(model);
            db.Paniers.Remove(models);
            db.SaveChanges();
            return RedirectToAction("Mes_commandes", "Commandes");
        }
        public ActionResult Resume_achat(int id)
        {
            NegoViewModel nego = new NegoViewModel();
            var model = db.Paniers.Where(s => s.IdPanier == id).SingleOrDefault();
            nego.Panier = model;
            nego.Client = db.Clients.Where(s => s.Pseudo_Client == User.Identity.Name).SingleOrDefault();
            return View(nego);
        }
        [HttpPost]
        public ActionResult Resume_achat(Commande commande, int id)
        {
            NegoViewModel nego = new NegoViewModel();
            var model = db.Paniers.Where(s => s.IdPanier == id).SingleOrDefault();
            var arti = db.Articles.Where(s => s.IdArticle == model.IdArticle).SingleOrDefault();
            nego.Panier = model;
            nego.Client = db.Clients.Where(s => s.Pseudo_Client == User.Identity.Name).SingleOrDefault();
            if (commande.Lieu != null)
            {
                commande.Date = DateTime.Now;
                commande.IdPanier = id;
                commande.Nomclient = User.Identity.Name;
                commande.NumeroCommande = "CMD" + new Random().Next(111111, 999999);
                arti.QuantitéDispo -= 1;
                model.IsActif = true;
                db.Paniers.Update(model);
                db.Articles.Update(arti);
                db.Commandes.Add(commande);
                db.SaveChanges();

                ViewBag.yes = "Votre commande est enrégistrée sous le numéro : " + commande.NumeroCommande;
            }
            else
                ViewBag.err = "Veuillez entrer le lieu de livraison";

            return View(nego);
        }

    }
}