using System;
using System.Collections.Generic;
using System.Web.Security;
using Lecoin.Models;
using Lecoin.DAL;
using Lecoin.VM;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class HomeController : Controller
    {
        public List<Panier> GetArticlesOfPanier()
        {
            var data = db.Paniers.Where(s => s.NomClient == User.Identity.Name && s.IsActif == false).ToList();
            return data;
        }
        LecoinContext db = new LecoinContext();
        public List<Articles> ArticlesAleatoire()
        {
            List<Articles> articles = new List<Articles>();
            List<int> random = new List<int>();
            var data = db.Articles.ToList();
            foreach (var item in data)
            {
                var id = new Random().Next(1, data.Count());
                random.Add(id);
            }
            foreach (var item in random)
            {
                var model = db.Articles.Where(s => s.IdArticle == item).SingleOrDefault();
                articles.Add(model);
            }
            return articles;
        }
        
        [Authorize]
        public ActionResult Profil()
        {
            var model = db.Clients.Where(s => s.Pseudo_Client == User.Identity.Name).SingleOrDefault();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Profil(Clients clients, string confMod)
        {
            var model = db.Clients.Where(s => s.Pseudo_Client == User.Identity.Name).SingleOrDefault();
            if (clients.MotDePasse != null && clients.MotDePasse == confMod)
            {
                model.MotDePasse = clients.MotDePasse;
                db.Clients.Update(model);
                db.SaveChanges();
                ViewBag.feli = "Profil modifié avec succès";
            }
            return View(model);
        }
        public ActionResult Acceuil()
        {
            HomeViewModel comView = new HomeViewModel();
            if (User.Identity.IsAuthenticated)
            {
                comView.Paniers = GetArticlesOfPanier();
            }
            comView.AllArticles = db.Articles.ToList();
            return View(comView);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Acceuil(Negociation negociation)
        {
            HomeViewModel comView = new HomeViewModel();
            comView.Paniers = GetArticlesOfPanier();
            comView.AllArticles = db.Articles.ToList();
            if ( negociation != null)
            {

                var vendeur = db.Articles.Where(s => s.IdArticle == negociation.IdArticle).SingleOrDefault();
                negociation.NomVendeur = vendeur.NomVendeur;
                negociation.PrixNormal = vendeur.Prix;
                negociation.NomArticle = vendeur.NomArticle;
                if (negociation.Quantité == 0)
                {
                    negociation.Quantité += 1;
                }
                negociation.NomClient = User.Identity.Name;
                negociation.Issuccess = false;
                negociation.Date = DateTime.Now;
                db.Negociations.Add(negociation);
                db.SaveChanges();
                ViewBag.nego = "négociation en traitement";
                return View(comView);
            }
            return View(comView);
        }
        [Authorize]
        public ActionResult Mes_annonces()
        {
            var model = db.Articles.Where(s=>s.NomVendeur == User.Identity.Name).ToList();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Mes_annonces(Articles articles)
        {
            var model = db.Articles.Where(s => s.NomVendeur == User.Identity.Name).ToList();
            if (ModelState.IsValid)
            {
                var file1 = Request.Files[0];
                var fileNames = Path.GetFileName(file1.FileName); //Récupération du nom du fichier;
                var ext = Path.GetExtension(fileNames);
                if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                {
                    var path = Path.Combine(Server.MapPath("/PhotosArticle"), fileNames);//Enregistrement du fichier dans le dossier Fichier
                    file1.SaveAs(path);
                    articles.Date = DateTime.Now;
                    articles.PhotoArticle = fileNames;
                    articles.NomVendeur = User.Identity.Name;
                    db.Articles.Add(articles);
                    db.SaveChanges();
                    Categories cate = new Categories();
                    var iscateorie = db.Categories.Where(s => s.NOmCategorie == articles.Categorie).SingleOrDefault();
                    if (iscateorie == null)
                    {
                        cate.NOmCategorie = articles.Categorie;
                        cate.Nbres =+ 1;
                        db.Categories.Add(cate);
                        db.SaveChanges();
                    }
                    else
                    {
                        var modelupdate = db.Categories.Where(s => s.NOmCategorie == articles.Categorie).SingleOrDefault();
                        modelupdate.Nbres =+ 1;
                        db.Categories.Update(modelupdate);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Mes_annonces");
                }
                else
                {
                    ViewData["errorPdf"] = "Merci de choisir une image";
                    return View(model);
                }
            }
            else
            {
                ViewBag.err = "Veuillez renseigner tous les champs s'il vous plaît";
            }
                
            return View(model);
        }
        /*public ActionResult Edit_annonce(int id)
        {
            var model = db.Articles.Where(s => s.IdArticle == id).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit_annonce(int id,Articles articles)
        {
            var model = db.Articles.Where(s => s.IdArticle == id).ToList();

            return View(model);
        }*/
        public ActionResult Delete_annonce(int id)
        {
            var model = db.Articles.Where(s => s.IdArticle == id).SingleOrDefault();
            var models = db.Paniers.Where(s => s.IdArticle == id).SingleOrDefault();
            if (models != null)
            {
                db.Paniers.Remove(models);
            }
            db.Articles.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Mes_annonces", "Home");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Acceuil", "Home");
        }
    }
}