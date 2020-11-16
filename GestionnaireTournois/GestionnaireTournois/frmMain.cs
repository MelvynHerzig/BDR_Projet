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

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            Form signUp = new frmSignUp();


            signUp.ShowDialog();

            lblSignUp.Enabled = true;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            int userId = 0;
            // Check dans la base de donnée l'email
            // Si dans la base :
            {
                frmUser user = new frmUser(userId);
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
