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

        public Equipe GetEquipe()
        {
            return DataBaseConnector.GetEquipeJoueur(this);
        }

        public Equipe GetEquipeDurantTournoi(Tournoi tournoi)
        {
            return DataBaseConnector.GetEquipeJoueurDurantTournoi(this, tournoi);
        }

        public int[] GetStatsTotal()
        {
            return DataBaseConnector.GetStatsTotal(this);
        }

        public double[] GetMoyenneStats()
        {
            return DataBaseConnector.GetMoyenneStats(this);
        }

        public int GetNbSerieJouee()
        {
            return DataBaseConnector.GetNbSerieJouee(this);
        }

        public int GetNbSerieGagnee()
        {
            return DataBaseConnector.GetNbSerieGagnee(this);
        }

        public void PostulerDansEquipe(Equipe equipe)
        {
            DataBaseConnector.PostulerDansEquipe(equipe, this);
        }

        public static Joueur GetJoueurById(int idJoueur)
        {
            return DataBaseConnector.GetJoueurById(idJoueur);
        }

        public static Joueur GetJoueurByEmail(string email)
        {
            return DataBaseConnector.GetJoueurByEmail(email);
        }

        public static void Ajouter(Joueur joueur)
        {
            joueur.Id = DataBaseConnector.AjouterJoueur(joueur);
        }
    }
}
