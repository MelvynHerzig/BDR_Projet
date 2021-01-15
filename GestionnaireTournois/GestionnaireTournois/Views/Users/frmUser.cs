using GestionnaireTournois.Models;
using GestionnaireTournois.Views.Users;
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
    public partial class frmUser : Form
    {
        private Joueur joueur;
        private List<Tournoi> tounroisAffiches;

        public Joueur Joueur { get => joueur; set => joueur = value; }
        public List<Tournoi> TournoisAffiches { get => tounroisAffiches; set => tounroisAffiches = value; }

        public frmUser(Joueur j)
        {
            Joueur = j;
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            if(Joueur.GetEquipe() == null || Joueur.Id != Joueur.GetEquipe().IdResponsable)
            {
                lblTypeTournoi.Visible = false;
                cbxTypeTournois.Visible = false;
            }

            cbxTypeTournois.SelectedIndex = 0;
        }


        private void dgvTournois_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvTournois.Columns.Count - 1 && e.RowIndex < TournoisAffiches.Count && e.RowIndex != -1)
            {
                Tournoi tournoiSelectionne = TournoisAffiches[e.RowIndex];

                switch (cbxTypeTournois.SelectedItem)
                {
                    case "Tournois participés":
                        frmTournoi frm = new frmTournoi(Joueur, tournoiSelectionne);
                        frm.ShowDialog();
                        break;
                    case "Tournois rejoignables":
                        Equipe equipe = Joueur.GetEquipe();
                        if(equipe != null)
                            tournoiSelectionne.Inscrire(equipe);
                        break;
                }

            }
        }

        private void tsmiChoixMode_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tsmiStats_Click(object sender, EventArgs e)
        {
            frmStats stats = new frmStats(Joueur);
            stats.ShowDialog();
        }

        private void tsmiEquipes_Click(object sender, EventArgs e)
        {
            if (Joueur.GetEquipe() == null)
            {
                frmRechercheEquipe frm = new frmRechercheEquipe(Joueur);

                frm.ShowDialog();
            }
            else
            {
                frmEquipe frm = new frmEquipe(Joueur);
                frm.ShowDialog();
            }
        }

        private void cbxTypeTournois_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbxTypeTournois.SelectedItem)
            {
                case "Tournois participés":
                    ChargeTournoisParticipes();
                    break;
                case "Tournois rejoignables":
                    ChargeTournoisRejoignables();
                    break;
            }
        }

        private void ChargeTournoisParticipes()
        {
            dgvTournois.Rows.Clear();

            TournoisAffiches = Tournoi.GetTournoisParticipes(Joueur.GetEquipe());

            foreach (Tournoi t in TournoisAffiches)
            {
                dgvTournois.Rows.Add(t.Nom, t.DateHeureDebut, t.DateHeureFin, t.NbEquipesMax, "Voir");
            }
        }

        private void ChargeTournoisRejoignables()
        {
            dgvTournois.Rows.Clear();

            TournoisAffiches = Tournoi.GetTournoisRejoignables();

            foreach (Tournoi t in TournoisAffiches)
            {
                dgvTournois.Rows.Add(t.Nom, t.DateHeureDebut, t.DateHeureFin, t.NbEquipesMax, "S'inscrire");
            }
        }
    }
}
