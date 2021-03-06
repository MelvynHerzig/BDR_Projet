﻿/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmEquipe.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Afficher et gérer l'équipe du joueur / responsable connecté

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
    public partial class frmEquipe : Form
    {
        private Equipe equipe;
        private Joueur joueur;

        private List<Joueur> joueursAffiches;
        public Equipe Equipe { get => equipe; set => equipe = value; }
        public Joueur Joueur { get => joueur; set => joueur = value; }
        public List<Joueur> JoueursAffiches { get => joueursAffiches; set => joueursAffiches = value; }

        public frmEquipe(Joueur joueur)
        {
            equipe = joueur.GetEquipe();
            Joueur = joueur;

            JoueursAffiches = new List<Joueur>();

            InitializeComponent();
        }

        /// <summary>
        /// Charge le formulaire et règles les paramètre d'affichage du GridView
        /// </summary>
        private void frmEquipe_Load(object sender, EventArgs e)
        {
            lblEquipe.Text = Equipe.Nom;

            if (Joueur.Id != Equipe.IdResponsable)
            {
                cbxInfosJoueur.Visible = false;
                dgvAffichage.Columns["colActions"].Visible = false;
                dgvAffichage.Columns["colNbSerieGagnee"].Visible = false;
                dgvAffichage.Columns["colTotButs"].Visible = false;
                dgvAffichage.Columns["colTotArrets"].Visible = false;

            }
            else
            {
                btnQuitter.Visible = false;
            }

            cbxInfosJoueur.SelectedIndex = 0;

        }

        /// <summary>
        /// Le joueur quitte son équipe actuelle
        /// </summary>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Equipe.SupprimerJoueur(Joueur);
        }

        /// <summary>
        /// Charge et affiche les joueurs actuels de l'équipe dans le GridView
        /// </summary>
        private void ChargeJoueursActuels()
        {
            dgvAffichage.Rows.Clear();

            dgvAffichage.Columns["colActions"].Visible = Joueur.Id == Equipe.IdResponsable;

            JoueursAffiches = Equipe.GetJoueursActuels();

            foreach (Joueur j in JoueursAffiches)
            {
                dgvAffichage.Rows.Add(j.Pseudo, j.Nom, j.Prenom, j.Email, j.GetNbSerieGagnee(), j.GetStatsTotal()[0], j.GetStatsTotal()[1], j.GetMoyenneStats()[0].ToString("0.00"), j.GetMoyenneStats()[1].ToString("0.00"), "Renvoyer");
            }
        }

        /// <summary>
        /// Charge et affiche les anciens joueurs de l'équipe dans le GridView
        /// </summary>
        private void ChargeAnciensJoueurs()
        {
            dgvAffichage.Rows.Clear();

            dgvAffichage.Columns["colActions"].Visible = false;

            JoueursAffiches = Equipe.GetAnciensJoueurs();

            foreach (Joueur j in JoueursAffiches)
            {
                dgvAffichage.Rows.Add(j.Pseudo, j.Nom, j.Prenom, j.Email, j.GetNbSerieGagnee(), j.GetStatsTotal()[0], j.GetStatsTotal()[1], j.GetMoyenneStats()[0].ToString("0.00"), j.GetMoyenneStats()[1].ToString("0.00"), "");
            }
        }

        /// <summary>
        /// Charge et affiche les joueurs en attente pour rejoindre l'équipe dans le GridView
        /// </summary>
        private void ChargeJoueursEnAttente()
        {
            dgvAffichage.Rows.Clear();

            dgvAffichage.Columns["colActions"].Visible = Joueur.Id == Equipe.IdResponsable;

            JoueursAffiches = Equipe.GetJoueursEnAttente();

            foreach (Joueur j in JoueursAffiches)
            {
                dgvAffichage.Rows.Add(j.Pseudo, j.Nom, j.Prenom, j.Email, j.GetNbSerieGagnee(), j.GetStatsTotal()[0], j.GetStatsTotal()[1], j.GetMoyenneStats()[0].ToString("0.00"), j.GetMoyenneStats()[1].ToString("0.00"), "Accepter");
            }
        }

        /// <summary>
        /// Affiche le choix des joueurs à afficher en fonction de la comboBox 
        /// </summary>
        private void cbxInfosJoueur_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxInfosJoueur.SelectedItem)
            {
                case "Joueurs actuels":
                    ChargeJoueursActuels();
                    break;
                case "Anciens joueurs":
                    ChargeAnciensJoueurs();
                    break;
                case "Joueurs en attente":
                    ChargeJoueursEnAttente();
                    break;
            }
        }

        /// <summary>
        /// Effectue l'action choisie sur le joueur séléctionné en fonction du bouton afficher 
        /// </summary>
        private void dgvAffichage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAffichage.Columns.Count - 1 && e.RowIndex < JoueursAffiches.Count && e.RowIndex != -1)
            {
                Joueur joueurSelectionne = JoueursAffiches[e.RowIndex];

                if (joueurSelectionne != null)
                {
                    switch (cbxInfosJoueur.SelectedItem)
                    {
                        case "Joueurs actuels":
                            Equipe.SupprimerJoueur(joueurSelectionne);
                            ChargeJoueursActuels();
                            break;
                        case "Joueurs en attente":
                            Equipe.AccepterJoueur(joueurSelectionne);
                            ChargeJoueursEnAttente();
                            break;
                    }
                }

            }
        }
    }
}
