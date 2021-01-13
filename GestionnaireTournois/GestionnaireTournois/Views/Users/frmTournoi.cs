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

namespace GestionnaireTournois.Views.Users
{
    public partial class frmTournoi : Form
    {
        private Tournoi tournoi;
        public Tournoi Tournoi { get => tournoi; set => tournoi = value; }

        public frmTournoi(Tournoi t)
        {
            tournoi = t;
            InitializeComponent();
        }
    }
}
