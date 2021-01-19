/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Match.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant un match. 
               Il reprend chaque champ de la table match de la base de données.
               Contient différentes méthodes en lien avec le match demandant un 
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
    public class Match
    {
        private int id;

        private int idSerie;

        private int noTour;

        private int idTournoi;

        public int Id { get => id; set => id = value; }
        internal int IdSerie { get => idSerie; set => idSerie = value; }
        public int NoTour { get => noTour; set => noTour = value; }
        public int IdTournoi { get => idTournoi; set => idTournoi = value; }


        public Match(int id, int idTournoi, int noTour, int idSerie)
        {
            Id = id;
            IdSerie = idSerie;
            NoTour = noTour;
            IdTournoi = idTournoi;
        }


        /// <summary>
        /// Obtient les buts et arrêts du joueur souhaité pour le match
        /// </summary>
        /// <param name="j">Joueur souhaité</param>
        /// <returns>tableau de int ayant le nombre de buts / arrêts du match pour le joueur</returns>
        public int[] GetDataJoueur(Joueur j)
        {
            return DataBaseConnector.GetDataJoueur(this, j);
        }

        public override string ToString()
        {
            return "Match " + Id;
        }
    }
}
