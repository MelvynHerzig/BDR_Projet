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
    public partial class frmAjoutTournoi : Form
    {
        public frmAjoutTournoi()
        {
            InitializeComponent();
        }

        private void btnAjouterTournoi_Click(object sender, EventArgs e)
        {

            Tournoi t = new Tournoi(0, dtpDateDebut.Value, DateTime.Now, "Test", 16);

            DataBaseConnector.InsertionTournoi(t);

            this.Close();
        }
    }
}
