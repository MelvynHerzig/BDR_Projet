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
    public partial class frmRechercheEquipe : Form
    {
        private Joueur joueur;
        public frmRechercheEquipe(Joueur j)
        {
            joueur = j;
            InitializeComponent();
        }

        private void frmRechercheEquipe_Load(object sender, EventArgs e)
        {
            ChargeEquipes();
        }

        private void btnRejoindre_Click(object sender, EventArgs e)
        {
            if (lbxEquipes.SelectedItem != null)
            {
                Equipe equipe = (Equipe)lbxEquipes.SelectedItem;
                // requête 
                // INSERT INTO equipe_joueur (acronymeEquipe, idJoueur, dateHeureArrivee) VALUES (equipe.Acronyme, joueur.Id, "0001-01-01");
            }

        }

        private void ChargeEquipes()
        {
            lbxEquipes.Items.Clear();


            foreach (Equipe e in Equipe.GetEquipes())
            {
                lbxEquipes.Items.Add(e);
            }
        }
    }
}
