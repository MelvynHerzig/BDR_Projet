/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Tournoi.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant une tournoi. 
               Elle reprend chaque champ de la table tournoi de la base de données.
               Contient différentes méthodes en lien avec le tournoi demandant un 
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
    public class Tournoi
    {

        public enum EtatTournoi { TOUS, EN_ATTENTE, EN_COURS, TERMINES, ANNULES };

        public static string[] EtatTournoiNom = { "Tous", "En attente", "En cours", "Terminés", "Annulés" };

        private int id;

        private DateTime dateHeureDebut;

        private DateTime dateHeureFin;

        private string nom;

        private int nbEquipesMax;

        private int idPremierPrix;

        private int idDeuxiemePrix;


        public int Id { get => id; set => id = value; }
        public DateTime DateHeureDebut { get => dateHeureDebut; set => dateHeureDebut = value; }
        public DateTime DateHeureFin { get => dateHeureFin; set => dateHeureFin = value; }
        public string Nom { get => nom; set => nom = value; }
        public int NbEquipesMax { get => nbEquipesMax; set => nbEquipesMax = value; }
        public int IdPremierPrix { get => idPremierPrix; set => idPremierPrix = value; }
        public int IdDeuxiemePrix { get => idDeuxiemePrix; set => idDeuxiemePrix = value; }


        public Tournoi(int id, DateTime debut, DateTime fin, string nom, int nbEquipesMax, int idPremierPrix, int idDeuxiemePrix)
        {
            Id = id;
            DateHeureDebut = debut;
            DateHeureFin = fin;
            Nom = nom;
            NbEquipesMax = nbEquipesMax;
            IdPremierPrix = idPremierPrix;
            IdDeuxiemePrix = idDeuxiemePrix;
        }

        #region Récupération de données en rapport avec le tournoi

        /// <summary>
        /// Récupère le nombre de tours du tounoi
        /// </summary>
        /// <returns>Nombre de tours du tournoi</returns>
        public int GetNbTours()
        {
            return DataBaseConnector.GetNbToursTournoi(this);
        }

        /// <summary>
        /// Récupère le gagnant du tournoi
        /// </summary>
        /// <returns>Equipe gagnante du tournoi</returns>
        public Equipe GetGagnant()
        {

            return DataBaseConnector.GetGagnantSerie(new Serie(1, Id, 1, null, null));
        }

        /// <summary>
        /// Récupère les tours du tournoi
        /// </summary>
        /// <returns>Liste des tours du tournoi</returns>
        public List<Tour> GetTours()
        {
            return DataBaseConnector.GetTours(this);
        }

        /// <summary>
        /// Récupère le tour associé au no souhaité du tournoi
        /// </summary>
        /// <param name="noTour">numéro du tour à récupérer</param>
        /// <returns>Tour associé au numéro souhaité</returns>
        public Tour GetTourByNo(int noTour)
        {
            return DataBaseConnector.GetTourByNo(this, noTour);
        }

        /// <summary>
        /// Récupère les équipes inscrites au tournoi
        /// </summary>
        /// <returns>Liste des équipes inscrites au tournoi</returns>
        public List<Equipe> GetEquipesInscrites()
        {
            return DataBaseConnector.GetEquipesInscritesTournoi(this);
        }

        /// <summary>
        /// Obtient le premier prix
        /// </summary>
        /// <returns>Premier prix du tournoi</returns>
        public Prix GetPremierPrix()
        {
            return DataBaseConnector.GetPrixById(IdPremierPrix);
        }

        /// <summary>
        /// Obtient le deuxième prix du tournoi
        /// </summary>
        /// <returns>Deuxième prix du tournoi</returns>
        public Prix GetDeuxiemePrix()
        {
            return DataBaseConnector.GetPrixById(IdDeuxiemePrix);
        }

        /// <summary>
        /// Récupère si le tournoi est en attente (n'a pas encore commencé)
        /// </summary>
        /// <returns>true -> le tournoi est en attente</returns>
        public bool EstEnAttente()
        {
            return DataBaseConnector.IsTournoiEnAttente(this);
        }

        #endregion

        #region Modification de données en rapport avec le tournoi

        /// <summary>
        /// Démarre le tournoi en appelant la procédure dans la base de données
        /// </summary>
        public void StartTournoi()
        {
            DataBaseConnector.StartTournoi(this);
        }

        /// <summary>
        /// Modifie les données des tours du tournoi
        /// </summary>
        /// <param name="tours">Liste des tours modifiés</param>
        public void ModifierTours(List<Tour> tours)
        {
            DataBaseConnector.ModifierToursTournoi(this, tours);
        }

        /// <summary>
        /// Modifie les propriétés du tournoi
        /// </summary>
        /// <param name="nom">Nouveau nom du tournoi</param>
        /// <param name="dateDebut">Nouvelle date de début du tournoi</param>
        public void ModifierProprietes(string nom, DateTime dateDebut)
        {
            DataBaseConnector.ModifierProprietesTournoi(this, nom, dateDebut);
        }

        /// <summary>
        /// Ajoute le premier prix du tournoi
        /// </summary>
        /// <param name="prix">prix a ajouter</param>
        public void AjouterPremierPrix(Prix prix)
        {
            if (IdPremierPrix != 0 || prix == null || prix.Id == 0) return;
            DataBaseConnector.AjouterPremierPrix(this, prix);
            IdPremierPrix = prix.Id;
        }

        /// <summary>
        /// Ajoute le deuxième prix du tournoi
        /// </summary>
        /// <param name="prix">prix a ajouter</param>
        public void AjouterDeuxiemePrix(Prix prix)
        {
            if (IdDeuxiemePrix != 0 || prix == null || prix.Id == 0) return;
            DataBaseConnector.AjouterDeuxiemePrix(this,prix);
            IdDeuxiemePrix = prix.Id;
        }

        /// <summary>
        /// Inscrit l'équipe en paramètre au tournoi
        /// </summary>
        /// <param name="equipe">Equipe a inscrire</param>
        public void Inscrire(Equipe equipe)
        {
            DataBaseConnector.InscrireEquipeTournoi(this, equipe);
        }

        #endregion

        #region Méthodes statiques en rapport avec une/plusieurs équipe(s) quelconque(s)

        /// <summary>
        /// Récupère le tournoi correspondant à l'id en paramètre
        /// </summary>
        /// <param name="idTournoi">Tournoi a récupérer</param>
        /// <returns>Tournoi souhaité</returns>
        public static Tournoi GetTournoiById(int idTournoi)
        {
            return DataBaseConnector.GetTournoiById(idTournoi);
        }

        /// <summary>
        /// Obtient la liste des tournois en fonction de l'état souhaité
        /// </summary>
        /// <param name="etat">Etat des tournois à récupérer</param>
        /// <returns>Liste des tournois ayant l'état souhaité</returns>
        public static List<Tournoi> GetTournoisParEtat(Tournoi.EtatTournoi etat)
        {
            return DataBaseConnector.GetTournoisFiltres(etat);
        }

        /// <summary>
        /// Obtient la liste des tournois rejoignables
        /// </summary>
        /// <returns>Liste des tournois rejoignables</returns>
        public static List<Tournoi> GetTournoisRejoignables()
        {
            return DataBaseConnector.GetTournoisRejoignables();
        }

        /// <summary>
        /// Obtient la liste des tournois auxquels le joueur a participé en paramètre
        /// </summary>
        /// <param name="joueur">Joueur dont il faut récupérer les tournois</param>
        /// <returns>Liste des tournois auxquels le joueur a participé</returns>
        public static List<Tournoi> GetTournoisParticipes(Joueur joueur)
        {
            if (joueur == null) return new List<Tournoi>();
            return DataBaseConnector.GetTournoisParticipesParJoueur(joueur);
        }

        /// <summary>
        /// Ajoute le tournoi passé en paramètre dans la base de données
        /// </summary>
        /// <param name="t">Tournoi a ajouter dans la base de données</param>
        public static void Ajouter(Tournoi t)
        {
            DataBaseConnector.InsertionTournoi(t);
        }

        /// <summary>
        /// Supprime le tournoi passé en paramètre dans la base de données
        /// </summary>
        /// <param name="t">Tournoi a supprimer dans la base de données</param>
        public static void Supprimer(Tournoi t)
        {
            DataBaseConnector.SuppressionTournoi(t);
        }

        #endregion

        public override string ToString()
        {
            return nom;
        }


    }
}
