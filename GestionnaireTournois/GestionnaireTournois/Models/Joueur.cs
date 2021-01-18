/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Joueur.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant un joueur. 
               Il reprend chaque champ de la table joueur de la base de données.
               Contient différentes méthodes en lien avec un joueur demandant un 
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
    public class Joueur
    {

        private int id;

        private string nom;

        private string prenom;

        private string email;

        private string pseudo;

        private DateTime dateNaissance;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }


        public Joueur(int id, string nom, string prenom, string email, string pseudo, DateTime dateNaissance)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Pseudo = pseudo;
            DateNaissance = dateNaissance;
        }


        #region Récupération de données en rapport avec le joueur

        /// <summary>
        /// Récupère l'équipe actuelle du joueur
        /// </summary>
        /// <returns>Equipe actuelle du jours</returns>
        public Equipe GetEquipe()
        {
            return DataBaseConnector.GetEquipeJoueur(this);
        }

        /// <summary>
        /// Récupère l'équipe du joueur lors du tournoi souhaité
        /// </summary>
        /// <param name="tournoi">Tournoi souhaité</param>
        /// <returns>Equipe du jours durant le tournoi</returns>
        public Equipe GetEquipeDurantTournoi(Tournoi tournoi)
        {
            return DataBaseConnector.GetEquipeJoueurDurantTournoi(this, tournoi);
        }

        /// <summary>
        /// Récupère le nombre de buts/arrêts totals sous forme de tableau de int
        /// L'indice du tableau 0 correspond aux buts
        /// L'indice du tableau 1 correspond aux arrêts
        /// </summary>
        /// <returns>tableau de int de taille 2 contenat les buts et arrêts</returns>
        public int[] GetStatsTotal()
        {
            return DataBaseConnector.GetStatsTotal(this);
        }

        /// <summary>
        /// Récupère la moyenne des buts/arrêts par match sous forme de tableau de double
        /// L'indice du tableau 0 correspond à la moyenne des buts
        /// L'indice du tableau 1 correspond à la moyenne des arrêts
        /// </summary>
        /// <returns>tableau de double de taille 2 contenant les moyennes de buts/arrêts</returns>
        public double[] GetMoyenneStats()
        {
            return DataBaseConnector.GetMoyenneStats(this);
        }

        /// <summary>
        /// Récupère le nombre de séries jouer par le joueur
        /// </summary>
        /// <returns>Nombre de séries jouer par le joueur</returns>
        public int GetNbSerieJouee()
        {
            return DataBaseConnector.GetNbSerieJouee(this);
        }

        /// <summary>
        /// Récupère le nombre de séries gagner par le joueur
        /// </summary>
        /// <returns>Nombre de séries gagner par le joueur</returns>
        public int GetNbSerieGagnee()
        {
            return DataBaseConnector.GetNbSerieGagnee(this);
        }


        #endregion

        #region Insertion de données en rapport avec le joueur

        /// <summary>
        /// Fait postuler le joueur dans une équipe.
        /// Celui ci devra attendre d'être accepter.
        /// </summary>
        /// <param name="equipe">Equipe ou postuler</param>
        public void PostulerDansEquipe(Equipe equipe)
        {
            DataBaseConnector.PostulerDansEquipe(equipe, this);
        }

        #endregion

        #region Méthodes statiques en rapport avec un/plusieurs joueur(s) quelconque(s)

        /// <summary>
        /// Récupère le joueur ayant l'email correspondant
        /// </summary>
        /// <param name="email">email du joueur</param>
        /// <returns>Joueur ayant pour email, l'email envoyé</returns>
        public static Joueur GetJoueurByEmail(string email)
        {
            return DataBaseConnector.GetJoueurByEmail(email);
        }

        /// <summary>
        /// Ajoute le joueur passé en paramètre dans la base de données
        /// </summary>
        /// <param name="joueur">Joueur a ajouter dans la base de données</param>
        public static void Ajouter(Joueur joueur)
        {
            joueur.Id = DataBaseConnector.AjouterJoueur(joueur);
        }

        #endregion
    }
}
