using GestionnaireTournois.Models;
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
            tbxId.Text = Tournoi.Id.ToString();
            tbxName.Text = Tournoi.Nom;

            tbxDateDebut.Text = Tournoi.DateHeureDebut.ToString();

            tbxDateFin.Text = Tournoi.DateHeureFin.ToString();

            tbxDateFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;
            lblDateFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;

            tbxMaxJoueurs.Text = Tournoi.NbEquipesMax.ToString();
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

        }

        private void btn2emePrix_Click(object sender, EventArgs e)
        {

        }
    }
}
