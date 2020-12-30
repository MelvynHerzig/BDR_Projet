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

        // Propriétés..
        public int Id { get => id; set => id = value; }
        internal Tour Tour { get => tour; set => tour = value; }

        // Constructeurs..
        public Serie(int id, Tour tour)
        {
            Id = id;
            Tour = tour;
        }

        public List<Equipe> GetEquipes()
        {
            return DataBaseConnector.GetEquipesFromSerie(Tour.Tournoi.Id, Tour.No, Id);
        }

        public Match GetMatchById(int id)
        {
            return new Match(id, this);
        }
    }
}
