﻿/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : frmAjoutTounoi.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Créer un nouveau tournoi

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
    public partial class frmAjoutTournoi : Form
    {
        public frmAjoutTournoi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Créer un nouveau tournoi avec les valeurs des champs correspondants
        /// </summary>
        private void btnAjouterTournoi_Click(object sender, EventArgs e)
        {

            Tournoi t = new Tournoi(0, dtpDateDebut.Value.Date + dtpHeureDebut.Value.TimeOfDay, DateTime.Now, tbxNomTournoi.Text, (int)nudEquipes.Value, 0, 0);

            Tournoi.Ajouter(t);

            this.Close();
        }
    }
}
