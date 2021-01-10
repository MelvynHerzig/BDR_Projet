using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Match
    {
        // Champs..
        private int id;

        private int idSerie;

        private int noTour;

        private int idTournoi;

        // Propriétés..
        public int Id { get => id; set => id = value; }
        internal int IdSerie { get => idSerie; set => idSerie = value; }
        public int NoTour { get => noTour; set => noTour = value; }
        public int IdTournoi { get => idTournoi; set => idTournoi = value; }

        // Constructeurs..

        public Match(int id, int idTournoi, int noTour, int idSerie)
        {
            Id = id;
            IdSerie = idSerie;
            NoTour = noTour;
            IdTournoi = idTournoi;
        }

        public override string ToString()
        {
            return "Match " + Id;
        }
    }
}
