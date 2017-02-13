using System;
using System.ComponentModel.DataAnnotations;

namespace SondageSoiree.Models.Metadata
{
    public class RestaurantMetadata
    {


        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(100)]
        public string Nom;

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [EmailAddress]
        [StringLength(150)]
        public string Email;

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(250)]
        public string Adresse;

        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Numéro de téléphone invalide")]
        [StringLength(20)]
        [Display(Name = "Téléphone")]
        public string Telephone;
    }
}