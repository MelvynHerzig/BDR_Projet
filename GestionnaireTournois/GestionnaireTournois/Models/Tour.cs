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
        private Tournoi tournoi;


        // Propriétés..
        public int No { get => no; set => no = value; }
        public int LongueurMaxSerie { get => longueurMaxSerie; set => longueurMaxSerie = value; }
        internal Tournoi Tournoi { get => tournoi; set => tournoi = value; }

        // Constructeurs..
        public Tour(int no, int longueurMaxSerie, Tournoi tournoi)
        {
            No = no;
            LongueurMaxSerie = longueurMaxSerie;
            Tournoi = tournoi;

        }

        public Serie GetSerieById(int id)
        {
            return new Serie(id, this);
        }
    }
}
