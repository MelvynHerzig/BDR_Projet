/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Serie.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant une série. 
               Elle reprend chaque champ de la table série de la base de données.
               Contient différentes méthodes en lien avec la série demandant un 
               accès à la base de données

 Remarque(s) : /

 -------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Serie
    {
        private int id;
        private int idTournoi;
        private int noTour;
        private string equipe1;
        private string equipe2;

        public int Id { get => id; set => id = value; }
        public int IdTournoi { get => idTournoi; set => idTournoi = value; }
        public int NoTour { get => noTour; set => noTour = value; }
        public string Equipe1 { get => equipe1; set => equipe1 = value; }
        public string Equipe2 { get => equipe2; set => equipe2 = value; }

        public Serie(int id, int idTournoi, int noTour, string e1, string e2)
        {
            Id = id;
            NoTour = noTour;
            IdTournoi = idTournoi;
            Equipe1 = e1;
            Equipe2 = e2;
        }

        #region Récupération de données en rapport avec la série

        /// <summary>
        /// Récupère les équipes associées à la série
        /// </summary>
        /// <returns>
        /// Liste contenant les 2 équipes. 
        /// Si une équipe n'est pas défini, elle est retourné null
        /// </returns>
        public List<Equipe> GetEquipes()
        {
            Equipe e1 = Equipe1 == null ? null : DataBaseConnector.GetEquipeByAcronyme(Equipe1);
            Equipe e2 = Equipe2 == null ? null : DataBaseConnector.GetEquipeByAcronyme(Equipe2);
            return new List<Equipe>() { e1, e2 };
        }

        /// <summary>
        /// Récupère les matchs appartenant à la série
        /// </summary>
        /// <returns>Liste des matchs de la série</returns>
        public List<Match> GetMatches()
        {
            return DataBaseConnector.GetMatchsFromSerie(this);
        }

        #endregion

        #region Modification de données en rapport avec la série

        /// <summary>
        /// Ajoute le match avec les données envoyés dans la base de données
        /// </summary>
        /// <param name="datas">Liste des données du match</param>
        public void AjouterMatch(List<JoueurMatchData> datas)
        {
            DataBaseConnector.AjouterMatch(datas);
        }

        /// <summary>
        /// Modifie les informations du match
        /// </summary>
        /// <param name="datas">Liste des données modifiées du match</param>
        public void ModifierMatch(List<JoueurMatchData> datas)
        {
            DataBaseConnector.ModifierMatch(datas);
        }

        #endregion
    }
}
