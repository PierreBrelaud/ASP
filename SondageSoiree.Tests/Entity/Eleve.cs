//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SondageSoiree.Tests.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Eleve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Eleve()
        {
            this.Vote = new HashSet<Vote>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vote> Vote { get; set; }
    }
}
