using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Joueur
    {

        // Champs..
        private int id;
        
        private string nom;
        
        private string prenom;

        private string email;

        private string pseudo;

        private DateTime dateNaissance;
        
        // Propriétés..
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }

        // Constructeurs

        public Joueur(int id, string nom, string prenom, string email, string pseudo, DateTime dateNaissance)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Pseudo = pseudo;
            DateNaissance = dateNaissance;
        }
    }
}
