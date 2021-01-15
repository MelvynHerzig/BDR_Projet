using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class JoueurMatchData
    {
        private int idJoueur;

        private int idMatch;
        private int idSerie;
        private int noTour;
        private int idTournoi;

        private int nbButs;
        private int nbArrets;

        public int IdJoueur { get => idJoueur; set => idJoueur = value; }
        public int IdMatch { get => idMatch; set => idMatch = value; }
        public int IdSerie { get => idSerie; set => idSerie = value; }
        public int NoTour { get => noTour; set => noTour = value; }
        public int IdTournoi { get => idTournoi; set => idTournoi = value; }
        public int NbButs { get => nbButs; set => nbButs = value; }
        public int NbArrets { get => nbArrets; set => nbArrets = value; }

        public JoueurMatchData(int idJoueur, int idMatch, int idSerie, int noTour, int idTournoi, string nbButs, string nbArrets)
        {
            IdJoueur = idJoueur;
            
            IdMatch = idMatch;
            IdSerie = idSerie;
            NoTour = noTour;
            IdTournoi = idTournoi;

            NbButs = nbButs == "" ? 0 : Convert.ToInt32(nbButs);
            NbArrets = nbArrets == "" ? 0 : Convert.ToInt32(nbArrets);
        }
    }
}
