﻿/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Equipe.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Controller de la base de données.
               Contient tous les appels à la base de données.
               Chaque modèle appelle les fonctions présentes dans ce fichier

 Remarque(s) : /

 -------------------------------------------------------------------------------
 */
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using GestionnaireTournois.Models;
using System.Data.SqlClient;
using System.Data;
using static GestionnaireTournois.Models.Tournoi;
using System.Windows.Forms;
using System.Configuration;

namespace GestionnaireTournois
{
    class DataBaseConnector
    {
        /// <summary>
        /// Construit la chaine de connexion. Les différents paramètres sont modifiables depuis le fichier App.config
        /// </summary>
        private static string connection = String.Format("server={0};database={1};uid={2};pwd={3};",
                                                        ConfigurationManager.AppSettings["server"],
                                                        ConfigurationManager.AppSettings["database"],
                                                        ConfigurationManager.AppSettings["user"],
                                                        ConfigurationManager.AppSettings["password"]);

        /// <summary>
        /// Ouvre et ferme la connexion à la base de données
        /// </summary>
        public static void TestDBConnection()
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            myConnection.Close();
        }

        #region Requêtes de récupération de données

        #region Tournois

        /// <summary>
        /// Récupère dans la base de données la liste des tournois en fonction de l'état souhaité 
        /// </summary>
        /// <param name="etat">Filtre de l'état du tournoi</param>
        /// <returns>Liste des tournois étant dans l'état souhaité</returns>
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

        /// <summary>
        /// Obtient dans la base de données la liste des tournois rejoignables => tournois en attente et pas complet.
        /// </summary>
        /// <returns>Liste des tournois rejoignables</returns>
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

