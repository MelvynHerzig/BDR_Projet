using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Equipe
    {

        // Champs..
        private string acronyme;

        private string nom;

        private int idResponsable;

        // Propriétés..
        public string Acronyme { get => acronyme; set => acronyme = value; }
        public string Nom { get => nom; set => nom = value; }
        public int IdResponsable { get => idResponsable; set => idResponsable = value; }

        // Constructeurs..
        public Equipe(string acronyme, string nom, int idResponsable)
        {
            Acronyme = acronyme;
            Nom = nom;
            IdResponsable = idResponsable;
        }

        public List<Joueur> GetJoueursFromTournoi(Tournoi tournoi)
        {
            return DataBaseConnector.GetJoueursEquipeTournoi(this, tournoi);
        }

        public List<Joueur> GetJoueursActuels()
        {
            return DataBaseConnector.GetJoueursEquipeActuels(this);
        }

        public List<Joueur> GetAnciensJoueurs()
        {
            return DataBaseConnector.GetAnciensJoueursEquipe(this);
        }

        public List<Joueur> GetJoueursEnAttente()
        {
            return DataBaseConnector.GetJoueursEnAttenteEquipe(this);
        }

        public void SupprimerJoueur(Joueur joueur)
        {
            DataBaseConnector.SupprimerJoueurEquipe(this, joueur);
        }

        public void AccepterJoueur(Joueur joueur)
        {
            DataBaseConnector.AccepterJoueurDansEquipe(this, joueur);
        }

        public void AbandonnerTournoi(Tournoi tournoi)
        {
            if (tournoi.EstEnAttente())
            {
                DataBaseConnector.DesinscrireEquipeTournoi(tournoi, this);
            }
            else
            {
                Serie derniereSerie = DataBaseConnector.GetDerniereSerieParticipeParEquipeTournoi(tournoi, this);

                if (DataBaseConnector.GetWinnerOfSerie(derniereSerie) == null)
                {
                    List<Equipe> equipes = derniereSerie.GetEquipes();

                    if (equipes.Count == 2)
                    {

                        List<Match> matches = derniereSerie.GetMatches();

                        int idDernierMatch = matches.Count == 0 ? 0 : matches[matches.Count - 1].Id;

                        while(DataBaseConnector.GetWinnerOfSerie(derniereSerie) == null)
                        {
                            DataBaseConnector.AjouterMatch(CreerMatchAbandon(equipes[0], equipes[1], tournoi, derniereSerie, ++idDernierMatch));
                        }
                    }

                }
            }
        }

        public override string ToString()
        {
            return Nom;
        }

        public static List<Equipe> GetEquipes()
        {
            return DataBaseConnector.GetAllEquipes();
        }

        public static void Ajouter(Equipe equipe)
        {
            DataBaseConnector.AjouterEquipe(equipe);
        }


        private List<JoueurMatchData> CreerMatchAbandon(Equipe e1, Equipe e2, Tournoi tournoi, Serie serie, int idMatch)
        {
            List<JoueurMatchData> datas = new List<JoueurMatchData>();

            Equipe perdant = e1.Acronyme == this.Acronyme ? e1 : e2;
            Equipe gagnant = e1.Acronyme == this.Acronyme ? e2 : e1;

            #region Perdant
            {
                List<Joueur> joueurs = perdant.GetJoueursFromTournoi(tournoi);

                JoueurMatchData j1 = new JoueurMatchData(joueurs[0].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "0", "0");

                JoueurMatchData j2 = new JoueurMatchData(joueurs[1].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "0", "0");

                JoueurMatchData j3 = new JoueurMatchData(joueurs[2].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "0", "0");

                datas.Add(j1);
                datas.Add(j2);
                datas.Add(j3);
            }
            #endregion

            #region Gagnant
            {
                List<Joueur> joueurs = gagnant.GetJoueursFromTournoi(tournoi);

                JoueurMatchData j1 = new JoueurMatchData(joueurs[0].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "1", "0");

                JoueurMatchData j2 = new JoueurMatchData(joueurs[1].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "1", "0");

                JoueurMatchData j3 = new JoueurMatchData(joueurs[2].Id, idMatch, serie.Id, serie.NoTour, serie.IdTournoi, "1", "0");

                datas.Add(j1);
                datas.Add(j2);
                datas.Add(j3);
            }
            #endregion

            return datas;
        }

    }
}
