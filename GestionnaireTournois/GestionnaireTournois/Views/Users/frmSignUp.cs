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
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {
            dtpBirthday.MaxDate = DateTime.Now;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // requête enregistrement
            //INSERT INTO joueur (nom, prenom, peuso, email) VALUES (tbxName.Text, tbxFirstName.Text, tbxPseudo.Text, tbxEmail.Text);

            Joueur j = new Joueur(0, tbxName.Text, tbxFirstName.Text, tbxPseudo.Text, tbxEmail.Text, dtpBirthday.Value);

            //Joueur.Aj
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
