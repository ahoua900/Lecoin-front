using System;
using System.Collections.Generic;
using System.Linq;
using Lecoin.VM;
using Lecoin.DAL;
using Lecoin.Models;
using System.Web;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class AchatsController : Controller
    {
        LecoinContext db = new LecoinContext();
        // GET: Achats
        public List<Articles> Articles()
        {
            return db.Articles.ToList();
        }
        public List<Articles> ArticlesCategories(string id)
        {
            return db.Articles.Where(s=>s.Categorie == id).ToList();
        }
        public ActionResult All_Shop(string id)
        {
            if (id == null)
            {
                ShopViewModel models = new ShopViewModel();
                models.Articles = Articles();
                models.Categories = db.Categories.ToList();
                return View(models);
            }
            else
            {
                ShopViewModel models = new ShopViewModel();
                models.Articles = ArticlesCategories(id);
                models.Categories = db.Categories.ToList();
                return View(models);
            }
           
        }
        [HttpPost]
        public ActionResult All_Shop(string search, Negociation negociation)
        {
            ShopViewModel models = new ShopViewModel();
            if (search != null)
            {
                var data = db.Articles.Where(s => s.NomArticle.Contains(search) || s.Categorie.Contains(search)).ToList();
                models.Articles = data;
                if (data == null)
                {
                    ViewData["no"] = "Pas de résultats pour votre recherche";
                    models.Articles = db.Articles.Where(s => s.NomArticle != search).ToList();
                }
                models.Categories = db.Categories.ToList();
                return View(models);
            }
            else
            {
                var vendeur = db.Articles.Where(s => s.IdArticle == negociation.IdArticle).SingleOrDefault();
                negociation.NomVendeur = vendeur.NomVendeur;
                negociation.NomArticle = vendeur.NomArticle;
                if (negociation.Quantité == 0)
                {
                    negociation.Quantité += 1;
                }
                negociation.PrixNormal = vendeur.Prix * negociation.Quantité;
                negociation.PrixPropose = negociation.PrixPropose * negociation.Quantité;
                negociation.NomClient = User.Identity.Name;
                negociation.Issuccess = false;
                negociation.Date = DateTime.Now;
                db.Negociations.Add(negociation);
                db.SaveChanges();
                ViewBag.nego = "négociation en traitement";
                models.Articles = db.Articles.ToList();
                models.Categories = db.Categories.ToList();
                return View(models);
            }
        }
        public ActionResult Shop_article(int id)
        {
            var article = db.Articles.Where(s => s.IdArticle == id).SingleOrDefault();
            ShopViewModel model = new ShopViewModel();
            model.Article = article;
            model.Articles = db.Articles.Where(s => s.NomArticle.Contains(article.NomArticle) && s.IdArticle != id).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Shop_article(int id,Negociation negociation)
        {
            var article = db.Articles.Where(s => s.IdArticle == id).SingleOrDefault();
            ShopViewModel model = new ShopViewModel();
            model.Article = article;
            model.Articles = db.Articles.Where(s => s.NomArticle.Contains(article.NomArticle)).ToList();
            if (negociation != null)
            {
                var vendeur = db.Articles.Where(s => s.IdArticle == negociation.IdArticle).SingleOrDefault();
                negociation.NomVendeur = vendeur.NomVendeur;
                negociation.NomArticle = vendeur.NomArticle;
                if (negociation.Quantité == 0)
                {
                    negociation.Quantité += 1;
                }
                negociation.PrixNormal = vendeur.Prix * negociation.Quantité;
                negociation.PrixPropose = negociation.PrixPropose * negociation.Quantité;
                negociation.NomClient = User.Identity.Name;
                negociation.Issuccess = false;
                negociation.Date = DateTime.Now;
                db.Negociations.Add(negociation);
                db.SaveChanges();
                ViewBag.nego = "négociation en traitement";
            }
            return View(model);
        }
    }
}