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
        private Joueur[] membresEquipe;
        public Equipe Equipe { get => equipe; set => equipe = value; }

        public frmEquipe(Equipe e)
        {
            equipe = e;
            InitializeComponent();
        }

        private void frmEquipe_Load(object sender, EventArgs e)
        {
            lblEquipe.Text = equipe.Nom;

            construireDataGridView();
            ChargeJoueurs();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            //requête quitter équipe
            //DELETE FROM equipe_joueur WHERE idJoueur = joueur.id;
        }

        private void construireDataGridView()
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

            membresEquipe = new Joueur[] { new Joueur(100, "Berney", "Alec", "alec.berney@heig-vd.ch", "Marlek", new DateTime(1998, 09, 09)),
                                           new Joueur(100, "Herzig", "Melvyn", "melvyn.herzig@heig-vd.ch", "Wheald", new DateTime(1997, 09, 09)),
                                           new Joueur(100, "Forestier", "Quentin", "quentin.forestier@heig-vd.ch", "Dudude", new DateTime(2001, 09, 09)) };
            //membresEquipe = DataBaseConnector.GetTournoisFiltres((Tournoi.EtatTournoi)dgvMembresEquipe.SelectedIndex).ToArray();

            foreach (Joueur j in membresEquipe)
            {
                dgvMembresEquipe.Rows.Add(j.Pseudo, j.Nom, j.Prenom, j.Email);
            }
        }
    }
}
