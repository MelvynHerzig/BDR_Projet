using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionnaireTournois.Models;
using System.Data.SqlClient;
using System.Data;
using static GestionnaireTournois.Models.Tournoi;

namespace GestionnaireTournois
{
    class DataBaseConnector
    {
        private const string connection = "server=localhost;database=gestionnairedetournoisrocketleague;uid=root;pwd=root;";

        private void templateTransaction()
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand myCommand = myConnection.CreateCommand();
            MySqlTransaction myTrans;

            // Start a local transaction
            myTrans = myConnection.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = "insert into Test (id, desc) VALUES (100, 'Description')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "insert into Test (id, desc) VALUES (101, 'Description')";
                myCommand.ExecuteNonQuery();

                myTrans.Commit();

            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                        " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.Message +
                " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");

            }
            finally
            {
                myConnection.Close();
            }
        }

        #region Tournois

        public static List<Tournoi> GetTournoisFiltres(EtatTournoi etat)
        {
            List<Tournoi> tournois = new List<Tournoi>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            string condition = "";

            switch (etat)
            {

                case EtatTournoi.EN_ATTENTE:
                    condition = "WHERE Tournoi.dateHeureDebut > NOW() AND Tournoi.dateHeureFin IS NULL";
                    break;
                case EtatTournoi.EN_COURS:
                    condition = "WHERE Tournoi.dateHeureDebut <= NOW() AND Tournoi.dateHeureFin IS NULL AND Tournoi.nbEquipesMax = (SELECT COUNT(1) FROM Tournoi_Equipe WHERE Tournoi.id = Tournoi_Equipe.idTournoi)";
                    break;
                case EtatTournoi.TERMINES:
                    condition = "WHERE Tournoi.dateHeureDebut <= NOW() AND Tournoi.dateHeureFin IS NOT NULL AND Tournoi.dateHeureFin <> Tournoi.dateHeureDebut";
                    break;
                case EtatTournoi.ANNULES:
                    condition = "WHERE Tournoi.dateHeureDebut = Tournoi.dateHeureFin";
                    break;
            }


            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax FROM tournoi " + condition + ";";

                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    DateTime fin = DateTime.MinValue;

                    if (!rdr.IsDBNull(2))
                        fin = rdr.GetDateTime("dateHeureFin");

                    tournois.Add(new Tournoi(rdr.GetInt32("id"), rdr.GetDateTime("dateHeureDebut"), fin, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax")));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
                " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return tournois;
        }

        public static Tournoi GetTournoiById(int idTournoi)
        {
            Tournoi result = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax FROM tournoi WHERE id = @idTournoi;";
                cmd.Parameters.AddWithValue("@idTournoi", idTournoi);

                cmd.Prepare();


                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime fin = DateTime.MinValue;

                    if (!rdr.IsDBNull(2))
                        fin = rdr.GetDateTime("dateHeureFin");

                    result = new Tournoi(idTournoi, rdr.GetDateTime("dateHeureDebut"), fin, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
                " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return result;
        }

        public static int GetNbToursTournoi(int idTournoi)
        {

            int nbTours = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM tour WHERE idTournoi = @idTournoi;";
                cmd.Parameters.AddWithValue("@idTournoi", idTournoi);

                nbTours = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
                " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return nbTours;
        }

        public static int InsertionTournoi(Tournoi t)
        {
            int idTournoi = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "INSERT INTO tournoi(nom, dateHeureDebut, dateHeureFin, nbEquipesMax) VALUES (@nom, @dateDebut, @dateFin, @nbEquipes);";

                MySqlParameter nom = new MySqlParameter("@nom", MySqlDbType.VarChar, 50);
                MySqlParameter dateDebut = new MySqlParameter("@dateDebut", MySqlDbType.DateTime);
                MySqlParameter dateFin = new MySqlParameter("@dateFin", MySqlDbType.DateTime);
                MySqlParameter nbEquipes = new MySqlParameter("@nbEquipes", MySqlDbType.Int32);

                nom.Value = t.Nom;
                dateDebut.Value = t.DateHeureDebut.ToString("yyyy-MM-dd HH:mm:ss");
                dateFin.Value = null;
                nbEquipes.Value = t.NbEquipesMax;

                cmd.Parameters.Add(nom);
                cmd.Parameters.Add(dateDebut);
                cmd.Parameters.Add(dateFin);
                cmd.Parameters.Add(nbEquipes);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                idTournoi = (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return idTournoi;
        }

        public static bool SeedingEffectue(Tournoi t)
        {
            bool flag = false;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "seedingEffectue";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ireturnvalue", MySqlDbType.Int32);
                cmd.Parameters["@ireturnvalue"].Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.AddWithValue("pIdTournoi", t.Id);

                cmd.Prepare();

                cmd.ExecuteScalar();

                flag = Convert.ToBoolean(cmd.Parameters["@ireturnvalue"].Value);

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return flag;
        }

        public static void StartTournoi(Tournoi t)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "demarrerTournoi";
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("pIdTournoi", t.Id);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        #endregion

        #region Tours

        public static List<Tour> GetTours(Tournoi t)
        {
            List<Tour> tours = new List<Tour>();


            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT no, longueurMaxSerie FROM tour WHERE idTournoi = @idTournoi ORDER BY no ASC; ";

                cmd.Parameters.AddWithValue("@idTournoi", t.Id);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int noTour = reader.GetInt32("no");
                    int longueurMax = reader.GetInt32("longueurMaxSerie");

                    tours.Add(new Tour(noTour, longueurMax, t.Id));

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return tours;
        }

        public static Tour GetTourByNo(Tournoi t, int noTour)
        {
            Tour tour = null;


            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT no, longueurMaxSerie FROM tour WHERE idTournoi = @idTournoi AND no = @noTour ORDER BY no ASC; ";

                cmd.Parameters.AddWithValue("@idTournoi", t.Id);
                cmd.Parameters.AddWithValue("@noTour", noTour);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int longueurMax = reader.GetInt32("longueurMaxSerie");

                    tour = new Tour(noTour, longueurMax, t.Id);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return tour;
        }

        #endregion

        #region Series

        public static List<Serie> GetSeries(Tour tour)
        {
            List<Serie> series = new List<Serie>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT id, acronymeEquipe1, acronymeEquipe2 FROM serie WHERE noTour = @noTour AND idTournoi = @idTournoi ORDER BY id ASC;";

                cmd.Parameters.AddWithValue("@idTournoi", tour.IdTournoi);
                cmd.Parameters.AddWithValue("@noTour", tour.No);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    series.Add(new Serie(reader.GetInt32("id"), tour.IdTournoi, tour.No, reader.GetString("acronymeEquipe1"), reader.GetString("acronymeEquipe2")));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return series;
        }

        public static Serie GetSerieById(Tour t, int idSerie)
        {
            Serie s = null;


            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT id, acronymeEquipe1, acronymeEquipe2 FROM serie WHERE idTournoi = @idTournoi AND noTour = @noTour and id = @idSerie ORDER BY id ASC; ";

                cmd.Parameters.AddWithValue("@idTournoi", t.IdTournoi);
                cmd.Parameters.AddWithValue("@noTour", t.No);
                cmd.Parameters.AddWithValue("@idSerie", idSerie);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(1) || !reader.IsDBNull(2))
                        s = new Serie(idSerie, t.IdTournoi, t.No, reader.GetString("acronymeEquipe1"), reader.GetString("acronymeEquipe2"));
                    else
                        s = new Serie(idSerie, t.IdTournoi, t.No, null, null);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return s;
        }

        public static Equipe GetWinnerOfSerie(Serie s)
        {
            string winner = "";

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "vainqueurSerie";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ireturnvalue", MySqlDbType.VarChar);
                cmd.Parameters["@ireturnvalue"].Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.AddWithValue("pIdSerie", s.Id);
                cmd.Parameters.AddWithValue("pNoTour", s.NoTour);
                cmd.Parameters.AddWithValue("pIdTournoi", s.IdTournoi);

                cmd.Prepare();

                cmd.ExecuteScalar();

                winner = cmd.Parameters["@ireturnvalue"].Value.ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return GetEquipeByAcronyme(winner);
        }

        #endregion

        #region Matchs

        public static List<Match> GetMatchsFromSerie(Serie serie)
        {
            List<Match> matchs = new List<Match>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT id FROM `match` WHERE idSerie = @idSerie AND noTour = @noTour AND idTournoi = @idTournoi ORDER BY id ASC;";

                cmd.Parameters.AddWithValue("@idTournoi", serie.IdTournoi);
                cmd.Parameters.AddWithValue("@noTour", serie.NoTour);
                cmd.Parameters.AddWithValue("@idSerie", serie.Id);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    matchs.Add(new Match(reader.GetInt32("id"), serie.IdTournoi, serie.NoTour, serie.Id));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return matchs;
        }

        public static void AjouterMatch(List<JoueurMatchData> datas)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand myCommand = myConnection.CreateCommand();
            MySqlTransaction myTrans;

            // Start a local transaction
            myTrans = myConnection.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = "INSERT INTO `match`(id, idSerie, noTour, idTournoi) VALUES (@idMatch, @idSerie, @noTour, @idTournoi)";

                myCommand.Parameters.AddWithValue("idMatch", datas[0].IdMatch);
                myCommand.Parameters.AddWithValue("idSerie", datas[0].IdSerie);
                myCommand.Parameters.AddWithValue("noTour", datas[0].NoTour);
                myCommand.Parameters.AddWithValue("idTournoi", datas[0].IdTournoi);

                myCommand.ExecuteNonQuery();

                string insertMatchJoueur = "";
                foreach (JoueurMatchData data in datas)
                {
                    insertMatchJoueur += string.Format("({0},{1},{2},{3},{4},{5},{6}),", data.IdJoueur, data.NbButs, data.NbArrets, data.IdMatch, data.IdSerie, data.NoTour, data.IdTournoi);   
                }

                insertMatchJoueur = insertMatchJoueur.Substring(0, insertMatchJoueur.Length - 1) + ";";


                myCommand.CommandText = "INSERT INTO Match_Joueur (idJoueur, nbButs, nbArrets, idMatch, idSerie, noTour, idTournoi) VALUES " + insertMatchJoueur;

                myCommand.ExecuteNonQuery();

                myTrans.Commit();

            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                        " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.Message +
                " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void ModifierMatch(List<JoueurMatchData> datas)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                string insertMatchJoueur = "";
                foreach (JoueurMatchData data in datas)
                {
                    insertMatchJoueur += string.Format("({0},{1},{2},{3},{4},{5},{6}), ", data.IdJoueur, data.NbButs, data.NbArrets, data.IdMatch, data.IdSerie, data.NoTour, data.IdTournoi);
                }

                insertMatchJoueur = insertMatchJoueur.Substring(0, insertMatchJoueur.Length - 2);

                cmd.CommandText = "INSERT INTO Match_Joueur (idJoueur, nbButs, nbArrets, idMatch, idSerie, noTour, idTournoi) VALUES " + insertMatchJoueur + " ON DUPLICATE KEY UPDATE nbButs = VALUES(nbButs), nbArrets = VALUES(nbArrets);";

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static int[] GetDataJoueur(Match m, Joueur j)
        {
            int[] data = new int[2];

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT nbButs, nbArrets FROM match_joueur WHERE idJoueur = @idJoueur AND idMatch = @idMatch AND idSerie = @idSerie AND noTour = @noTour AND idTournoi = @idTournoi;";

                cmd.Parameters.AddWithValue("@idTournoi", m.IdTournoi);
                cmd.Parameters.AddWithValue("@noTour", m.NoTour);
                cmd.Parameters.AddWithValue("@idSerie", m.IdSerie);
                cmd.Parameters.AddWithValue("@idMatch", m.Id);

                cmd.Parameters.AddWithValue("@idJoueur", j.Id);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data[0] = reader.GetInt32("nbButs");
                    data[1] = reader.GetInt32("nbArrets");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }


            return data;
        }

        public static List<Joueur> GetJoueursEquipe(Equipe equipe, int idTournoi)
        {
            List<Joueur> joueurs = new List<Joueur>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT DISTINCT id,  nom, prenom, email, pseudo, dateNaissance " +
                                  "FROM joueur " +
                                  "JOIN equipe_joueur ON equipe_joueur.idJoueur = joueur.id " +
                                  "JOIN tournoi_equipe ON tournoi_equipe.acronymeEquipe = equipe_joueur.acronymeEquipe " +
                                  "WHERE tournoi_equipe.idTournoi = @idTournoi  AND equipeDuJoueurLorsDu(joueur.id, tournoi_equipe.dateInscription) = @acronyme;";

                cmd.Parameters.AddWithValue("@idTournoi", idTournoi);

                cmd.Parameters.AddWithValue("@acronyme", equipe.Acronyme);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    joueurs.Add(new Joueur(reader.GetInt32("id"), reader.GetString("nom"), reader.GetString("prenom"), reader.GetString("email"), reader.GetString("pseudo"), reader.GetDateTime("dateNaissance")));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return joueurs;
        }

        #endregion

        #region Equipes

        public static List<Equipe> GetEquipesFromSerie(Serie s)
        {

            List<Equipe> equipes = new List<Equipe>();

            List<string> acronymes = new List<string>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT acronymeEquipe1, acronymeEquipe2 FROM serie WHERE idTournoi = @idTournoi AND noTour = @noTour AND id = @idSerie;";

                cmd.Parameters.AddWithValue("@idSerie", s.Id);
                cmd.Parameters.AddWithValue("@noTour", s.NoTour);
                cmd.Parameters.AddWithValue("@idTournoi", s.IdTournoi);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string acronyme1 = reader.GetString("acronymeEquipe1");
                    string acronyme2 = reader.GetString("acronymeEquipe2");


                    acronymes.Add(acronyme1);
                    acronymes.Add(acronyme2);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            if (acronymes.Count > 0)
            {
                equipes.Add(GetEquipeByAcronyme(acronymes[0]));
                equipes.Add(GetEquipeByAcronyme(acronymes[1]));
            }
            return equipes;
        }

        public static Equipe GetEquipeByAcronyme(string acronyme)
        {

            Equipe result = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT acronyme, nom, idResponsable FROM equipe WHERE acronyme = @acronyme;";
                cmd.Parameters.AddWithValue("@acronyme", acronyme);

                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result = new Equipe(rdr.GetString("acronyme"), rdr.GetString("nom"), rdr.GetInt32("idResponsable"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
                " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return result;
        }

        #endregion

        #region Joueurs
        /*
        public static List<Joueur> GetJoueursDeEquipe(Equipe equipe)
        {
            List<Joueur> joueurs = new List<Joueur>();


            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT acronymeEquipe1, acronymeEquipe2 FROM serie WHERE idTournoi = @idTournoi AND noTour = @noTour AND id = @idSerie;";

                cmd.Parameters.AddWithValue("@idSerie", s.Id);
                cmd.Parameters.AddWithValue("@noTour", s.NoTour);
                cmd.Parameters.AddWithValue("@idTournoi", s.IdTournoi);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string acronyme1 = reader.GetString("acronymeEquipe1");
                    string acronyme2 = reader.GetString("acronymeEquipe2");


                    acronymes.Add(acronyme1);
                    acronymes.Add(acronyme2);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            if (acronymes.Count > 0)
            {
                equipes.Add(GetEquipeByAcronyme(acronymes[0]));
                equipes.Add(GetEquipeByAcronyme(acronymes[1]));
            }
            return equipes;
        }
        */
        #endregion
    }
}
