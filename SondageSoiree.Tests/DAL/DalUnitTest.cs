using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SondageSoiree.Tests.Entity;
using SondageSoiree;
using SondageSoiree.Models;
using System.Collections.Generic;
using System;

namespace SondageSoiree.Tests.DAL
{
    /// <summary>
    /// Description résumée pour DalUnitTest
    /// </summary>
    [TestClass]
    public class DalUnitTest
    {
        private SoireeContextTest s;
        private Dal d;
        public DalUnitTest()
        {
            d = new Dal(); 
            s = new SoireeContextTest();
        }



        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void CreerSondageTest()
        {
            int nbSondages = s.Sondage.Count();

            Models.Entity.Sondage son = new Models.Entity.Sondage();
            son.Nom = "TestUnitaire";
            son.Date = new DateTime(2017, 06, 06);
            d.CreerSondage(son);

            int nbSondages2 = s.Sondage.Count();

            Assert.AreEqual(nbSondages + 1, nbSondages2);
        }

        [TestMethod]
        public void AjouterVoteTest()
        {
            int nb = s.Vote.Count();

            //Test avec ajout d'un vote
            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);

            d.AjouterVote(1, l, 7);

            int nb2 = s.Vote.Count();
            Assert.AreEqual(nb + l.Count(), nb2);
        }
    }
}
