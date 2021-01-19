/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmAdmin.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Formulaire principal de la partie administrateur qui
                gère les tournois sur tous ces aspects et affiche ces statistiques

 Remarque(s) : /

 -------------------------------------------------------------------------------
 */

using GestionnaireTournois.Models;
using GestionnaireTournois.Views.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionnaireTournois
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Charge le formulaire, règle les paramètres des objets de ce dernier et affiche les données de base
        /// </summary>
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            cbxFilter.Items.AddRange(Tournoi.EtatTournoiNom);
            cbxFilter.SelectedIndex = 0;

            wbrTreeStruct.DocumentText = "";
            wbrTreeStruct.Document.Click += Document_Click;

            ChargeStatistiques();
        }

        /// <summary>
        /// Charge et affiche les tournois choisis par l'utilisateur à l'aide de la liste déroulante dans la listBox
        /// </summary>
        private void ChargeTournois()
        {
            int index = lbxTournament.SelectedIndex == -1 ? 0 : lbxTournament.SelectedIndex;

            lbxTournament.Items.Clear();

            foreach (Tournoi t in Tournoi.GetTournoisParEtat((Tournoi.EtatTournoi)cbxFilter.SelectedIndex))
            {

                lbxTournament.Items.Add(t);
            }

            lbxTournament.SelectedIndex = index >= lbxTournament.Items.Count ? -1 : index;
            ChargeStatistiques();
        }

        /// <summary>
        /// Charge et affiche les statistiques des tournois en fonction du choix de l'utilisateur
        /// </summary>
        private void ChargeStatistiques()
        {
            int index = cbxStatVitesseInscription.SelectedIndex == -1 ? 0 : cbxStatVitesseInscription.SelectedIndex;

            cbxStatVitesseInscription.Items.Clear();
            foreach(int i in DataBaseConnector.GetNbEquipesParTournoi())
            {
                cbxStatVitesseInscription.Items.Add(i);
            }

            tbxEquipesJoueur.Text = DataBaseConnector.GetMoyenneNbEquipesDesJoueurs().ToString();

            cbxStatVitesseInscription.SelectedIndex = index >= cbxStatVitesseInscription.Items.Count ? -1 : index;
        }

        /// <summary>
        /// Quitte le formulaire et réaffiche le formulaire de connexion Main
        /// </summary>
        private void tsmiModeChoice_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// Affiche la série sélectionné dans l'arbre de tournoi dans un nouveau formulaire d'édition
        /// </summary>
        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument doc = (HtmlDocument)sender;

            HtmlElement elem = doc.ActiveElement;

            if (elem.InnerHtml == "Editer")
            {
                Console.WriteLine(elem.GetAttribute("name"));
                string[] split = elem.GetAttribute("name").ToString().Split(';');

                Tournoi tournoi = Tournoi.GetTournoiById(Convert.ToInt32(split[0]));
                
                Tour tour = tournoi.GetTourByNo(Convert.ToInt32(split[1]));
                
                Serie s = tour.GetSerieById(Convert.ToInt32(split[2]));

                frmSerie frm = new frmSerie(s, true);
                frm.ShowDialog();
                ShowArborescence();
            }


        }

        /// <summary>
        /// Récupère le choix de l'utilisateur et affiche les tournois en conséquence
        /// </summary>
        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargeTournois();
        }

        /// <summary>
        /// Récupère le choix de l'utilisateur et affiche l'arbre du tournoi séléctionné
        /// </summary>
        private void lbxTournament_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowArborescence();
        }

        /// <summary>
        /// Affiche le choix de l'utilisateur (tournoi séléctionné) dans l'arbre du tournoi
        /// </summary>
        private void ShowArborescence()
        {
            try
            {
                if (lbxTournament.SelectedItem != null)
                {
                    Tournoi t = (Tournoi)lbxTournament.SelectedItem;

                    t.StartTournoi();

                    wbrTreeStruct.DocumentText = TournamentArborescenceGenerator.Generate(t, "Editer");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// Affiche les propriétés du tournoi séléctionné dans un nouveau formulaire d'édition
        /// </summary>
        private void btnProperties_Click(object sender, EventArgs e)
        {
            Tournoi t = (Tournoi)lbxTournament.SelectedItem;

            if (t != null)
            {
                frmTournamentProperties properties = new frmTournamentProperties(t);

                properties.ShowDialog();

                ChargeTournois();

                lbxTournament.SelectedIndex = lbxTournament.SelectedIndex;
            }
        }


        /// <summary>
        /// Affiche un nouveau formulaire de création de tournoi
        /// </summary>
        private void tsmiAjoutTournoi_Click(object sender, EventArgs e)
        {
            frmAjoutTournoi frm = new frmAjoutTournoi();

            frm.ShowDialog();

            ChargeTournois();

        }

        /// <summary>
        /// Récupère le choix de l'utilisateur et affiche la statisitque en conséquence
        /// </summary>
        private void cbxStatVitesseInscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(DataBaseConnector.GetVitesseInscriptionEnSecTournoiDe(Convert.ToInt32(cbxStatVitesseInscription.SelectedItem)));
            tbxVitesseInscription.Text = string.Format("{0} jours, {1:D2}h:{2:D2}m:{3:D2}s",
                                                        t.Days,
                                                        t.Hours,
                                                        t.Minutes,
                                                        t.Seconds);
        }
    }
}