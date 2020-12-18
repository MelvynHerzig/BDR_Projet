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

        private Serie serie;

        // Propriétés..
        public int Id { get => id; set => id = value; }
        internal Serie Serie { get => serie; set => serie = value; }

        // Constructeurs..

        public Match(int id, Serie serie)
        {
            Id = id;
            Serie = serie;
        }
    }
}
