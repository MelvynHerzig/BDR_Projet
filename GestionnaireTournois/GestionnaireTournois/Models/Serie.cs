using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Serie
    {
        // Champs..
        private int id;
        private Tour tour;
        private Equipe equipe1;
        private Equipe equipe2;

        // Propriétés..
        public int Id { get => id; set => id = value; }
        internal Tour Tour { get => tour; set => tour = value; }
        public Equipe Equipe1 { get => equipe1; set => equipe1 = value; }
        public Equipe Equipe2 { get => equipe2; set => equipe2 = value; }

        // Constructeurs..
        public Serie(int id, Tour tour, Equipe e1, Equipe e2)
        {
            Id = id;
            Tour = tour;
            Equipe1 = e1;
            Equipe2 = e2;
        }

        public List<Equipe> GetEquipes()
        {
            return new List<Equipe>() { Equipe1, Equipe2 };
        }

        public Match GetMatchById(int id)
        {
            return new Match(id, this);
        }
    }
}
