/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmRechercheEquipe.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Recherche / s'inscrire dans une équipe ou en créer une 
                pour un joueur sans équipe

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

namespace GestionnaireTournois.Views.Users
{
    public partial class frmRechercheEquipe : Form
    {
        private Joueur joueur;

        public Joueur Joueur { get => joueur; set => joueur = value; }

        public frmRechercheEquipe(Joueur j)
        {
            Joueur = j;
            InitializeComponent();
        }

        /// <summary>
        /// Charge le formulaire et les informations à afficher
        /// </summary>
        private void frmRechercheEquipe_Load(object sender, EventArgs e)
        {
            ChargeEquipes();
        }

        /// <summary>
        /// Rejoins l'équipe sélectionnée dans la listBox
        /// </summary>
        private void btnRejoindre_Click(object sender, EventArgs e)
        {
            if (lbxRecherche.SelectedItem != null)
            {
                Equipe equipe = (Equipe)lbxRecherche.SelectedItem;

                Joueur.PostulerDansEquipe(equipe);
            }

        }

        /// <summary>
        /// Charge les équipes de la BD dans la listBox
        /// </summary>
        private void ChargeEquipes()
        {
            lbxRecherche.Items.Clear();


            foreach (Equipe e in Equipe.GetEquipes())
            {
                lbxRecherche.Items.Add(e);
            }
        }

        /// <summary>
        /// Créer une nouvelle équipe avec les valeurs des champs correspondant
        /// </summary>
        private void btnCreer_Click(object sender, EventArgs e)
        {
            Equipe equipe = new Equipe(tbxAcronyme.Text, tbxNom.Text, Joueur.Id);

            Equipe.Ajouter(equipe);

            this.Close();
        }
    }
}
