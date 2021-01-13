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

        private int idResponsable;

        // Propriétés..
        public string Acronyme { get => acronyme; set => acronyme = value; }
        public string Nom { get => nom; set => nom = value; }
        public int IdResponsable { get => idResponsable; set => idResponsable = value; }

        // Constructeurs..
        public Equipe(string acronyme, string nom, int idResponsable)
        {
            Acronyme = acronyme;
            Nom = nom;
            IdResponsable = idResponsable;
        }

        public List<Joueur> GetJoueursFromTournoi(int idTournoi)
        {
            return DataBaseConnector.GetJoueursEquipeTournoi(this, idTournoi);
        }

        public List<Joueur> GetJoueursActuels()
        {
            return DataBaseConnector.GetJoueursEquipeActuels(this);
        }

        public void SupprimerJoueur(Joueur joueur)
        {
            DataBaseConnector.SupprimerJoueurEquipe(this, joueur);
        }

        public override string ToString()
        {
            return Nom;
        }

        public static List<Equipe> GetEquipes()
        {
            return DataBaseConnector.GetAllEquipes();
        }
    }
}
