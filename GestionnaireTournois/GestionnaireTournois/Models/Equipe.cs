using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Equipe
    {

        // Champs..
        private string acronyme;

        private string nom;

        private Joueur responsable;

        // Propriétés..
        public string Acronyme { get => acronyme; set => acronyme = value; }
        public string Nom { get => nom; set => nom = value; }
        internal Joueur Responsable { get => responsable; set => responsable = value; }

        // Constructeurs..
        public Equipe(string acronyme, string nom, Joueur responsable)
        {
            Acronyme = acronyme;
            Nom = nom;
            Responsable = responsable;
        }
    }
}
