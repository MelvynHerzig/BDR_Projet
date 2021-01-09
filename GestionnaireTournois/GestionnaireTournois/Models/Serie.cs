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
        private int idTournoi;
        private int noTour;
        private string equipe1;
        private string equipe2;

        // Propriétés..
        public int Id { get => id; set => id = value; }
        public int IdTournoi { get => idTournoi; set => idTournoi = value; }
        public int NoTour { get => noTour; set => noTour = value; }
        public string Equipe1 { get => equipe1; set => equipe1 = value; }
        public string Equipe2 { get => equipe2; set => equipe2 = value; }

        // Constructeurs..
        public Serie(int id, int idTournoi, int noTour, string e1, string e2)
        {
            Id = id;
            NoTour = noTour;
            IdTournoi = idTournoi;
            Equipe1 = e1;
            Equipe2 = e2;
        }

   

        public List<Equipe> GetEquipes()
        {
            Equipe e1 = Equipe1 == null ? null : DataBaseConnector.GetEquipeByAcronyme(Equipe1);
            Equipe e2 = Equipe2 == null ? null : DataBaseConnector.GetEquipeByAcronyme(Equipe2);
            return new List<Equipe>() { e1, e2 };
        }

        public Match GetMatchById(int id)
        {
            return new Match(id, IdTournoi, NoTour, Id);
        }

        public List<Match> GetMatches()
        {
            return DataBaseConnector.GetMatchsFromSerie(this);
        }

        public void AjouterMatch()
        {
            DataBaseConnector.AjouterMatch(this);
        }
    }
}
