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
using System.Windows.Forms;
using System.Configuration;

namespace GestionnaireTournois
{
    class DataBaseConnector
    {//"server=localhost;database=gestionnairedetournoisrocketleague;uid=root;pwd=root;";
        private static string connection = String.Format("server={0};database={1};uid={2};pwd={3};",
                                                        ConfigurationManager.AppSettings["server"],
                                                        ConfigurationManager.AppSettings["database"],
                                                        ConfigurationManager.AppSettings["user"],
                                                        ConfigurationManager.AppSettings["password"]);

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
                cmd.CommandText = "SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax, idPrixPremier, idPrixSecond FROM tournoi " + condition + ";";

                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    DateTime fin = DateTime.MinValue;
                    int idPrixPremier = 0;
                    int idPrixDeuxieme = 0;

                    if (!rdr.IsDBNull(2))
                        fin = rdr.GetDateTime("dateHeureFin");
                    if (!rdr.IsDBNull(5))
                        idPrixPremier = rdr.GetInt32("idPrixPremier");
                    if (!rdr.IsDBNull(6))
                        idPrixPremier = rdr.GetInt32("idPrixSecond");

                    tournois.Add(new Tournoi(rdr.GetInt32("id"), rdr.GetDateTime("dateHeureDebut"), fin, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax"), idPrixPremier, idPrixDeuxieme));
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

        public static List<Tournoi> GetTournoisRejoignables()
        {
            List<Tournoi> tournois = new List<Tournoi>();

            MySqlConnection myConnection = new MySqlConnection(connection);


            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax, idPrixPremier, idPrixSecond FROM tournoi WHERE NOT estComplet(id) AND estEnAttente(id);";

                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    DateTime fin = DateTime.MinValue;
                    int idPrixPremier = 0;
                    int idPrixDeuxieme = 0;

                    if (!rdr.IsDBNull(2))
                        fin = rdr.GetDateTime("dateHeureFin");
                    if (!rdr.IsDBNull(5))
                        idPrixPremier = rdr.GetInt32("idPrixPremier");
                    if (!rdr.IsDBNull(6))
                        idPrixPremier = rdr.GetInt32("idPrixSecond");

                    tournois.Add(new Tournoi(rdr.GetInt32("id"), rdr.GetDateTime("dateHeureDebut"), fin, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax"), idPrixPremier, idPrixDeuxieme));
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

        public static List<Tournoi> GetTournoisParticipesParEquipe(Equipe equipe)
        {
            List<Tournoi> tournois = new List<Tournoi>();

            MySqlConnection myConnection = new MySqlConnection(connection);


            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax, idPrixPremier, idPrixSecond FROM tournoi JOIN tournoi_equipe ON tournoi_equipe.idTournoi = tournoi.id WHERE tournoi_equipe.acronymeEquipe = @acronyme;";

                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);

                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    DateTime fin = DateTime.MinValue;
                    int idPrixPremier = 0;
                    int idPrixDeuxieme = 0;

                    if (!rdr.IsDBNull(2))
                        fin = rdr.GetDateTime("dateHeureFin");
                    if (!rdr.IsDBNull(5))
                        idPrixPremier = rdr.GetInt32("idPrixPremier");
                    if (!rdr.IsDBNull(6))
                        idPrixPremier = rdr.GetInt32("idPrixSecond");

                    tournois.Add(new Tournoi(rdr.GetInt32("id"), rdr.GetDateTime("dateHeureDebut"), fin, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax"), idPrixPremier, idPrixDeuxieme));
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
                cmd.CommandText = "SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax, idPrixPremier, idPrixSecond FROM tournoi WHERE id = @idTournoi;";
                cmd.Parameters.AddWithValue("@idTournoi", idTournoi);

                cmd.Prepare();


                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime fin = DateTime.MinValue;

                    if (!rdr.IsDBNull(2))
                        fin = rdr.GetDateTime("dateHeureFin");

                    result = new Tournoi(idTournoi, rdr.GetDateTime("dateHeureDebut"), fin, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax"), rdr.GetInt32("idPrixPremier"), rdr.GetInt32("idPrixSecond"));
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

        public static int GetNbToursTournoi(Tournoi tournoi)
        {

            int nbTours = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM tour WHERE idTournoi = @idTournoi;";
                cmd.Parameters.AddWithValue("@idTournoi", tournoi.Id);

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
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return idTournoi;
        }

        public static void InscrireEquipeTournoi(Tournoi tournoi, Equipe equipe)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "INSERT INTO tournoi_equipe(idTournoi, acronymeEquipe, dateInscription) VALUES (@idTournoi, @acronyme, NOW());";

                cmd.Parameters.AddWithValue("idTournoi", tournoi.Id);
                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void ModifierProprietesTournoi(Tournoi t, string nouveauNom, DateTime nouveauDebut)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "UPDATE tournoi SET nom = @nom, dateHeureDebut = @dateDebut WHERE id = @idTournoi;";

                MySqlParameter nom = new MySqlParameter("@nom", MySqlDbType.VarChar, 50);
                MySqlParameter dateDebut = new MySqlParameter("@dateDebut", MySqlDbType.DateTime);
                MySqlParameter idTournoi = new MySqlParameter("idTournoi", MySqlDbType.Int32);

                nom.Value = nouveauNom;
                dateDebut.Value = nouveauDebut.ToString("yyyy-MM-dd HH:mm:ss");
                idTournoi.Value = t.Id;

                cmd.Parameters.Add(nom);
                cmd.Parameters.Add(dateDebut);
                cmd.Parameters.Add(idTournoi);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void SuppressionTournoi(Tournoi t)
        {

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "DELETE FROM tournoi WHERE id = @idTournoi";

                cmd.Parameters.AddWithValue("idTournoi", t.Id);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
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

        public static void ModifierToursTournoi(Tournoi tournoi, List<Tour> tours)
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

                myCommand.Parameters.AddWithValue("idTournoi", tours[0].IdTournoi);

                foreach (Tour t in tours)
                {
                    myCommand.CommandText = String.Format("UPDATE tour SET longueurMaxSerie = @longueurSerie{0} WHERE no = @noTour{1} AND idTournoi = @idTournoi;", t.No, t.No);

                    myCommand.Parameters.AddWithValue(String.Format("longueurSerie{0}", t.No), t.LongueurMaxSerie);
                    myCommand.Parameters.AddWithValue(String.Format("noTour{0}", t.No), t.No);

                    myCommand.Prepare();

                    myCommand.ExecuteNonQuery();

                }

                myTrans.Commit();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string e1 = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string e2 = reader.IsDBNull(2) ? null : reader.GetString(2); ;



                    s = new Serie(idSerie, t.IdTournoi, t.No, e1, e2);
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
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static Equipe GetEquipeJoueurDurantTournoi(Joueur joueur, Tournoi tournoi)
        {
            Equipe equipe = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT acronyme, nom, idResponsable FROM equipe WHERE acronyme = equipeDuJoueurLorsDu(@idJoueur, @dateDebutTournoi);";

                cmd.Parameters.AddWithValue("@dateDebutTournoi", tournoi.DateHeureDebut.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.Parameters.AddWithValue("@idJoueur", joueur.Id);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    equipe = new Equipe(reader.GetString("acronyme"), reader.GetString("nom"), reader.GetInt32("idResponsable"));
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

            return equipe;
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

        public static Equipe GetEquipeJoueur(Joueur joueur)
        {
            Equipe result = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT acronyme, nom, idResponsable FROM equipe WHERE acronyme = equipeDuJoueurLorsDu(@idJoueur, NOW())";
                cmd.Parameters.AddWithValue("@idJoueur", joueur.Id);

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

        public static void PostulerDansEquipe(Equipe equipe, Joueur joueur)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "INSERT INTO equipe_joueur(acronymeEquipe, idJoueur, dateHeureArrivee, dateHeureDepart) VALUES (@acronyme, @idJoueur, '0001-01-01 00:00:00', NULL);";
                
                cmd.Parameters.AddWithValue("@idJoueur", joueur.Id);
                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
                " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void SupprimerJoueurEquipe(Equipe equipe, Joueur joueur)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "UPDATE equipe_joueur SET dateHeureDepart = NOW() WHERE acronymeEquipe = @acronyme AND idJoueur = @idJoueur AND dateHeureDepart IS NULL;";

                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);
                cmd.Parameters.AddWithValue("idJoueur", joueur.Id);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<Equipe> GetAllEquipes()
        {
            List<Equipe> equipes = new List<Equipe>();


            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT acronyme, nom, idResponsable FROM equipe";

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    equipes.Add(new Equipe(reader.GetString("acronyme"), reader.GetString("nom"), reader.GetInt32("idResponsable")));
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

            return equipes;
        }



        #endregion

        #region Joueurs

        public static Joueur GetJoueurById(int idJoueur)
        {
            Joueur joueur = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT id, nom, prenom, email, pseudo, dateNaissance FROM joueur WHERE id = @idJoueur";

                cmd.Parameters.AddWithValue("idJoueur", idJoueur);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    joueur = new Joueur(idJoueur, reader.GetString("nom"), reader.GetString("prenom"), reader.GetString("email"), reader.GetString("pseudo"), reader.GetDateTime("dateNaissance"));

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

            return joueur;
        }

        public static Joueur GetJoueurByEmail(string email)
        {
            Joueur joueur = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT id, nom, prenom, email, pseudo, dateNaissance FROM joueur WHERE email = @email";

                cmd.Parameters.AddWithValue("email", email);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    joueur = new Joueur(reader.GetInt32("id"), reader.GetString("nom"), reader.GetString("prenom"), reader.GetString("email"), reader.GetString("pseudo"), reader.GetDateTime("dateNaissance"));

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

            return joueur;
        }

        public static List<Joueur> GetJoueursEquipeTournoi(Equipe equipe, Tournoi tournoi)
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

                cmd.Parameters.AddWithValue("@idTournoi", tournoi.Id);

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

        public static List<Joueur> GetJoueursEquipeActuels(Equipe equipe)
        {
            List<Joueur> joueurs = new List<Joueur>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT id, nom, prenom, email, pseudo, dateNaissance FROM joueur JOIN equipe_joueur ON equipe_joueur.idJoueur = joueur.id WHERE equipe_joueur.acronymeEquipe = @acronyme AND equipeDuJoueurLorsDu(joueur.id, NOW()) = @acronyme";

                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);

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

        public static List<Joueur> GetAnciensJoueursEquipe(Equipe equipe)
        {
            List<Joueur> joueurs = new List<Joueur>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT DISTINCT id, nom, prenom, email, pseudo, dateNaissance FROM joueur JOIN equipe_joueur ON equipe_joueur.idJoueur = joueur.id WHERE equipe_joueur.acronymeEquipe = @acronyme AND equipe_joueur.dateHeureDepart IS NOT NULL;";

                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);

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

        public static List<Joueur> GetJoueursEnAttenteEquipe(Equipe equipe)
        {
            List<Joueur> joueurs = new List<Joueur>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT DISTINCT id, nom, prenom, email, pseudo, dateNaissance FROM joueur JOIN equipe_joueur ON equipe_joueur.idJoueur = joueur.id WHERE equipe_joueur.acronymeEquipe = @acronyme AND equipe_joueur.dateHeureArrivee = '0001-01-01 00:00:00';";

                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);

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

        public static void AccepterJoueurDansEquipe(Equipe equipe, Joueur joueur)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "UPDATE equipe_joueur SET dateHeureArrivee = NOW() WHERE acronymeEquipe = @acronyme AND idJoueur = @idJoueur";

                cmd.Parameters.AddWithValue("idJoueur", joueur.Id);
                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static int AjouterJoueur(Joueur joueur)
        {
            int id = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "INSERT INTO joueur(nom, prenom, email, pseudo, dateNaissance) VALUES (@nom, @prenom, @email, @pseudo, @dateNaissance);";

                cmd.Parameters.AddWithValue("nom", joueur.Nom);
                cmd.Parameters.AddWithValue("prenom", joueur.Prenom);
                cmd.Parameters.AddWithValue("email", joueur.Email);
                cmd.Parameters.AddWithValue("pseudo", joueur.Pseudo);
                cmd.Parameters.AddWithValue("dateNaissance", joueur.DateNaissance);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                id = (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return id;
        }

        #endregion

        #region Prix

        public static Prix GetPrixById(int idPrix)
        {
            Prix prix = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT id, montantArgent FROM prix WHERE id = @idPrix ; ";

                cmd.Parameters.AddWithValue("@idPrix", idPrix);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    prix = new Prix(reader.GetInt32("id"), reader.GetInt32("montantArgent"));

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

            return prix;
        }

        public static List<Objet> GetObjetsPrix(Prix prix)
        {
            List<Objet> objets = new List<Objet>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT id, nom FROM objet JOIN prix_objet ON prix_objet.idObjet = objet.id WHERE prix_objet.idPrix = @idPrix;";

                cmd.Parameters.AddWithValue("@idPrix", prix.Id);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    objets.Add(new Objet(reader.GetInt32("id"), reader.GetString("nom")));

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

            return objets;
        }

        public static List<Objet> GetObjets()
        {
            List<Objet> objets = new List<Objet>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT id, nom FROM objet";


                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    objets.Add(new Objet(reader.GetInt32("id"), reader.GetString("nom")));

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

            return objets;
        }

        public static int CreerPrix(Prix prix)
        {
            int id = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "INSERT INTO prix(montantArgent) VALUES (@montantArgent);";

                MySqlParameter montantArgent = new MySqlParameter("@montantArgent", MySqlDbType.Decimal);

                montantArgent.Value = prix.MontantArgent;

                cmd.Parameters.Add(montantArgent);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                id = (int)cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return id;

        }

        public static void AjouterObjetsPrix(Prix prix, List<Objet> objets)
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
                foreach (Objet o in objets)
                {
                    myCommand.CommandText = String.Format("INSERT INTO prix_objet(idPrix, idObjet) VALUES (@idPrix{0}, @idObjet{1})", o.Id, o.Id);

                    myCommand.Parameters.AddWithValue(string.Format("idPrix{0}", o.Id), prix.Id);
                    myCommand.Parameters.AddWithValue(string.Format("idObjet{0}", o.Id), o.Id);

                    myCommand.ExecuteNonQuery();

                }


                myTrans.Commit();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void RetirerObjetsPrix(Prix prix, List<Objet> objets)
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
                foreach (Objet o in objets)
                {
                    myCommand.CommandText = String.Format("DELETE FROM prix_objet WHERE idPrix = @idPrix{0} AND idObjet = @idObjet{1};", o.Id, o.Id);

                    myCommand.Parameters.AddWithValue(string.Format("idPrix{0}", o.Id), prix.Id);
                    myCommand.Parameters.AddWithValue(string.Format("idObjet{0}", o.Id), o.Id);

                    myCommand.ExecuteNonQuery();

                }


                myTrans.Commit();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void AjouterObjet(Objet objet)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "INSERT INTO objet(nom) VALUES (@nom);";

                MySqlParameter nom = new MySqlParameter("@nom", MySqlDbType.VarChar, 100);

                nom.Value = objet.Nom;

                cmd.Parameters.Add(nom);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void ModifierMontantArgentPrix(Prix prix, double montant)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "UPDATE prix SET montantArgent = @montantArgent WHERE id = @idPrix";

                cmd.Parameters.AddWithValue("montantArgent", montant);
                cmd.Parameters.AddWithValue("idPrix", prix.Id);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void AjouterPremierPrix(Tournoi tournoi, Prix prix)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "UPDATE tournoi SET idPrixPremier = @idPrix WHERE id = @idTournoi";

                cmd.Parameters.AddWithValue("idPrix", prix.Id);
                cmd.Parameters.AddWithValue("idTournoi", tournoi.Id);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void AjouterDeuxiemePrix(Tournoi tournoi, Prix prix)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "UPDATE tournoi SET idPrixSecond = @idPrix WHERE id = @idTournoi";

                cmd.Parameters.AddWithValue("idPrix", prix.Id);
                cmd.Parameters.AddWithValue("idTournoi", tournoi.Id);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impossible d'effectuer votre requête", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("An exception of type " + e.Message +
               " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }
        }

        #endregion

        #region Statistiques
        public static List<int> GetNbEquipesParTournoi()
        {
            List<int> nbEquipes = new List<int>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT DISTINCT nbEquipesMax FROM tournoi ORDER BY nbEquipesMax; ";


                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    nbEquipes.Add(reader.GetInt32("nbEquipesMax"));

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

            return nbEquipes;
        }

        public static long GetVitesseInscriptionEnSecTournoiDe(int nbEquipes)
        {
            long vitesse = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT TIMESTAMPDIFF(SECOND, MIN(Tournoi_Equipe.dateInscription), MAX(Tournoi_Equipe.dateInscription)) AS ecart FROM Tournoi INNER JOIN Tournoi_Equipe ON Tournoi_Equipe.idTournoi = Tournoi.id WHERE Tournoi.nbEquipesMax = (SELECT COUNT(1) FROM Tournoi_Equipe WHERE Tournoi_Equipe.idTournoi = Tournoi.id) AND Tournoi.nbEquipesMax = @nbEquipesMax GROUP BY Tournoi.id; ";

                cmd.Parameters.AddWithValue("nbEquipesMax", nbEquipes);

                cmd.Prepare();

                vitesse = Convert.ToInt64(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return vitesse;
        }

        public static double GetMoyenneNbEquipesDesJoueurs()
        {
            double moyenne = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT AVG(Equipe_Par_Joueur.somme) FROM (SELECT COUNT(DISTINCT Equipe_joueur.acronymeEquipe) AS somme, Equipe_Joueur.idJoueur FROM Equipe_Joueur GROUP BY Equipe_Joueur.idJoueur)  AS Equipe_Par_Joueur";


                cmd.Prepare();

                moyenne = Convert.ToDouble(cmd.ExecuteScalar());

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return moyenne;
        }

        public static int[] GetStatsTotal(Joueur joueur)
        {
            int[] stats = new int[2];

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT SUM(nbButs) nbButsTot, SUM(nbArrets) nbArretsTot, COUNT(1) nbMatchsTot FROM match_joueur WHERE idJoueur = @idJoueur;";

                cmd.Parameters.AddWithValue("idJoueur", joueur.Id);

                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    stats[0] = rdr.GetInt32("nbButsTot");
                    stats[1] = rdr.GetInt32("nbArretsTot");
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

            return stats;
        }

        public static double[] GetMoyenneStats(Joueur joueur)
        {
            double[] moyenneStats = new double[2];

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT AVG(nbButs) moyenneButs, AVG(nbArrets) moyenneArrets FROM match_joueur WHERE idJoueur = @idJoueur";

                cmd.Parameters.AddWithValue("idJoueur", joueur.Id);

                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    moyenneStats[0] = rdr.GetDouble("moyenneButs");
                    moyenneStats[1] = rdr.GetDouble("moyenneArrets");
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

            return moyenneStats;
        }

        public static int GetNbSerieGagnee(Joueur joueur)
        {
            int nbSerie = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT COUNT(1) as nbVictoire FROM serie JOIN tournoi ON tournoi.id = serie.idTournoi WHERE vainqueurSerie(serie.id, serie.noTour, serie.idTournoi) = equipeDuJoueurLorsDu(@idJoueur, tournoi.dateHeureDebut)";

                cmd.Parameters.AddWithValue("idJoueur", joueur.Id);

                cmd.Prepare();

                nbSerie = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return nbSerie;
        }

        public static int GetNbSerieJouee(Joueur joueur)
        {
            int nbSerie = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();


            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT COUNT(DISTINCT idSerie, noTour, idTournoi) as nbMatch FROM match_joueur WHERE idJoueur = @idJoueur;";

                cmd.Parameters.AddWithValue("idJoueur", joueur.Id);

                cmd.Prepare();

                nbSerie = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.Message + " was encountered.");
            }
            finally
            {
                myConnection.Close();
            }

            return nbSerie;
        }

        #endregion

    }
}
