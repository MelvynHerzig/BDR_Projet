using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Tour
    {
        // Champs..

        private int no;
        private int longueurMaxSerie;
        private int idTournoi;


        // Propriétés..
        public int No { get => no; set => no = value; }
        public int LongueurMaxSerie { get => longueurMaxSerie; set => longueurMaxSerie = value; }
        public int IdTournoi { get => idTournoi; set => idTournoi = value; }

        // Constructeurs..
        public Tour(int no, int longueurMaxSerie, int idTournoi)
        {
            No = no;
            LongueurMaxSerie = longueurMaxSerie;
            IdTournoi = idTournoi;

        }

        public List<Serie> GetSerieOrderByIdASC()
        {
            return DataBaseConnector.GetSeries(IdTournoi, No);
        }

        public Serie GetSerieById(int idSerie)
        {
            return DataBaseConnector.GetSerieById(IdTournoi, No, idSerie);
        }
    }
}
