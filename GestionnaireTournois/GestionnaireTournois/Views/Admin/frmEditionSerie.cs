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

namespace GestionnaireTournois.Views.Admin
{
    public partial class frmEditionSerie : Form
    {

        private Serie serie;
        public Serie Serie { get => serie; set => serie = value; }
        public frmEditionSerie(Serie serie)
        {
            Serie = serie;
            InitializeComponent();
        }

        private void btnAjoutMatch_Click(object sender, EventArgs e)
        {
            DataBaseConnector.AjouterMatch(Serie);
        }

        private void frmEditionSerie_Load(object sender, EventArgs e)
        {
            lbxMatchs.Items.AddRange(Serie.GetMatches().ToArray());
            List<Equipe> equipes = Serie.GetEquipes();
            gbxEquipe1.Text = equipes[0].Nom;
            gbxEquipe2.Text = equipes[1].Nom;
        }

        private void lbxMatchs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatch((Match)lbxMatchs.SelectedItem);
        }

        private void LoadMatch(Match m)
        {
            List<Equipe> equipes = Serie.GetEquipes();
            //List<Joueur> equipe1 = equipes[0].Get
        }
    }
}
