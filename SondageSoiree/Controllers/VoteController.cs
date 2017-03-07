using SondageSoiree.Models;
using SondageSoiree.Models.Entity;
using SondageSoiree.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SondageSoiree.Controllers
{
    public class VoteController : Controller
    {
        private readonly IDal dal;
        public VoteController(IDal dal)
        {
            this.dal = dal;
        }

        public ActionResult CreerVote(int? id)
        {

            int userId = int.Parse(((ClaimsIdentity)User.Identity).Claims.First(s => s.Type == ClaimTypes.NameIdentifier).Value);

            if (dal.VoteExist(id, userId) == true)
                return RedirectToAction("ResultatVote", "Vote", routeValues: new { id = id});
            else
                return View(new VoteViewModel(dal.RenvoieTousLesRestaurants(), id));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreerVote(VoteViewModel v)
        {
            int userId = int.Parse(((ClaimsIdentity)User.Identity).Claims.First(s => s.Type == ClaimTypes.NameIdentifier).Value);

            List<int> liste = v.Choix.Where(c => c.IsSelected).Select(c => c.Id).ToList();

            dal.AjouterVote(v.IdSondage, liste , userId);

            return RedirectToAction("Index", "Sondage");

        }

        public ActionResult ResultatVote(int? id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            return View(dal.ResultatVote(id));
        }

    }
}