/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Equipe.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant une équipe. 
               Elle reprend chaque champ de la table équipe de la base de données.
               Contient différentes méthodes en lien avec l'équipe demandant un 
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
    public class Equipe
    {

        private string acronyme;

        private string nom;

        private int idResponsable;

        public string Acronyme { get => acronyme; set => acronyme = value; }
        public string Nom { get => nom; set => nom = value; }
        public int IdResponsable { get => idResponsable; set => idResponsable = value; }

        public Equipe(string acronyme, string nom, int idResponsable)
        {
            Acronyme = acronyme;
            Nom = nom;
            IdResponsable = idResponsable;
        }

        #region Récupération de données en rapport avec l'équipe

        /// <summary>
        /// Récupère les joueurs de l'équipe au moment du tournoi souhaité
        /// </summary>
        /// <param name="tournoi">Tournoi permettant de connaitre l'état de l'équipe souhaité (quelle date)</param>
        /// <returns>Liste contenant les joueurs de l'équipe ayant participé au tournoi donné</returns>
        public List<Joueur> GetJoueursFromTournoi(Tournoi tournoi)
        {
            return DataBaseConnector.GetJoueursEquipeTournoi(this, tournoi);
        }

        /// <summary>
        /// Récupère les joueurs inscrits dans l'équipe à date actuelle
        /// </summary>
        /// <returns>Liste des joueurs inscrits dans l'équipe actuellement</returns>
        public List<Joueur> GetJoueursActuels()
        {
            return DataBaseConnector.GetJoueursEquipeActuels(this);
        }

        /// <summary>
        /// Obtient la liste des joueurs ayant été membres de l'équipe précemment
        /// </summary>
        /// <returns>Liste contenant les anciens membres de l'équipe</returns>
        public List<Joueur> GetAnciensJoueurs()
        {
            return DataBaseConnector.GetAnciensJoueursEquipe(this);
        }

        /// <summary>
        /// Obtient la liste des joueurs souhaitants rejoindre l'équipe.
        /// </summary>
        /// <returns>Liste contenant les joueurs avec une requête d'inscriptions à l'équipe en attente</returns>
        public List<Joueur> GetJoueursEnAttente()
        {
            return DataBaseConnector.GetJoueursEnAttenteEquipe(this);
        }

        #endregion

        #region Modification de données en rapport avec l'équipe

        /// <summary>
        /// Supprime le joueur donné en parametre de l'équipe.
        /// Supprimer un joueur revient à lui attribuer une date de départ
        /// </summary>
        /// <param name="joueur">Joueur devant quitter l'équipe</param>
        public void SupprimerJoueur(Joueur joueur)
        {
            DataBaseConnector.SupprimerJoueurEquipe(this, joueur);
        }

        /// <summary>
        /// Accepte dans l'équipe le joueur donné en paramètre
        /// Accepter un joueur revient a lui modifier sa date d'arrivée dans l'équipe
        /// </summary>
        /// <param name="joueur">Joueur a accepté</param>
        public void AccepterJoueur(Joueur joueur)
        {
            DataBaseConnector.AccepterJoueurDansEquipe(this, joueur);
        }

        /// <summary>
        /// Abandonne le tournoi. 
        /// Si le tournoi n'a pas commencé, l'équipe va se désinscrire.
        /// Si le tournoi a commencé, l'équipe va automatiquement perdre la série en cours
        /// </summary>
        /// <param name="tournoi">Tournoi a abandonné</param>
        public void AbandonnerTournoi(Tournoi tournoi)
        {
            if (tournoi.EstEnAttente())
            {
                DataBaseConnector.DesinscrireEquipeTournoi(tournoi, this);
            }
            else
            {
                Serie derniereSerie = DataBaseConnector.GetDerniereSerieParticipeParEquipeTournoi(tournoi, this);

                if (DataBaseConnector.GetGagnantSerie(derniereSerie) == null)
                {
                    List<Equipe> equipes = derniereSerie.GetEquipes();

                    if (equipes.Count == 2)
                    {

                        List<Match> matches = derniereSerie.GetMatches();

                        int idDernierMatch = matches.Count == 0 ? 0 : matches[matches.Count - 1].Id;

                        while (DataBaseConnector.GetGagnantSerie(derniereSerie) == null)
                        {
                            DataBaseConnector.AjouterMatch(CreerMatchAbandon(equipes[0], equipes[1], tournoi, derniereSerie, ++idDernierMatch));
                        }
                    }

                }
            }
        }

        #endregion

        #region Méthodes statiques en rapport avec une/plusieurs équipe(s) quelconque(s)

        /// <summary>
        /// Obtient la liste de toutes les équipes dans la base de données
        /// </summary>
        /// <returns>Liste contenant toutes les équipes qui existent</returns>
        public static List<Equipe> GetEquipes()
        {
            return DataBaseConnector.GetAllEquipes();
        }

        /// <summary>
        /// Ajoute l'équipe envoyé en paramètre dans la base de données
        /// </summary>
        /// <param name="equipe">Equipe a ajouter dans la base de données</param>
        public static void Ajouter(Equipe equipe)
        {
            DataBaseConnector.AjouterEquipe(equipe);
        }

        #endregion

        /// <summary>
        /// Créer un match ayant 1 but par joueur pour l'équipe gagnante, et 0 buts par joueur pour l'équipe qui abandonne.
        /// </summary>
        /// <param name="e1">Equipe participant à la série</param>
        /// <param name="e2">Equipe participant à la série</param>
        /// <param name="tournoi">Tournoi a abandonné</param>
        /// <param name="serie">Série a remplir du nouveau match</param>
        /// <param name="idMatch">L'id du match a créer</param>
        /// <returns>Liste contenant les résultats du match créé pour chaque joueur</returns>
        private List<JoueurMatchData> CreerMatchAbandon(Equipe e1, Equipe e2, Tournoi tournoi, Serie serie, int idMatch)
        {
            List<JoueurMatchData> datas = new List<JoueurMatchData>();

            Equipe perdant = e1.Acronyme == this.Acronyme ? e1 : e2;
            Equipe gagnant = e1.Acronyme == this.Acronyme ? e2 : e1;

            #region Perdant
            {
                List<Joueur> joueurs = perdant.GetJoueursFromTournoi(tournoi);

                JoueurMatchData j1 = new JoueurMatchData(joueurs[0].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "0", "0");

                JoueurMatchData j2 = new JoueurMatchData(joueurs[1].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "0", "0");

                JoueurMatchData j3 = new JoueurMatchData(joueurs[2].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "0", "0");

                datas.Add(j1);
                datas.Add(j2);
                datas.Add(j3);
            }
            #endregion

            #region Gagnant
            {
                List<Joueur> joueurs = gagnant.GetJoueursFromTournoi(tournoi);

                JoueurMatchData j1 = new JoueurMatchData(joueurs[0].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "1", "0");

                JoueurMatchData j2 = new JoueurMatchData(joueurs[1].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "1", "0");

                JoueurMatchData j3 = new JoueurMatchData(joueurs[2].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "1", "0");

                datas.Add(j1);
                datas.Add(j2);
                datas.Add(j3);
            }
            #endregion

            return datas;
        }

        public override string ToString()
        {
            return Nom;
        }

    }
}
