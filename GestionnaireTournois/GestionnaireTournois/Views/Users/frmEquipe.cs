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
    public partial class frmEquipe : Form
    {
        private Equipe equipe;
        private Joueur joueur;
        public Equipe Equipe { get => equipe; set => equipe = value; }
        public Joueur Joueur { get => joueur; set => joueur = value; }

        public frmEquipe(Joueur joueur)
        {
            equipe = joueur.GetEquipe();
            Joueur = joueur;
            InitializeComponent();
        }

        private void frmEquipe_Load(object sender, EventArgs e)
        {
            lblEquipe.Text = equipe.Nom;

            ConstruireDataGridView();
            ChargeJoueurs();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Equipe.SupprimerJoueur(Joueur);
        }

        private void ConstruireDataGridView()
        {
            dgvMembresEquipe.ColumnCount = 4;
            dgvMembresEquipe.Columns[0].Name = "Pseudo";
            dgvMembresEquipe.Columns[1].Name = "Nom";
            dgvMembresEquipe.Columns[2].Name = "Prénom";
            dgvMembresEquipe.Columns[3].Name = "Email";

            dgvMembresEquipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ChargeJoueurs()
        {
            dgvMembresEquipe.Rows.Clear();


            foreach (Joueur j in Equipe.GetJoueursActuels())
            {
                dgvMembresEquipe.Rows.Add(j.Pseudo, j.Nom, j.Prenom, j.Email);
            }
        }
    }
}
