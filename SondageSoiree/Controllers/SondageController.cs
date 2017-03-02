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
    public class SondageController : Controller
    {
        private readonly IDal dal;
        public SondageController(IDal dal)
        {
            this.dal = dal;
        }
        // GET: Sondage

        [Authorize]
        public ActionResult Index()
        {
            return View(dal.RenvoieTousLesSondages());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreerSondage()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreerSondage(Sondage sondage)
        {
            if (dal.SondageExist(sondage.Nom) == true)
            {
                ModelState.AddModelError("nameExist", "Le sondage" + sondage.Nom + " a déjà été créé !");
            }

            DateTime t = new DateTime(01,01,0001,00,00,00);

            if (sondage.Date < DateTime.Now && sondage.Date != t)
            {
                ModelState.AddModelError("dateError", "La date du sondage soit être supérieur à la date du jour");
            }

            if (!ModelState.IsValid || dal.SondageExist(sondage.Nom) == true || sondage.Date < DateTime.Now)
            {
                return View(sondage);
            }
            else
            {
                dal.CreerSondage(sondage);
                return RedirectToAction("Index");
            }
        }
    }
}