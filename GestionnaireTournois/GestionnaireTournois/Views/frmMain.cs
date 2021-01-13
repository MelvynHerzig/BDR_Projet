﻿using GestionnaireTournois.Models;
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

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            frmSignUp signUp = new frmSignUp();


            if (signUp.ShowDialog() == DialogResult.OK)
            {
                // Recupère info + envoie bdd
                signUp.GetName();
                signUp.GetFirstName();
                signUp.GetEmail();
                signUp.GetPseudo();
                signUp.GetBirthday();
            }

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Joueur j = Joueur.GetJoueurById(1);
            // Check dans la base de donnée l'email
            // Si dans la base :
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

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            btnSignIn.Enabled = tbxEmail.TextLength > 0;
        }

    }
}
