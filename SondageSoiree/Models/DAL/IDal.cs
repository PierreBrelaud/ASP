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

        List<Restaurant> ResultatVote(int? id);

        void AjouterVote(int idSondage, List<int> restos, int idEtudiant);

        Eleve Authentifier(Eleve eleve);

        void CreerRestaurant(Restaurant r);

        void CreerSondage(Sondage s);

        void ModifierRestaurant(int idResto, string nom, string adresse, string telephone, string email);

        void ModifierCompte(int id, string nom, string prenom);

        Eleve RenvoieEtudiant(int idEtudiant);
   
        Eleve RenvoieEtudiant(string nom);

        IList<Resultat> RenvoieResultat(int idSondage);

        IList<Restaurant> RenvoieTousLesRestaurants();

        IList<Sondage> RenvoieTousLesSondages();

        Restaurant RenvoieRestaurant(int? idRestaurant);

        bool RestaurantExist(string nom);

        bool RestaurantExist(string nom, int id);

        bool SondageExist(string nom);

        bool VoteExist(int? idSondage, int idEtudiant);

        bool EleveExist(string nom, int id);
    }
}
