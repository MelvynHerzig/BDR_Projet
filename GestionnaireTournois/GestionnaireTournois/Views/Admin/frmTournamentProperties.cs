/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmTournoiProperties.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Editer et afficher les propriétés du tournoi choisi

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
    public partial class frmTournamentProperties : Form
    {
        private Tournoi tournoi;
        public Tournoi Tournoi { get => tournoi; set => tournoi = value; }
        public frmTournamentProperties(Tournoi t)
        {
            Tournoi = t;
            InitializeComponent();
        }

        /// <summary>
        /// Charge le formulaire et affiche les données de base
        /// </summary>
        private void frmTournamentProperties_Load(object sender, EventArgs e)
        {

            LoadInfoTournoi();
            LoadInfoTours();
        }

        /// <summary>
        /// Charge et affiche les données concernant le tournoi dans les champs correspondants
        /// </summary>
        private void LoadInfoTournoi()
        {
            lbxEquipesInscrites.Items.Clear();

            tbxId.Text = Tournoi.Id.ToString();
            tbxName.Text = Tournoi.Nom;


            dtpDateDebut.Value = Tournoi.DateHeureDebut;
            dtpHeureDebut.Value = Tournoi.DateHeureDebut;

            if (Tournoi.DateHeureFin != DateTime.MinValue)
            {
                dtpDateFin.Value = Tournoi.DateHeureFin;
                dtpHeureFin.Value = Tournoi.DateHeureFin;
            }
            
            dtpHeureFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;
            dtpDateFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;
            lblDateFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;
            lblHeureFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;
            
            tbxMaxJoueurs.Text = Tournoi.NbEquipesMax.ToString();

            lbxEquipesInscrites.Items.AddRange(Tournoi.GetEquipesInscrites().ToArray());
        }

        /// <summary>
        /// Charge et affiche les données concernant le tour dans les champs correspondants
        /// </summary>
        private void LoadInfoTours()
        {
            cbxTours.Items.AddRange(Tournoi.GetTours().ToArray());
            cbxTours.SelectedIndex = 0;
        }

        /// <summary>
        /// Récupère le choix de l'utilisateur et affiche le tour séléctionné
        /// </summary>
        private void cbxTours_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudLongueurSerie.Value = ((Tour)cbxTours.SelectedItem).LongueurMaxSerie;
        }

        /// <summary>
        /// Change la longueur d'une série avec la valeur choisie pour le tour séléctionné
        /// </summary>
        private void nudLongueurSerie_ValueChanged(object sender, EventArgs e)
        {
            ((Tour)cbxTours.SelectedItem).LongueurMaxSerie = (int)nudLongueurSerie.Value;
        }

        /// <summary>
        /// Modifie le tour séléctionné avec les valeurs des champs actuels
        /// </summary>
        private void btnSaveTours_Click(object sender, EventArgs e)
        {
            Tournoi.ModifierTours(cbxTours.Items.Cast<Tour>().ToList());
        }

        /// <summary>
        /// Affiche les propriétés du prix du premier dans un nouveau formulaire d'édition
        /// </summary>
        private void btn1erPrix_Click(object sender, EventArgs e)
        {
            frmEditionPrix frm = new frmEditionPrix(Tournoi.GetPremierPrix());
            frm.ShowDialog();
            Tournoi.AjouterPremierPrix(frm.Prix);


        }

        /// <summary>
        /// Affiche les propriétés du prix du second dans un nouveau formulaire d'édition
        /// </summary>
        private void btn2emePrix_Click(object sender, EventArgs e)
        {
            frmEditionPrix frm = new frmEditionPrix(Tournoi.GetDeuxiemePrix());
            frm.ShowDialog();
            Tournoi.AjouterDeuxiemePrix(frm.Prix);


        }

        /// <summary>
        /// Supprime le tournoi en cours d'édition
        /// </summary>
        private void btnSupprimerTournoi_Click(object sender, EventArgs e)
        {
            Tournoi.Supprimer(Tournoi);
            this.Close();
        }

        /// <summary>
        /// Sauvegarde toutes les modifications faites au tournoi en cours d'édition
        /// </summary>
        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            Tournoi.ModifierProprietes(tbxName.Text, dtpDateDebut.Value.Date + dtpHeureDebut.Value.TimeOfDay);
        }

        /// <summary>
        /// Retire l'équipe séléctionnée du tournoi
        /// </summary>
        private void btnRetirerEquipe_Click(object sender, EventArgs e)
        {
            Equipe equipe = (Equipe)lbxEquipesInscrites.SelectedItem;

            if(equipe != null)
            {
                if(Tournoi.EstEnAttente())
                    equipe.AbandonnerTournoi(Tournoi);
                LoadInfoTournoi();
            }
        }
    }
}
