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
            tbxId.Text = Tournoi.Id.ToString();
            tbxName.Text = Tournoi.Nom;

            tbxDateDebut.Text = Tournoi.DateHeureDebut.ToString();

            tbxDateFin.Text = Tournoi.DateHeureFin.ToString();

            tbxDateFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;
            lblDateFin.Visible = Tournoi.DateHeureFin != DateTime.MinValue;

            tbxMaxJoueurs.Text = Tournoi.NbEquipesMax.ToString();

        }
    }
}
