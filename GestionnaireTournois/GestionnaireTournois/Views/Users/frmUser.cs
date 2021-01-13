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
        private List<Tournoi> tournois;

        public Joueur Joueur { get => joueur; set => joueur = value; }
        public List<Tournoi> Tournois { get => tournois; set => tournois = value; }

        public frmUser(Joueur j)
        {
            Joueur = j;
            InitializeComponent();
        }

        private void ChargeTournois()
        {
            dgvTournois.Rows.Clear();

            Tournois = Tournoi.GetTournoiParEtat((Tournoi.EtatTournoi)cbxTournois.SelectedIndex);

            foreach (Tournoi t in Tournois)
            {
                dgvTournois.Rows.Add(t.Nom, t.DateHeureDebut, t.DateHeureFin, t.NbEquipesMax);
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            cbxTournois.Items.AddRange(Tournoi.EtatTournoiNom);
            cbxTournois.SelectedIndex = 0;

            ConstruireDataGridView();
            ChargeTournois();

            // id responsable == id joueur
            // get equipe

            /*if(estResposable)
            {
                btnEquipe.Text = "Gérer équipe";
            }*/
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            frmStats stats = new frmStats(Joueur);
            stats.ShowDialog();
        }

        private void btnEquipe_Click(object sender, EventArgs e)
        {

            frmEquipe equipe = new frmEquipe(Joueur);
            equipe.ShowDialog();

            /*if(estResponsable)
            {
                frmEquipe equipe = new frmEquipe(joueur);
                equipe.ShowDialog();
            }
            else if(napasdequipe)
            {
                
            }
            else
            {
                
                frmGestionEquipe equipe = new frmGestionEquipe(joueur);
                equipe.ShowDialog();
            }*/
        }

        private void cbxTournois_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargeTournois();
        }

        private void ConstruireDataGridView()
        {
            dgvTournois.ColumnCount = 4;
            dgvTournois.Columns[0].Name = "Nom tournoi";
            dgvTournois.Columns[1].Name = "Date début";
            dgvTournois.Columns[2].Name = "Date fin";
            dgvTournois.Columns[3].Name = "Nombre d'équipe";

            dgvTournois.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Actions";
            btn.Text = "Voir";
            btn.Name = "btnVoir";
            btn.UseColumnTextForButtonValue = true;
            dgvTournois.Columns.Add(btn);
        }

        private void dgvTournois_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4 & e.RowIndex < Tournois.Count)
            {
                Tournoi tournoiSelectionne = Tournois[e.RowIndex];

                MessageBox.Show("tournoi sélectionné : " + tournoiSelectionne.Nom);

            }   
        }

        private void tsmiChoixMode_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
