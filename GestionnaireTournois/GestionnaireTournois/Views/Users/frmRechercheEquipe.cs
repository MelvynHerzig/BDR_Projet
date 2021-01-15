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

        public Joueur Joueur { get => joueur; set => joueur = value; }

        public frmRechercheEquipe(Joueur j)
        {
            Joueur = j;
            InitializeComponent();
        }

        private void frmRechercheEquipe_Load(object sender, EventArgs e)
        {
            ChargeEquipes();
        }

        private void btnRejoindre_Click(object sender, EventArgs e)
        {
            if (lbxRecherche.SelectedItem != null)
            {
                Equipe equipe = (Equipe)lbxRecherche.SelectedItem;

                Joueur.PostulerDansEquipe(equipe);
            }

        }

        private void ChargeEquipes()
        {
            lbxRecherche.Items.Clear();


            foreach (Equipe e in Equipe.GetEquipes())
            {
                lbxRecherche.Items.Add(e);
            }
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            Equipe equipe = new Equipe(tbxAcronyme.Text, tbxNom.Text, Joueur.Id);

            Equipe.Ajouter(equipe);
        }
    }
}
