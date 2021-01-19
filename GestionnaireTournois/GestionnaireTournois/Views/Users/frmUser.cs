/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmUser.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Formulaire principal de la partie utilisateur qui peut
                Afficher les tournois du joueur connecté
                Gérer les tournois de l'équipe pour un responsable
                Naviguer dans divers formulaires concernant le joueur à l'aide du menu

 Remarque(s) : /

 -------------------------------------------------------------------------------
 */

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

        /// <summary>
        /// Charge le formulaire
        /// </summary>
        private void frmUser_Load(object sender, EventArgs e)
        {
            RechargerAffichage();
        }

        /// <summary>
        /// Affiche les éléments en fonction du type de joueur (responsable ou non)
        /// </summary>
        private void RechargerAffichage()
        {
            if (Joueur.GetEquipe() == null || Joueur.Id != Joueur.GetEquipe().IdResponsable)
            {
                lblTypeTournoi.Visible = false;
                cbxTypeTournois.Visible = false;
            }
            else
            {
                lblTypeTournoi.Visible = true;
                cbxTypeTournois.Visible = true;
            }

            cbxTypeTournois.SelectedIndex = 0;
        }

        /// <summary>
        /// Effectue l'action réalisée par l'utilisateur (voir le tournoi ou s'y inscrire)
        /// </summary>
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
                        ChargeTournoisParticipes();
                        break;
                    case "Tournois rejoignables":
                        Equipe equipe = Joueur.GetEquipe();
                        if (equipe != null)
                            tournoiSelectionne.Inscrire(equipe);
                        ChargeTournoisRejoignables();
                        break;
                }

            }
        }

        /// <summary>
        /// Quitte le formulaire et réaffiche le formulaire de connexion Main
        /// </summary>
        private void tsmiChoixMode_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Créer et affiche un formulaire contenant les statistiques du joueur connecté
        /// </summary>
        private void tsmiStats_Click(object sender, EventArgs e)
        {
            frmStats stats = new frmStats(Joueur);
            stats.ShowDialog();
        }

        /// <summary>
        /// Créer et affiche un formulaire affichant l'équipe du joueur connecté
        /// </summary>
        private void tsmiEquipes_Click(object sender, EventArgs e)
        {
            if (Joueur.GetEquipe() == null)
            {
                frmRechercheEquipe frm = new frmRechercheEquipe(Joueur);

                frm.ShowDialog();

                RechargerAffichage();
            }
            else
            {
                frmEquipe frm = new frmEquipe(Joueur);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Affiche les tournois en fonction du choix de la list déroulante (mode Responsable)
        /// </summary>
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

        /// <summary>
        /// Affiche les tournois auquels le joueur a participé et participe
        /// </summary>
        private void ChargeTournoisParticipes()
        {
            dgvTournois.Rows.Clear();

            TournoisAffiches = Tournoi.GetTournoisParticipes(Joueur);

            foreach (Tournoi t in TournoisAffiches)
            {
                if (t.DateHeureFin == DateTime.MinValue)
                {
                    dgvTournois.Rows.Add(t.Nom, t.DateHeureDebut, "Non terminé", t.NbEquipesMax, "Voir");
                }
                else
                {
                    dgvTournois.Rows.Add(t.Nom, t.DateHeureDebut, t.DateHeureFin, t.NbEquipesMax, "Voir");
                }
            }
        }

        /// <summary>
        /// Affiche les tournois rejoignables (mode Responsable)
        /// </summary>
        private void ChargeTournoisRejoignables()
        {
            dgvTournois.Rows.Clear();

            TournoisAffiches = Tournoi.GetTournoisRejoignables();

            foreach (Tournoi t in TournoisAffiches)
            {
                if (t.DateHeureFin == DateTime.MinValue)
                {
                    dgvTournois.Rows.Add(t.Nom, t.DateHeureDebut, "Non terminé", t.NbEquipesMax, "S'inscrire");
                }
                else
                {
                    dgvTournois.Rows.Add(t.Nom, t.DateHeureDebut, t.DateHeureFin, t.NbEquipesMax, "S'inscrire");
                }
            }
        }
    }
}
