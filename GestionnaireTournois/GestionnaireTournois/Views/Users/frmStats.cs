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
            Joueur = j;
            InitializeComponent();
        }

        private void frmStats_Load(object sender, EventArgs e)
        {
            // récupérer les valeurs stats via requête

            int[] statsTotal = Joueur.GetStatsTotal();
            double[] moyenneStats = Joueur.GetMoyenneStats();

            lblPseudoJoueur.Text = Joueur.Pseudo;
            lblNbButs.Text = statsTotal[0].ToString();
            lblNbArrets.Text = statsTotal[1].ToString();
            lblMoyenneButs.Text = String.Format("{0:0.00}", moyenneStats[0]);
            lblMoyenneArret.Text = String.Format("{0:0.00}", moyenneStats[1]);

            double nbSerieGagnee = Joueur.GetNbSerieGagnee();
            double nbSerieJouee = Joueur.GetNbSerieJouee();

            lblRapportSerie.Text = nbSerieJouee == 0 ? "-" : (nbSerieGagnee / nbSerieJouee).ToString("0.00");
        }
    }
}
