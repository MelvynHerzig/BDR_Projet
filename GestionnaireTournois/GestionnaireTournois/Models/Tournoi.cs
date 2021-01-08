using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Tournoi
    {
        // Champs..
        private int id;
        
        private DateTime dateHeureDebut;

        private DateTime dateHeureFin;

        private string nom;

        private int nbEquipesMax;


        // Propriétés..
        public int Id { get => id; set => id = value; }
        public DateTime DateHeureDebut { get => dateHeureDebut; set => dateHeureDebut = value; }
        public DateTime DateHeureFin { get => dateHeureFin; set => dateHeureFin = value; }
        public string Nom { get => nom; set => nom = value; }
        public int NbEquipesMax { get => nbEquipesMax; set => nbEquipesMax = value; }

        // Constructeurs..
        public Tournoi(int id, DateTime debut, DateTime fin, string nom, int nbEquipesMax)
        {
            Id = id;
            DateHeureDebut = debut;
            DateHeureFin = fin;
            Nom = nom;
            NbEquipesMax = nbEquipesMax;

        }

        // Méthodes..
        public int GetNbTours()
        {
            return DataBaseConnector.GetNbToursTournoi(this.Id);
        }

        public Equipe GetGagnant()
        {
            return DataBaseConnector.GetWinnerOfSerie(Id, 1, 1);
        }

        public List<Tour> GetTours()
        {
            return DataBaseConnector.GetTours(Id);
        }

        public Tour GetTourByNo(int noTour)
        {
            return DataBaseConnector.GetTourByNo(Id, noTour);
        }
        
        public override string ToString()
        {
            return nom;
        }
    }
}
