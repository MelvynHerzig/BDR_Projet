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

        private void frmTournamentProperties_Load(object sender, EventArgs e)
        {

            LoadInfoTournoi();
            LoadInfoTours();
        }

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

        private void LoadInfoTours()
        {
            cbxTours.Items.AddRange(Tournoi.GetTours().ToArray());
            cbxTours.SelectedIndex = 0;
        }

        private void cbxTours_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudLongueurSerie.Value = ((Tour)cbxTours.SelectedItem).LongueurMaxSerie;
        }

        private void nudLongueurSerie_ValueChanged(object sender, EventArgs e)
        {
            ((Tour)cbxTours.SelectedItem).LongueurMaxSerie = (int)nudLongueurSerie.Value;
        }

        private void btnSaveTours_Click(object sender, EventArgs e)
        {
            Tournoi.ModifierTours(cbxTours.Items.Cast<Tour>().ToList());
        }

        private void btn1erPrix_Click(object sender, EventArgs e)
        {
            frmEditionPrix frm = new frmEditionPrix(Tournoi.GetPremierPrix());
            frm.ShowDialog();
            Tournoi.AjouterPremierPrix(frm.Prix);


        }

        private void btn2emePrix_Click(object sender, EventArgs e)
        {
            frmEditionPrix frm = new frmEditionPrix(Tournoi.GetDeuxiemePrix());
            frm.ShowDialog();
            Tournoi.AjouterDeuxiemePrix(frm.Prix);


        }

        private void btnSupprimerTournoi_Click(object sender, EventArgs e)
        {
            Tournoi.Supprimer(Tournoi);
            this.Close();
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            Tournoi.ModifierProprietes(tbxName.Text, dtpDateDebut.Value.Date + dtpHeureDebut.Value.TimeOfDay);
        }

        private void btnRetirerEquipe_Click(object sender, EventArgs e)
        {
            Equipe equipe = (Equipe)lbxEquipesInscrites.SelectedItem;

            if(equipe != null)
            {
                equipe.AbandonnerTournoi(Tournoi);
                LoadInfoTournoi();
            }
        }
    }
}