        /// <summary>
        /// Obtient dans la base de données la liste des tournois auxquels un joueur a participé
        /// </summary>
        /// <param name="joueur">Joueur souhaité</param>
        /// <returns>Liste des tournois auxquels le jour a participé</returns>
        public static List<Tournoi> GetTournoisParticipesParJoueur(Joueur joueur)
        {
            List<Tournoi> tournois = new List<Tournoi>();

            MySqlConnection myConnection = new MySqlConnection(connection);


            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT id, dateHeureDebut, dateHeureFin, nom, nbEquipesMax, idPrixPremier, idPrixSecond FROM tournoi JOIN tournoi_equipe ON tournoi_equipe.idTournoi = tournoi.id WHERE tournoi_equipe.acronymeEquipe = equipeDuJoueurLorsDu(@idJoueur, tournoi.dateHeureDebut);";

                cmd.Parameters.AddWithValue("idJoueur", joueur.Id);

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

        /// <summary>
        /// Récupère dans la base le tournoi ayant l'id passé en paramètre
        /// </summary>
        /// <param name="idTournoi">id du tournoi a retourné</param>
        /// <returns>Tournoi ayant l'id passé en paramètre</returns>
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
                    int idPrixPremier = 0;
                    int idPrixDeuxieme = 0;

                    if (!rdr.IsDBNull(2))
                        fin = rdr.GetDateTime("dateHeureFin");
                    if (!rdr.IsDBNull(5))
                        idPrixPremier = rdr.GetInt32("idPrixPremier");
                    if (!rdr.IsDBNull(6))
                        idPrixPremier = rdr.GetInt32("idPrixSecond");

                    result = new Tournoi(idTournoi, rdr.GetDateTime("dateHeureDebut"), fin, rdr.GetString("nom"), rdr.GetInt32("nbEquipesMax"), idPrixPremier, idPrixDeuxieme);
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

        /// <summary>
        /// Détermine si le tournoi est en attente
        /// </summary>
        /// <param name="t">Tournoi a vérifié</param>
        /// <returns>true -> le tournoi est en attente</returns>
        public static bool IsTournoiEnAttente(Tournoi t)
        {
            bool enAttente = false;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT COUNT(id) FROM tournoi WHERE id = @idTournoi AND estEnAttente(@idTournoi)";


                cmd.Parameters.AddWithValue("idTournoi", t.Id);

                cmd.Prepare();

                enAttente = Convert.ToBoolean(cmd.ExecuteScalar());

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

            return enAttente;
        }

        #endregion

        #region Tours

        /// <summary>
        /// Récupère les tours du tournoi, passé en paramètre, dans la base de donneés
        /// </summary>
        /// <param name="t">Tournoi souhaité</param>
        /// <returns>Liste des tours du tournoi</returns>
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

        /// <summary>
        /// Obtient le tour correspondant au numéro en paramètre, du tournoi en paramètre
        /// </summary>
        /// <param name="t">Tournoi souhaité</param>
        /// <param name="noTour">Numéro du tour souhaité</param>
        /// <returns>Tour no souhaité du tournoi souhaité</returns>
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

        /// <summary>
        /// Obtient le nombre de tour du tournoi passé en paramètre
        /// </summary>
        /// <param name="tournoi">Tournoi souhaité</param>
        /// <returns>Nombre de tours du tournoi</returns>
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

        #endregion

        #region Series

        /// <summary>
        /// Récupère la série souhaité dans la base de données, pour le tour donné
        /// </summary>
        /// <param name="t">Tour souhaité</param>
        /// <param name="idSerie">Id de la série souhaitée</param>
        /// <returns>Serie correpondante à l'id en paramètre du tour donné</returns>
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

        /// <summary>
        /// Obtient la dernière série joué par une équipe lors d'un tournoi
        /// </summary>
        /// <param name="tournoi">Tournoi souhaité</param>
        /// <param name="equipe">Equipe souhaitée</param>
        /// <returns>La dernière série dans laquelle l'équipe en paramètre à jouer</returns>
        public static Serie GetDerniereSerieParticipeParEquipeTournoi(Tournoi tournoi, Equipe equipe)
        {
            Serie s = null;


            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT Serie.id as id, Serie.noTour as noTour, Serie.idTournoi as idTournoi, Serie.acronymeEquipe1, Serie.acronymeEquipe2, MIN(Serie.noTour) FROM Serie WHERE Serie.idTournoi = @idTournoi AND (Serie.acronymeEquipe1 = @acronyme OR Serie.acronymeEquipe2 = @acronyme); ";

                cmd.Parameters.AddWithValue("@idTournoi", tournoi.Id);
                cmd.Parameters.AddWithValue("@acronyme", equipe.Acronyme);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string e1 = reader.IsDBNull(3) ? null : reader.GetString(3);
                    string e2 = reader.IsDBNull(4) ? null : reader.GetString(4); ;



                    s = new Serie(reader.GetInt32("id"), reader.GetInt32("idTournoi"), reader.GetInt32("noTour"), e1, e2);
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

        #endregion

        #region Matches

        /// <summary>
        /// Obtient la liste des matchs de la série donnée
        /// </summary>
        /// <param name="serie">Série donnée</param>
        /// <returns>Liste des matches de la série</returns>
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

        #endregion

        #region Equipes

        /// <summary>
        /// Obtient la liste des équipes inscrites à un tournoi
        /// </summary>
        /// <param name="tournoi">tournoi donné</param>
        /// <returns>Liste des équipes du tournoi donné</returns>
        public static List<Equipe> GetEquipesInscritesTournoi(Tournoi tournoi)
        {
            List<Equipe> equipes = new List<Equipe>();


            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT acronyme, nom, idResponsable FROM equipe JOIN tournoi_equipe ON tournoi_equipe.acronymeEquipe = equipe.acronyme WHERE tournoi_equipe.idTournoi = @idTournoi";

                cmd.Parameters.AddWithValue("idTournoi", tournoi.Id);

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

        /// <summary>
        /// Obtient l'équipe gagnante de la série
        /// </summary>
        /// <param name="s">Série ou déterminer le gagnant</param>
        /// <returns>Equipe gagnante de la série</returns>
        public static Equipe GetGagnantSerie(Serie s)
        {
            Equipe equipe = null;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT acronyme, nom, idResponsable FROM equipe WHERE acronyme = vainqueurSerie(@idSerie, @noTour, @idTournoi, false);";

                cmd.Parameters.AddWithValue("idSerie", s.Id);
                cmd.Parameters.AddWithValue("noTour", s.NoTour);
                cmd.Parameters.AddWithValue("idTournoi", s.IdTournoi);

                cmd.Prepare();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    equipe = new Equipe(reader.GetString("acronyme"), reader.GetString("nom"), reader.GetInt32("idResponsable"));
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

            return equipe;
        }

        /// <summary>
        /// Obtient l'équipe du joueur en paramètre lors du tournoi passé en paramètre
        /// </summary>
        /// <param name="joueur">Joueur donné</param>
        /// <param name="tournoi">Tournoi donné</param>
        /// <returns>Equipe du joueur donnée lors du tournoi donné</returns>
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

        /// <summary>
        /// Obtient l'équipe ayant pour acronyme, l'acronyme passé en paramètre
        /// </summary>
        /// <param name="acronyme">Acronyme de l'équipe recherchée</param>
        /// <returns>Equipe ayant l'acronyme donné</returns>
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

        /// <summary>
        /// Obtient l'équipe actuelle du joueur
        /// </summary>
        /// <param name="joueur">Joueur donné</param>
        /// <returns>Equipe actuelle du joueur donné</returns>
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

        /// <summary>
        /// Obtient toutes les équipes existantes dans la base de données
        /// </summary>
        /// <returns>Liste contenant toutes les équipes</returns>
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

        /// <summary>
        /// Obtient le joueur ayant l'email passée en paramètre
        /// </summary>
        /// <param name="email">Email du joueur a recherché</param>
        /// <returns>Joueur ayant l'email donnée</returns>
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

        /// <summary>
        /// Obtient les joueurs de l'équipe passée en paramètre lors du tournoi souhaité
        /// </summary>
        /// <param name="equipe">Equipe donnée</param>
        /// <param name="tournoi">Tournoi souhaité</param>
        /// <returns>Liste des joueurs de l'équipe donnée lors du tournoi donné</returns>
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

        /// <summary>
        /// Obtient les joueurs actuels de l'équipe passée en paramètre
        /// </summary>
        /// <param name="equipe">Equipe donnée</param>
        /// <returns>Liste des joueurs actuels de l'équipe donnée</returns>
        public static List<Joueur> GetJoueursEquipeActuels(Equipe equipe)
        {
            List<Joueur> joueurs = new List<Joueur>();

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT DISTINCT id, nom, prenom, email, pseudo, dateNaissance FROM joueur JOIN equipe_joueur ON equipe_joueur.idJoueur = joueur.id WHERE equipe_joueur.acronymeEquipe = @acronyme AND equipeDuJoueurLorsDu(joueur.id, NOW()) = @acronyme";

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

        /// <summary>
        /// Obtient la liste de tous joueurs qui ont fait partis de l'équipe dans le passé
        /// Un joueur étant parti et revenu sera dans la liste
        /// </summary>
        /// <param name="equipe">Equipe donnée</param>
        /// <returns>Liste des anciens joueurs de l'équipe donnée</returns>
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

        /// <summary>
        /// Obtient les joueurs en attente d'acceptation pour l'équipe en paramètre
        /// </summary>
        /// <param name="equipe">Equipe donnée</param>
        /// <returns>Liste des joueurs en attente de l'équipe donnée</returns>
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

        #endregion

        #region Prix

        /// <summary>
        /// Obtient le prix selon l'id passé en paramètre
        /// </summary>
        /// <param name="idPrix">Id du prix a recherché</param>
        /// <returns>Prix ayant l'id donné</returns>
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

        /// <summary>
        /// Obtient la liste des objets associés au prix en paramètre
        /// </summary>
        /// <param name="prix">Prix donné</param>
        /// <returns>Liste des objets du prix donné</returns>
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

        /// <summary>
        /// Obtient la liste de tous les objets présents dans la base de données
        /// </summary>
        /// <returns>Liste des objets dans la base de données</returns>
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

        #endregion

        #region Statistiques et autres données

        /// <summary>
        /// Obtient le nombre de buts/arrêts pour le joueur donné lors du match donné
        /// </summary>
        /// <param name="m">Match donné</param>
        /// <param name="j">Joueur donné</param>
        /// <returns>tableau de int contenant les buts/arrêts du joueur donné pour le match donné</returns>
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

        /// <summary>
        /// Obtient distinctement le nombre d'équipes par tournoi
        /// </summary>
        /// <returns>Liste contenant les différents nombre d'équipes des tournois</returns>
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

        /// <summary>
        /// Obtient la moyenne de la vitesse d'inscriptions (en secondes) des tournois du nombre d'équipes donné
        /// </summary>
        /// <param name="nbEquipes">Nombre d'équipes du tournoi</param>
        /// <returns>Moyenne de la vitesse d'inscriptions en secondes des tournois du nombre d'équipes donné</returns>
        public static long GetVitesseInscriptionEnSecTournoiDe(int nbEquipes)
        {
            long vitesse = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT AVG(ecart.temps) FROM (SELECT TIMESTAMPDIFF(SECOND, MIN(Tournoi_Equipe.dateInscription), MAX(Tournoi_Equipe.dateInscription)) AS temps FROM Tournoi INNER JOIN Tournoi_Equipe ON Tournoi_Equipe.idTournoi = Tournoi.id WHERE Tournoi.nbEquipesMax = (SELECT COUNT(1) FROM Tournoi_Equipe WHERE Tournoi_Equipe.idTournoi = Tournoi.id) AND Tournoi.nbEquipesMax = @nbEquipesMax GROUP BY Tournoi.id) as ecart; ";

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

        /// <summary>
        /// Obtient la moyenne du nombre d'équipes pour chaque joueur
        /// </summary>
        /// <returns>Moyenne du nombre d'équipes par joueur</returns>
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

        /// <summary>
        /// Obtient les statistiques (nombre de buts/arrêts) totales pour le joueur donné
        /// </summary>
        /// <param name="joueur">Joueur donné</param>
        /// <returns>Tableau de int contenant les nombres de buts/arrêts totals</returns>
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

        /// <summary>
        /// Obtient la moyenne des statistiques (nombre de buts/arrêts) totales pour le joueur donné
        /// </summary>
        /// <param name="joueur">Joueur donné</param>
        /// <returns>Tableau de int contenant les moyenne des nombres de buts/arrêts totals</returns>
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

        /// <summary>
        /// Obtient le nombre de série que le joueur a gagné
        /// </summary>
        /// <param name="joueur">Joueur donné</param>
        /// <returns>Le nombre de série gagné du joueur donné</returns>
        public static int GetNbSerieGagnee(Joueur joueur)
        {
            int nbSerie = 0;

            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "SELECT COUNT(1) as nbVictoire FROM serie JOIN tournoi ON tournoi.id = serie.idTournoi WHERE vainqueurSerie(serie.id, serie.noTour, serie.idTournoi, FALSE) = equipeDuJoueurLorsDu(@idJoueur, tournoi.dateHeureDebut)";

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

        /// <summary>
        /// Obtient le nombre de série que le joueur a joué
        /// </summary>
        /// <param name="joueur">Joueur donné</param>
        /// <returns>Le nombre de série joué par le joueur</returns>
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

        #endregion

        #region Requêtes d'insertion de données

        /// <summary>
        /// Ajoute le tournoi en paramètre dans la base de données
        /// </summary>
        /// <param name="t">Tournoi a ajouter dans la base de données</param>
        /// <returns>Rend l'id du tournoi inséré</returns>
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

        /// <summary>
        /// Inscrit l'équipe a un tournoi
        /// Ajoute une entrée dans la table tournoi_equipe
        /// </summary>
        /// <param name="tournoi">Tournoi souhaité</param>
        /// <param name="equipe">Equipe a inscrire</param>
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

        /// <summary>
        /// Fait postuler le joueur donné dans l'équipe
        /// Ajoute une entrée dans la table equipe_joueur
        /// </summary>
        /// <param name="equipe">Equipe souhaité</param>
        /// <param name="joueur">Joueur a inscrire</param>
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

        /// <summary>
        /// Ajoute le match ainsi que toutes les données du match dans la base de données
        /// </summary>
        /// <param name="datas">Liste de toutes les données du match par joueur</param>
        public static void AjouterMatch(List<JoueurMatchData> datas)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand myCommand = myConnection.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = myConnection.BeginTransaction();
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

        /// <summary>
        /// Ajoute l'équipe en paramètre dans la base de données
        /// </summary>
        /// <param name="equipe">Equipe a ajouter dans la base de données</param>
        public static void AjouterEquipe(Equipe equipe)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "INSERT INTO equipe(acronyme, nom, idResponsable) VALUES (@acronyme, @nom, @idResponsable);";

                cmd.Parameters.AddWithValue("nom", equipe.Nom);
                cmd.Parameters.AddWithValue("acronyme", equipe.Acronyme);
                cmd.Parameters.AddWithValue("idResponsable", equipe.IdResponsable);

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

        /// <summary>
        /// Ajoute le joueur en paramètre dans la base de données
        /// </summary>
        /// <param name="joueur">Joueur a ajouter dans la base de données</param>
        /// <returns>Id du joueur inséré</returns>
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

        /// <summary>
        /// Créer le prix en paramètre dans la base de données
        /// </summary>
        /// <param name="prix">Prix a ajouter dans la base de données</param>
        /// <returns>Id du prix inséré</returns>
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

        /// <summary>
        /// Ajoute les objets de la liste au prix donné
        /// Ajoute des entrées dans la table prix_objets
        /// </summary>
        /// <param name="prix">Prix ou ajouter les objets</param>
        /// <param name="objets">Liste des objets a ajouter</param>
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

        /// <summary>
        /// Ajoute l'objet en paramètre dans la base de données
        /// </summary>
        /// <param name="objet"></param>
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

        #endregion

        #region Requêtes de modification de données

        /// <summary>
        /// Utilise la procédure dans la base de données qui démarre le tournoi
        /// Cela effectue le seeding du premier tour
        /// </summary>
        /// <param name="t">Tournoi a démarrer</param>
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

        /// <summary>
        /// Modifie les données du tournoi en paramètre
        /// </summary>
        /// <param name="t">Tournoi a modifier</param>
        /// <param name="nouveauNom">nouveau nom du tournoi</param>
        /// <param name="nouveauDebut">nouvelle date de début du tournoi</param>
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

        /// <summary>
        /// Modifie les informations des tours d'un tournoi
        /// </summary>
        /// <param name="tournoi">Tournoi ou il faut modifier les tours</param>
        /// <param name="tours">Liste des tours modifiés</param>
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

        /// <summary>
        /// Modifie le match en paramètre avec les nouvelles données passées
        /// </summary>
        /// <param name="datas">Nouvelles données du match</param>
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

        /// <summary>
        /// Accepte le joueur dans l'équipe
        /// Met a jour la date d'arrivée du joueur dans equipe_joueur
        /// </summary>
        /// <param name="equipe">Equipe qui accepte le joueur</param>
        /// <param name="joueur">Joueur a accepté</param>
        public static void AccepterJoueurDansEquipe(Equipe equipe, Joueur joueur)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "accepterJoueur";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pAcronymeEquipe", equipe.Acronyme);
                cmd.Parameters.AddWithValue("pIdJoueur", joueur.Id);

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

        /// <summary>
        /// Modifie le montant d'argent du prix en paramètre
        /// </summary>
        /// <param name="prix">Prix a modifier</param>
        /// <param name="montant">Nouveau montant d'argent</param>
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

        /// <summary>
        /// Ajoute l'id du premier prix du tournoi donné
        /// </summary>
        /// <param name="tournoi">Tournoi a mettre à jour</param>
        /// <param name="prix">Prix a ajouter au tournoi</param>
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

        /// <summary>
        /// Ajoute l'id du deuxième prix du tournoi donné
        /// </summary>
        /// <param name="tournoi">Tournoi a mettre à jour</param>
        /// <param name="prix">Prix a ajouter au tournoi</param>
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

        #region Requêtes de suppression de données

        /// <summary>
        /// Supprime le tournoi passé en paramètre de la base de données
        /// </summary>
        /// <param name="t">Tournoi a supprimer</param>
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

        /// <summary>
        /// Désinscrit l'équipe donnée du tournoi en paramètre
        /// Supprime l'entrée dans la table tournoi_equipe
        /// </summary>
        /// <param name="tournoi">Tournoi ou il faut se désinscrire</param>
        /// <param name="equipe">Equipe a désinscrire</param>
        public static void DesinscrireEquipeTournoi(Tournoi tournoi, Equipe equipe)
        {
            MySqlConnection myConnection = new MySqlConnection(connection);

            myConnection.Open();

            MySqlCommand cmd = myConnection.CreateCommand();

            try
            {

                cmd.CommandText = "DELETE FROM tournoi_equipe WHERE idTournoi = @idTournoi AND acronymeEquipe = @acronyme";

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

        /// <summary>
        /// Retire le joueur de l'équipe
        /// Met a jour la date de départ du joueur dans la table equipe_joueur
        /// </summary>
        /// <param name="equipe">Equipe ou il faut désinscrire le joueur</param>
        /// <param name="joueur">Joueur a retirer de l'équipe</param>
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

        /// <summary>
        /// Retire les objets du prix en paramètre
        /// Retire les entrées dans la table prix_objet
        /// </summary>
        /// <param name="prix">Prix ou il faut supprimer les objets</param>
        /// <param name="objets">Liste des objets a supprimer</param>
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

        #endregion

    }
}
