using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionnaireTournois.Models;

namespace GestionnaireTournois
{
    class DataBaseConnector
    {
        private static string connection = "server=localhost;database=gestionnairedetournoisrocketleague;uid=root;pwd=root;";

        private static MySqlConnection db;

        private static void OpenConnection()
        {
            db = new MySqlConnection(connection);
            db.Open();
        }

        private static void CloseConnection()
        {
            db.Close();
        }

        #region Tournois

        public static List<Tournoi> GetTournois()
        {
            List<Tournoi> tournois = new List<Tournoi>();
            
            OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax FROM tournoi;", DataBaseConnector.db);

            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                tournois.Add(new Tournoi(rdr.GetInt32("id"), DateTime.Now, DateTime.Now, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax")));
            }


            CloseConnection();

            return tournois;
        }

        public static Tournoi GetTournoiById(int idTournoi)
        {
            Tournoi result = null;

            OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax FROM tournoi WHERE id = " + idTournoi + ";", DataBaseConnector.db);

            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                result = new Tournoi(idTournoi, DateTime.Now, DateTime.Now, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax"));
            }

            CloseConnection();

            return result;
        }

        public static int GetNbToursTournoi(int idTournoi)
        {

            int nbTours = 0;
            
            OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tour WHERE idTournoi = " + idTournoi + ";", DataBaseConnector.db);

            nbTours = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            CloseConnection();

            return nbTours;
        }
       

        #endregion

        #region Tours

        public static List<Tour> GetTours(int idTournoi)
        {
            Tournoi t = GetTournoiById(idTournoi);
            List<Tour> tours = new List<Tour>();

            OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT no, longueurMaxSerie FROM tour WHERE idTournoi = " + idTournoi + " ORDER BY no ASC;", DataBaseConnector.db);

            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                int noTour = reader.GetInt32("no");
                int longueurMax = reader.GetInt32("longueurMaxSerie");

                tours.Add(new Tour(noTour, longueurMax, t));

            }

            CloseConnection();

            return tours;
        }

        #endregion

        #region Series

        public static List<Serie> GetSeries(int idTournoi, int noTour)
        {
            Tournoi tournoi = GetTournoiById(idTournoi);
            Tour tour = GetTours(idTournoi)[noTour - 1];

            List<Serie> series = new List<Serie>();

            OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT id FROM serie WHERE noTour = " + tour.No + " AND idTournoi = " + idTournoi + " ORDER BY id ASC;", DataBaseConnector.db);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int idSerie = reader.GetInt32("id");

                series.Add(new Serie(idSerie, tour));
            }

            CloseConnection();

            return series;
        }

        public static Equipe GetWinnerOfSerie(int idTournoi, int noTour, int idSerie)
        {
            Equipe winner = null;

            OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tour WHERE idTournoi = " + idTournoi + ";", DataBaseConnector.db);

            //nbTours = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            CloseConnection();

            return winner;
        }

        #endregion

        #region Equipes

        public static List<Equipe> GetEquipesFromSerie(int idTournoi, int noTour, int idSerie)
        {
            Tournoi tournoi = GetTournoiById(idTournoi);
            Tour tour = GetTours(idTournoi)[noTour - 1];

            List<Equipe> equipes = new List<Equipe>();

            OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT equipe.acronyme, equipe.nom, equipe.idResponsable FROM equipe JOIN serie_equipe se ON equipe.acronyme = se.acronymeEquipe WHERE se.idSerie = " + idSerie + " AND se.noTour = " + tour.No + " AND se.idTournoi = " + idTournoi + " ORDER BY equipe.acronyme DESC;", DataBaseConnector.db);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string acronyme = reader.GetString("acronyme");
                string nom = reader.GetString("nom");
                int idresp = reader.GetInt32("idResponsable");



                equipes.Add(new Equipe(acronyme, nom, null));
            }

            CloseConnection();

            return equipes;
        }

        #endregion
    }
}
