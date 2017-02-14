using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SondageSoiree.Models.Metadata
{
    public class SondageMetadata
    {

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date;


        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(150)]
        public string Nom;
    }
}