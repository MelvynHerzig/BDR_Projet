using GestionnaireTournois.Models;
using GestionnaireTournois.Views.Admin;
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
        private Joueur joueur;
        public Tournoi Tournoi { get => tournoi; set => tournoi = value; }
        public Joueur Joueur { get => joueur; set => joueur = value; }

        public frmTournoi(Joueur joueur, Tournoi tournoi)
        {
            Tournoi = tournoi;
            Joueur = joueur;
            InitializeComponent();
        }

        /// <summary>
        /// Charge le formulaire et conditionne les champs avec des valeurs de base
        /// </summary>
        private void frmTournoi_Load(object sender, EventArgs e)
        {
            GenererArborescence();
            wbrTreeStruct.Document.Click += Document_Click;

            Equipe equipe = Joueur.GetEquipeDurantTournoi(Tournoi);

            if (equipe != null)
            {
                gbxEquipe.Text += " ( " + equipe.Nom + " )";

                List<Joueur> joueurs = equipe.GetJoueursFromTournoi(Tournoi);

                if (joueurs.Count != 0)
                {
                    lblJ1.Text = joueurs[0].Pseudo;
                    lblJ2.Text = joueurs[1].Pseudo;
                    lblJ3.Text = joueurs[2].Pseudo;
                }
            }

            if(Joueur.Id == Joueur.GetEquipeDurantTournoi(Tournoi).IdResponsable && Tournoi.DateHeureFin == DateTime.MinValue)
            {
                btnAbandonnerTournoi.Visible = true;
            }

            if (Tournoi.EstEnAttente())
            {
                btnAbandonnerTournoi.Text = "Se désinscrire";
            }
            else
            {
                btnAbandonnerTournoi.Text = "Abandonner";
            }
            

        }

        /// <summary>
        /// Affiche la série sélectionné dans l'arbre de tournoi dans un nouveau formulaire
        /// </summary>
        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument doc = (HtmlDocument)sender;

            HtmlElement elem = doc.ActiveElement;

            if (elem.InnerHtml == "Voir")
            {
                Console.WriteLine(elem.GetAttribute("name"));
                string[] split = elem.GetAttribute("name").ToString().Split(';');

                Tournoi tournoi = Tournoi.GetTournoiById(Convert.ToInt32(split[0]));

                Tour tour = tournoi.GetTourByNo(Convert.ToInt32(split[1]));

                Serie s = tour.GetSerieById(Convert.ToInt32(split[2]));

                frmSerie frm = new frmSerie(s, false);
                frm.ShowDialog();
            }
        }


        /// <summary>
        /// L'équipe du responsable actuellement connecté abandonne le tournoi affiché
        /// </summary>
        private void btnAbandonnerTournoi_Click(object sender, EventArgs e)
        {
            Joueur.GetEquipeDurantTournoi(Tournoi).AbandonnerTournoi(Tournoi);
            GenererArborescence();
        }

        /// <summary>
        /// Génère l'arbre de tournoi au niveau graphique
        /// </summary>
        private void GenererArborescence()
        {
            wbrTreeStruct.DocumentText = TournamentArborescenceGenerator.Generate(Tournoi, "Voir");
        }
    }
}
