using SondageSoiree.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SondageSoiree.ViewModels
{

    public class ChoixRestoViewModel
    {
        public string Nom { get; set; }
        public int Id { get; set; }
        public bool IsSelected { get; set; }
    }


    public class VoteViewModel : IValidatableObject
    {
        private IList<Restaurant> list;
        private int? id;

        [Key]
        public int IdSondage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var valid = new List<ValidationResult>();
            if (Choix.Count(s => s.IsSelected) == 0)
                valid.Add(new ValidationResult("Vous devez au moins un selectionner un restaurant", new[] { "Choix" }));
            return valid;
        }


        public VoteViewModel()
        {
            Choix = new List<ChoixRestoViewModel>();
        }



        public VoteViewModel(IEnumerable<Restaurant> restos, int idSondage)
        {
            IdSondage = idSondage;
            Choix = new List<ChoixRestoViewModel>();
            foreach (var r in restos)
            {
                Choix.Add(new ChoixRestoViewModel() { Id = r.Id, IsSelected = false, Nom = r.Nom });
            }
        }

        public VoteViewModel(IList<Restaurant> list, int? id)
        {
            this.list = list;
            this.id = id;
        }

        public List<ChoixRestoViewModel> Choix { get; private set; }
    }
}