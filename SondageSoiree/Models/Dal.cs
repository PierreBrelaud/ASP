using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SondageSoiree.Models.Entity;
using System.Web.Helpers;

namespace SondageSoiree.Models
{
    public class Dal : IDal
    {
        private SoireeContext s;
        public Dal()
        {
            s = new SoireeContext();
        }

        public void Dispose()
        {
            s.Dispose();
        }

        public void AjouterEtudiant(Eleve e)
        {
            using (var ctx = new SoireeContext())
            {
                e.Password = Crypto.HashPassword(e.Password);
                ctx.Eleves.Add(e);
                ctx.SaveChanges();               
            }
        }

        public int AjouterVote(int idSondage, int idResto, int idEtudiant)
        {
            throw new NotImplementedException();
        }

        public Eleve Authentifier(Eleve eleve)
        {
            Eleve e = new Eleve();
            e = s.Eleves.FirstOrDefault(c => c.Nom == eleve.Nom);
            if (Crypto.VerifyHashedPassword(e.Password, eleve.Password))
                return e;
            else
                return null;
        }

        public void CreerRestaurant(Restaurant r)
        {
            using (var ctx = new SoireeContext())
            {
                ctx.Restaurants.Add(r);
                ctx.SaveChanges();
            }

        }

        public void CreerSondage(Sondage sondage)
        {
            Sondage so = s.Sondages.Add(sondage);
            s.SaveChanges();
            s.Dispose();
        }



        public void ModifierRestaurant(int idResto, string nom, string adresse, string telephone, string email)
        {
            Restaurant r = s.Restaurants.First(c=> c.Id == idResto);

            r.Nom = nom;
            r.Adresse = adresse;
            r.Telephone = telephone;
            r.Email = email;

            s.SaveChanges();
            s.Dispose();
        }

        public void ModifierCompte(int id, string nom, string prenom, string password)
        {
            Eleve e = s.Eleves.First(c => c.Id == id);

            e.Nom = nom;
            e.Prenom = prenom;
            e.Password = Crypto.HashPassword(password);

            s.SaveChanges();
            s.Dispose();
        }

        public Eleve RenvoieEtudiant(string nom)
        {
            Eleve e = s.Eleves.First(c => c.Nom == nom);
            return e;
        }

        public Eleve RenvoieEtudiant(int idEtudiant)
        {
            Eleve e = s.Eleves.FirstOrDefault(c => c.Id == idEtudiant);
            return e;
            
        }

        public Restaurant RenvoieRestaurant(int idRestaurant)
        {
            Restaurant r = new Restaurant();
            using (var ctx = new SoireeContext())
            {
                r = ctx.Restaurants.FirstOrDefault(c=>c.Id==idRestaurant);
            }
            return r;
        }

        public IList<Resultat> RenvoieResultat(int idSondage)
        {
            throw new NotImplementedException();
        }

        public IList<Restaurant> RenvoieTousLesRestaurants()
        {
            List<Restaurant> r = new List<Restaurant>();
            using (var ctx = new SoireeContext())
            {
                foreach(var resto in ctx.Restaurants)
                {
                    r.Add(resto);
                }
            }
            return r;
        }

        public IList<Sondage> RenvoieTousLesSondages()
        {
            List<Sondage> s = new List<Sondage>();
            using (var ctx = new SoireeContext())
            {
                foreach (var sondage in ctx.Sondages)
                {
                    s.Add(sondage);
                }
            }
            return s;
        }

        public bool RestaurantExist(string nom)
        {
            using (var ctx = new SoireeContext())
            {
                var result = ctx.Restaurants.Count(c => c.Nom == nom);
                if (result != 0)
                    return true;
                else
                    return false;
            }
        }

        public bool SondageExist(string nom)
        {
            int result = s.Sondages.Count(c => c.Nom == nom);
            if (result != 0)
                return true;
            else
                return false;
            s.Dispose();

        }

        public bool RestaurantExist(string nom, int id)
        {
            using (var ctx = new SoireeContext())
            {
                var result = ctx.Restaurants.Count(c => c.Nom == nom & c.Id != id);
                if (result != 0)
                    return true;
                else
                    return false;
            }
        }

        public bool EleveExist(string nom, int id)
        {
            using (var ctx = new SoireeContext())
            {
                var result = ctx.Eleves.Count(c => c.Nom == nom & c.Id != id);
                if (result != 0)
                    return true;
                else
                    return false;
            }
        }

        public bool VoteExist(int idSondage, int idEtudiant)
        {
            throw new NotImplementedException();
        }
    }
}