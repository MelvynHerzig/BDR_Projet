/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Tour.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant un tour. 
               Il reprend chaque champ de la table tour de la base de données.
               Contient différentes méthodes en lien avec le tour demandant un 
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
    public class Tour
    {

        private int no;
        private int longueurMaxSerie;
        private int idTournoi;


        public int No { get => no; set => no = value; }
        public int LongueurMaxSerie { get => longueurMaxSerie; set => longueurMaxSerie = value; }
        public int IdTournoi { get => idTournoi; set => idTournoi = value; }

        public Tour(int no, int longueurMaxSerie, int idTournoi)
        {
            No = no;
            LongueurMaxSerie = longueurMaxSerie;
            IdTournoi = idTournoi;

        }

        /// <summary>
        /// Obtient la série ayant l'id souhaité du tour
        /// </summary>
        /// <param name="idSerie">id de la série du tour</param>
        /// <returns>Serie correspondant à l'id</returns>
        public Serie GetSerieById(int idSerie)
        {
            return DataBaseConnector.GetSerieById(this, idSerie);
        }

        public override string ToString()
        {
            return "Tour no " + No;
        }
    }
}
