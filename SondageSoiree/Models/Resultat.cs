using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SondageSoiree.Models
{
    public class Resultat
    {
        private string nom;

        public string Nom
        {
            get{return nom; }

            set{nom = value;}
        }

        public int NbVote
        {
            get{return nbVote; }
            set {nbVote = value;}
        }

        private int nbVote;
    }
}