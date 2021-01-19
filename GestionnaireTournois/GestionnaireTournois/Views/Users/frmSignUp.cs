/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmSignUp.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : S'inscrire sur la plateforme en tant que nouveau joueur

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
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Charge le formulaire et conditionne les champs avec des valeurs de base
        /// </summary>
        private void frmSignUp_Load(object sender, EventArgs e)
        {
            dtpBirthday.MaxDate = DateTime.Now;
        }

        /// <summary>
        /// Créer le nouveau joueur avec les valeurs des champs correspondant
        /// </summary>
        private void btnSignUp_Click(object sender, EventArgs e)
        {

            Joueur j = new Joueur(0, tbxName.Text, tbxFirstName.Text, tbxEmail.Text, tbxPseudo.Text, dtpBirthday.Value);

            Joueur.Ajouter(j);
        }

        /// <summary>
        /// Quitte le formulaire
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
