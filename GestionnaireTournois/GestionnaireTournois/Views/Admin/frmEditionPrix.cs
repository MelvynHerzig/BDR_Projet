/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmEditionPrix.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Gérer, afficher et modifier les prix d'un tournoi choisi 
                pour une place finale définie (1er ou 2ème)

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

        /// <summary>
        /// Charge le formulaire et les données utilisées dans ce dernier
        /// </summary>
        private void frmEditionPrix_Load(object sender, EventArgs e)
        {
            LoadPrix();
            LoadObjets();
        }

        /// <summary>
        /// Charge et affiche les prix dans la listBox prévu pour
        /// </summary>
        private void LoadPrix()
        {
            if (Prix == null) return;

            nudMontantArgent.Value = (int)Prix.MontantArgent;

            lbxObjets.Items.Clear();
            lbxObjets.Items.AddRange(Prix.GetObjets().ToArray());
        }

        /// <summary>
        /// Charge et affiche tous les objets dans la listBox prévu pour
        /// </summary>
        private void LoadObjets()
        {
            lbxTousObjets.Items.Clear();
            lbxTousObjets.Items.AddRange(Objet.GetObjets().ToArray());
        }

        /// <summary>
        /// Ajoute l'objet séléctionné aux prix du tournoi en cours d'édition
        /// </summary>
        private void btnAddToPrix_Click(object sender, EventArgs e)
        {

            lbxObjets.Items.Add(lbxTousObjets.SelectedItem);
        }

        /// <summary>
        /// Retire l'objet séléctionné des prix du tournoi en cours d'édition
        /// </summary>
        private void btnRetirerObjet_Click(object sender, EventArgs e)
        {
            lbxObjets.Items.Remove(lbxObjets.SelectedItem);
        }

        /// <summary>
        /// Récupère l'objet à ajouter au tournoi et l'ajoute
        /// </summary>
        private void btnAddObjet_Click(object sender, EventArgs e)
        {
            Objet o = new Objet(0, tbxNouvelObjet.Text);

            o.AjouterInDB();

            LoadObjets();
        }

        /// <summary>
        /// Enregistre les modifications concernant les prix du tournoi en cours d'édition
        /// </summary>
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
