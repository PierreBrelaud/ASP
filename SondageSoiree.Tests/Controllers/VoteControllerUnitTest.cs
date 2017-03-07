using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SondageSoiree.Controllers;
using SondageSoiree.Models.DAL;
using SondageSoiree.Models.Entity;
using System.Web;
using System.Security.Claims;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using SondageSoiree.ViewModels;
using SondageSoiree.Models;

namespace SondageSoiree.Tests.Controllers
{



    [TestClass]
    public class VoteControllerUnitTest : TestControllerBase
    {
        private IDal dal;
        private Sondage sondage;
        private IList<Eleve> eleves;
        private IList<Restaurant> allRestaurant;


        [TestInitialize]
        public void Initialize() 
        {
            eleves = new List<Eleve>();
            using (var ctx = new SoireeContext()) 
            {
                sondage = new Sondage()
                {
                    Date = DateTime.Today.AddYears(30),
                };
                allRestaurant = ctx.Restaurants.ToList();
                ctx.Sondages.Add(sondage);
                Eleve eleve;
                for (int i = 0; i < 4; i++) 
                {
                    eleve = new Eleve()
                    {   
                        Nom = "TestEleve"+i,
                        Password = Crypto.HashPassword("testElevePwd"+i),
                        Prenom = "Prenom" + i,
                    };
                    ctx.Eleves.Add(eleve);
                    eleves.Add(eleve);
                }

                ctx.SaveChanges();
            }
            dal = new Dal();
            
        }

        [TestCleanup]
        public void CleanUp()
        {
            dal.Dispose();
            using (var ctx = new SoireeContext())
            {
                ctx.Sondages.Attach(sondage);
                ctx.Sondages.Remove(sondage);

                foreach (var e in eleves)
                    ctx.Eleves.Attach(e);
                ctx.Eleves.RemoveRange(eleves);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Cas standard : test d'un utilisateur qui n'a pas encore voté et qui accede au vote
        /// </summary>
        [TestMethod]
        public void VoteGetValide()
        {
            var ctrl = new VoteController(dal);
            FillControllerContext(ctrl, eleves[0]);
            
            //Test sondage valide (utilisateur en cours n'a pas voté)

            var vr = ctrl.CreerVote(sondage.Id) as ViewResult;

            //Verif 1 : on a bien un objet ViewResult
            Assert.IsNotNull(vr);

            //Verif 2 : Le nom de la vue doit être celui par défault ou "Voter"
            Assert.IsTrue(  string.IsNullOrEmpty(vr.ViewName) || vr.ViewName == "Voter");

            //Verif 3 : on a bien un Model de type VoteViewModel
            var vm = vr.Model as VoteViewModel;

            //Verif 4 : on s'assure que le view model est bon
            Assert.AreEqual(sondage.Id, vm.IdSondage);
            Assert.AreEqual(allRestaurant.Count, vm.Choix.Count);
        }

        /// <summary>
        /// Cas d'un identifiant de sondage incorrect (null, qui n'existe pas en base,...)
        /// </summary>
        [TestMethod]
        public void VoteGetBadId()
        {
            Assert.Fail("A completer");
        }


        /// <summary>
        /// Cas d'un eleve qui a déjà voté pour le sondage. (Note utilisé entity framework pour rajouter le vote en début du test).
        /// Tester que l'on est bien rediriger (on doit obtenir un objet RedirectToRouteResult, avec le bon controlleur et la bonne action)
        /// </summary>
        [TestMethod]
        public void VoteGetDejaVotee()
        {
            Assert.Fail("A completer");
        }



        /// <summary>
        /// Cas standard : l'utilisateur renvois un formulaire correctement remplit, le vote doit être inséré et l'utilisateur rediriger
        /// </summary>
        [TestMethod]
        public void VotePostValide()
        {
            Assert.Fail("A completer");
        }

        /// <summary>
        /// L'utilisateur ne choisit aucun restaurant : il doit obtenir la vue a nouveau la vue Voter avec un message d'erreur
        /// </summary>
        [TestMethod]
        public void VotePostAucunChoix()
        {
            Assert.Fail("A completer");
        }

        /// <summary>
        /// Cas d'un identifiant de sondage incorrect (null, qui n'existe pas en base,...)
        /// En théorie ce cas ne peux pas se produire sauf si l'utilisateur tente de détourner le systeme : a tester !!
        /// </summary>
        [TestMethod]
        public void VotePostBadId()
        {
            Assert.Fail("A completer");
        }


        /// <summary>
        /// Cas d'un ViewModel renvoyé incorect (null, SondageId = 0, SondageId != de l'id de l'url,...)
        /// En théorie ce cas ne peux pas se produire sauf si l'utilisateur tente de détourner le systeme : a tester !!
        /// </summary>
        [TestMethod]
        public void VotePostBadVm()
        {
            Assert.Fail("A completer");
        }



        /// <summary>
        /// Cas d'un eleve qui a déjà voté pour le sondage. (Note utilisé entity framework pour rajouter le vote en début du test).
        /// </summary>
        [TestMethod]
        public void VotePostDejaVote()
        {
            Assert.Fail("A completer");
        }


        /// <summary>
        /// Cas standard : test d'un utilisateur qui accede au résultat d'un sondage auquel il n'a jamais voté
        /// </summary>
        [TestMethod]
        public void ResultatGetValide()
        {
            Assert.Fail("A completer");
        }

        /// <summary>
        /// Cas d'un identifiant de sondage incorrect (null, qui n'existe pas en base,...)
        /// </summary>
        [TestMethod]
        public void ResultatGetBadId()
        {
            Assert.Fail("A completer");
        }


        /// <summary>
        /// Cas d'un eleve qui n'a pas encore voté pour le sondage.
        /// </summary>
        [TestMethod]
        public void ResultatGetPasEncoreVote()
        {
            Assert.Fail("A completer");
        }

    }
}
