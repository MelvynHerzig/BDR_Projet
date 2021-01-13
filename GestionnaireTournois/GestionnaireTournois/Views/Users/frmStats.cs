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

namespace GestionnaireTournois.Views.Users
{
    public partial class frmStats : Form
    {
        private Joueur joueur;
        public Joueur Joueur { get => joueur; set => joueur = value; }

        public frmStats(Joueur j)
        {
            joueur = j;
            InitializeComponent();
        }

        private void frmStats_Load(object sender, EventArgs e)
        {
            // récupérer les valeurs stats via requête
            lblPseudoJoueur.Text = joueur.Pseudo;
            lblNbButs.Text = "0";
            lblNbArrets.Text = "0";
            lblMoyenneButs.Text = "0";
            lblMoyenneArret.Text = "0";
            lblRapportSerie.Text = "0";
        }
    }
}
