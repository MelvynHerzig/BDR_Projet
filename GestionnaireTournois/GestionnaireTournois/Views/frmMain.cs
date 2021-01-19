/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmMain.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Rejoindre soit la partie utilisateur ou soit la partie administateur

 Remarque(s) : /

 -------------------------------------------------------------------------------
 */

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

namespace GestionnaireTournois
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

       	/// <summary>
        /// Créer et affiche un nouveau formulaire de la partie Admin
        /// </summary>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin admin = new frmAdmin();

            this.Hide();

            if (admin.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }

            this.Show();
        }

        /// <summary>
        /// Créer et affiche un nouveau formulaire de la partie d'inscription
        /// </summary>
        private void btnSignUp_Click(object sender, EventArgs e)
        {

            frmSignUp signUp = new frmSignUp();

            signUp.ShowDialog();

        }

        /// <summary>
        /// Créer et affiche un nouveau formulaire de la partie utilisateur
        /// si l'email entré est valide
        /// </summary>
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Joueur j = Joueur.GetJoueurByEmail(tbxEmail.Text);
            // Check dans la base de donnée l'email
            // Si dans la base :
            if (j != null)
            {
                frmUser user = new frmUser(j);
                this.Hide();
                if (user.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                }
                this.Show();
            }

        }

        /// <summary>
        /// Affiche ou non le bouton en fonction de la valeur de l'email
        /// </summary>
        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            btnSignIn.Enabled = tbxEmail.TextLength > 0;
        }

        /// <summary>
        /// Charge le formulaire et test la connection à la BD
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                DataBaseConnector.TestDBConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données, veuillez consulter le manuel d'installation.", "Connexion à la base impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
