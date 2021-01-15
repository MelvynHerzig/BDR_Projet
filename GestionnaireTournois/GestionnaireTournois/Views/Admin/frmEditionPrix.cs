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

namespace GestionnaireTournois.Views.Admin
{
    public partial class frmEditionPrix : Form
    {

        private Prix prix;
        public Prix Prix { get => prix; set => prix = value; }

        public frmEditionPrix(Prix prix)
        {
            Prix = prix;
            InitializeComponent();
        }

        private void LoadPrix()
        {
            if (Prix == null) return;

            nudMontantArgent.Value = (int)Prix.MontantArgent;

            lbxObjets.Items.Clear();
            lbxObjets.Items.AddRange(Prix.GetObjets().ToArray());
        }

        private void LoadObjets()
        {
            lbxTousObjets.Items.Clear();
            lbxTousObjets.Items.AddRange(Objet.GetObjets().ToArray());
        }

        private void frmEditionPrix_Load(object sender, EventArgs e)
        {
            LoadPrix();
            LoadObjets();
        }

        private void btnAddToPrix_Click(object sender, EventArgs e)
        {

            lbxObjets.Items.Add(lbxTousObjets.SelectedItem);
        }

        private void btnRetirerObjet_Click(object sender, EventArgs e)
        {
            lbxObjets.Items.Remove(lbxObjets.SelectedItem);
        }

        private void btnAddObjet_Click(object sender, EventArgs e)
        {
            Objet o = new Objet(0, tbxNouvelObjet.Text);

            o.AjouterInDB();

            LoadObjets();
        }

        private void btnEnregistrerPrixAssignés_Click(object sender, EventArgs e)
        {
            if (Prix == null)
            {
                Prix = new Prix(0, Convert.ToDouble(nudMontantArgent.Value));
                Prix.CreerInDB();
            }
            else
            {
                Prix.ModifierMontantArgent(Convert.ToDouble(nudMontantArgent.Value));
            }
            Prix.AjouterObjets(lbxObjets.Items.Cast<Objet>().ToList());
        }
    }
}
