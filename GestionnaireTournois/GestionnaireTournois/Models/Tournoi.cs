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

        // Champs..
        private int id;

        private DateTime dateHeureDebut;

        private DateTime dateHeureFin;

        private string nom;

        private int nbEquipesMax;

        private int idPremierPrix;

        private int idDeuxiemePrix;

        // Propriétés..
        public int Id { get => id; set => id = value; }
        public DateTime DateHeureDebut { get => dateHeureDebut; set => dateHeureDebut = value; }
        public DateTime DateHeureFin { get => dateHeureFin; set => dateHeureFin = value; }
        public string Nom { get => nom; set => nom = value; }
        public int NbEquipesMax { get => nbEquipesMax; set => nbEquipesMax = value; }
        public int IdPremierPrix { get => idPremierPrix; set => idPremierPrix = value; }
        public int IdDeuxiemePrix { get => idDeuxiemePrix; set => idDeuxiemePrix = value; }

        // Constructeurs..
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

        // Méthodes..
        public int GetNbTours()
        {
            return DataBaseConnector.GetNbToursTournoi(this.Id);
        }

        public Equipe GetGagnant()
        {

            return DataBaseConnector.GetWinnerOfSerie(new Serie(1, Id, 1, null, null));
        }

        public List<Tour> GetTours()
        {
            return DataBaseConnector.GetTours(this);
        }

        public Tour GetTourByNo(int noTour)
        {
            return DataBaseConnector.GetTourByNo(this, noTour);
        }


        public void StartTournoi()
        {
            DataBaseConnector.StartTournoi(this);
        }

        public void ModifierTours(List<Tour> tours)
        {
            DataBaseConnector.ModifierToursTournoi(this, tours);
        }

        public void ModifierProprietes(string nom, DateTime dateDebut)
        {
            DataBaseConnector.ModifierProprietesTournoi(this, nom, dateDebut);
        }
        public override string ToString()
        {
            return nom;
        }

        public Prix GetPremierPrix()
        {
            return DataBaseConnector.GetPrixById(IdPremierPrix);
        }
        public Prix GetDeuxiemePrix()
        {
            return DataBaseConnector.GetPrixById(IdDeuxiemePrix);
        }

        public void AjouterPremierPrix(Prix prix)
        {
            if (IdPremierPrix != 0) return;
            DataBaseConnector.AjouterPremierPrix(this, prix);
            IdPremierPrix = prix.Id;
        }

        public void AjouterDeuxiemePrix(Prix prix)
        {
            if (IdDeuxiemePrix != 0) return;
            DataBaseConnector.AjouterDeuxiemePrix(this,prix);
            IdDeuxiemePrix = prix.Id;
        }


        public static Tournoi GetTournoiById(int idTournoi)
        {
            return DataBaseConnector.GetTournoiById(idTournoi);
        }

        public static List<Tournoi> GetTournoiParEtat(Tournoi.EtatTournoi etat)
        {
            return DataBaseConnector.GetTournoisFiltres(etat);
        }

        public static void Ajouter(Tournoi t)
        {
            DataBaseConnector.InsertionTournoi(t);
        }
        public static void Supprimer(Tournoi t)
        {
            DataBaseConnector.SuppressionTournoi(t);
        }

    }
}
