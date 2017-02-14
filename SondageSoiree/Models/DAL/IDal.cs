using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondageSoiree.Models
{
    public interface IDal : IDisposable
    {
        void AjouterEtudiant(Eleve e);

        int AjouterVote(int idSondage, int idResto, int idEtudiant);

        Eleve Authentifier(Eleve eleve);

        void CreerRestaurant(Restaurant r);

        int CreerSondage(DateTime date);

        void ModifierRestaurant(int idResto, string nom, string adresse, string telephone, string email);

        Eleve RenvoieEtudiant(int idEtudiant);
   
        Eleve RenvoieEtudiant(string nom);

        IList<Resultat> RenvoieResultat(int idSondage);

        IList<Restaurant> RenvoieTousLesRestaurants();

        Restaurant RenvoieRestaurant(int idRestaurant);

        bool RestaurantExist(string nom);

        bool RestaurantExist(string nom, int id);

        bool VoteExist(int idSondage, int idEtudiant);

        bool EleveExist(string nom, int id);
    }
}
