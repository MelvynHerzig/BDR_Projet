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
            // On load les pays qui sont dans la base de données dans le combobox

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

        public int GetCountryKey()
        {
            // A revoir
            return cbxCountry.SelectedIndex;
        }
    }
}
