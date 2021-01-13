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

        public String GetName()
        {
            return tbxName.Text;
        }

        public String GetFirstName()
        {
            return tbxFirstName.Text;
        }

        public String GetEmail()
        {
            return tbxEmail.Text;
        }

        public String GetPseudo()
        {
            return tbxPseudo.Text;
        }

        public DateTime GetBirthday()
        {
            return dtpBirthday.Value;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // requête enregistrement
             //INSERT INTO joueur (nom, prenom, peuso, email) VALUES (tbxName.Text, tbxFirstName.Text, tbxPseudo.Text, tbxEmail.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbxFirstName.Text = "";
            tbxName.Text = "";
            tbxPseudo.Text = "";
            tbxEmail.Text = "";
            tbxFirstName.Text = "";
            dtpBirthday.Value = new DateTime(0001-01-01);
        }
    }
}
