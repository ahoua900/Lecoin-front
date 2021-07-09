using System;
using System.Web.Security;
using System.Net;
using System.Collections.Generic;
using Lecoin.Models;
using System.Linq;
using System.Web;
using Lecoin.DAL;
using System.Web.Mvc;

namespace Lecoin.Controllers
{
    public class AuthController : Controller
    {
        LecoinContext db = new LecoinContext();
        public Clients GetClientsRegister(Clients clients)
        {
            var model = db.Clients.Where(s=>s.Pseudo_Client == clients.Pseudo_Client ).SingleOrDefault();
            if (model == null)
                return null;
            else
                return clients;
        }
        public Clients LoginSuccess(Clients clients)
        {
            var model = db.Clients.Where(s => s.Email_client.Equals(clients.Email_client) && s.MotDePasse.Equals(clients.MotDePasse)).SingleOrDefault();
            if (model != null)
                return clients;
            else
                return null;
        }
        // GET: Auth
        public ActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Register(Clients clients)
        {
            if (ModelState.IsValid)
            {
                var isalready = GetClientsRegister(clients);
                if (isalready == null)
                {
                    db.Clients.Add(clients);
                    db.SaveChanges();
                    ViewBag.feli = "Inscription éffectuée";
                }
                else
                    ViewBag.already = "Vous êtes déjà enregistré !";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Clients clients)
        {
            var model = db.Clients.Where(s => s.Pseudo_Client.Equals(clients.Pseudo_Client) && s.MotDePasse.Equals(clients.MotDePasse)).SingleOrDefault();
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(model.Pseudo_Client, false);
                return RedirectToAction("Acceuil", "Home");
            }
            else
                ViewBag.errorLog = "Vérifiez vos identifiants";
            return View();
        }
        public ActionResult Forgot_password()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot_password(Clients clients)
        {
            if (clients.Email_client != null)
            {
                var password = db.Clients.Where(s => s.Email_client == clients.Email_client && s.Pseudo_Client == clients.Pseudo_Client).SingleOrDefault();
                ViewBag.passwordtrue = "Votre mot de passe est : " + password.MotDePasse;
            }else
                ViewBag.passwordfalse = "Votre adresse mail n'existe pas";
            return View();
        }
    }
}