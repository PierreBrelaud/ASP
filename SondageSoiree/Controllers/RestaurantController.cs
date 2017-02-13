using SondageSoiree.Models;
using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SondageSoiree.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IDal dal;
        public RestaurantController(IDal dal)
        {
            this.dal = dal;
        }

        [Authorize]
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(dal.RenvoieTousLesRestaurants());
        }

        [Authorize]
        public ActionResult CreerRestaurant()
        {
            return View();
        }

        [Authorize]
        public ActionResult ModifierRestaurant(int id)
        {
            Restaurant r = dal.RenvoieRestaurant(id);
            return View(r);
        }

        [HttpPost]
        public ActionResult ModifierRestaurant(Restaurant r)
        {
            if (dal.RestaurantExist(r.Nom, r.Id) == true)
            {

                ModelState.AddModelError("nameExistModify", " le nom " + r.Nom + " est déjà utilisé !");
                return View(r);
            }
            else
            {
                dal.ModifierRestaurant(r.Id, r.Nom, r.Adresse, r.Telephone, r.Email);
                return RedirectToAction("AfficherRestaurant", new { id = r.Id });
            }
        }

        [Authorize]
        public ActionResult AfficherRestaurant(Restaurant r)
        {
            return View(dal.RenvoieRestaurant(r.Id));
        }

        [HttpPost]
        public ActionResult CreerRestaurant(Restaurant poResto)
        {       
            if (dal.RestaurantExist(poResto.Nom) == true)
            {
                ModelState.AddModelError("nameExist", "Le nom " + poResto.Nom + " est déjà utilisé !");
            }

            if (!ModelState.IsValid || dal.RestaurantExist(poResto.Nom) == true)
            {
                return View(poResto);
            }
            else
            {
                dal.CreerRestaurant(poResto);
                return RedirectToAction("Index");
            }
        }
    }
}