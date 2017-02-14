using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SondageSoiree.Models;
using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SondageSoiree.Controllers
{
    public class CompteController : Controller
    {
        private readonly IDal dal;
        public CompteController(IDal dal)
        {
            this.dal = dal;
        }

        public ActionResult LogOff()
        {
            IdentitySignout();
            return RedirectToAction("Login");
        }

        // GET: Compte
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Eleve e)
        {
            if (dal.Authentifier(e) == null)
            {
                ModelState.AddModelError("Authentifier", "Identifiant ou mot de passe incorrect !");
                return View(e);
            }
            else
            {
                IdentitySignin(dal.RenvoieEtudiant(e.Nom));
                return RedirectToAction("Index","Restaurant");
            }
        }

        public ActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerCompte(Eleve e)
        {
            if (dal.EleveExist(e.Nom, e.Id) == true)
                ModelState.AddModelError("studentExist", "Le nom " + e.Nom + " est déjà utilisé !");

            if (!ModelState.IsValid || dal.EleveExist(e.Nom, e.Id) == true)
            {
                return View(e);
            }
            else
            {
                dal.AjouterEtudiant(e);
                return RedirectToAction("Index","Restaurant");
            }
        }

        private void IdentitySignin(Eleve eleve)
        {
            var claims = new List<Claim>();
            if (eleve.Role != null) claims.Add(new Claim(ClaimTypes.Role, eleve.Role));
            // create required claims 
            claims.Add(new Claim(ClaimTypes.NameIdentifier, eleve.Id.ToString())); claims.Add(new Claim(ClaimTypes.Name, eleve.Nom));
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie); HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties() { AllowRefresh = true, IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddDays(7) }, identity);
            
        }
        private void IdentitySignout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
        }

    }
}