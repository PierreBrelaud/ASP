using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SondageSoiree.Models.Metadata
{
    public class CompteMetadata
    {

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(100)]
        public string Nom;


        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(250)]
        public string Prenom;

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(100)]
        [MinLength(6)]
        public string Password;
    }
}