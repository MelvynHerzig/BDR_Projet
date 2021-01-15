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
    public partial class frmSerie : Form
    {

        private Serie serie;

        private List<List<List<TextBox>>> equipeJoueurTextBoxes;
        public Serie Serie { get => serie; set => serie = value; }
        public List<List<List<TextBox>>> EquipeJoueurTextBoxes { get => equipeJoueurTextBoxes; set => equipeJoueurTextBoxes = value; }

        public frmSerie(Serie serie, bool editON)
        {
            Serie = serie;


            InitializeComponent();
            
            btnAjoutMatch.Visible = editON;
            btnModifier.Visible = editON;

            
        }

        private void btnAjoutMatch_Click(object sender, EventArgs e)
        {
            List<JoueurMatchData> datas = CreationInfosMatch(lbxMatchs.Items.Count + 1);
            Serie.AjouterMatch(datas);
            ChargeMatchs();

        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            List<JoueurMatchData> datas = CreationInfosMatch(((Match)lbxMatchs.SelectedItem).Id);
            Serie.ModifierMatch(datas);
            ChargeMatchs();
        }
        private void frmEditionSerie_Load(object sender, EventArgs e)
        {

            ChargeMatchs();

            List<Equipe> equipes = Serie.GetEquipes();
            gbxEquipe1.Text = equipes[0].Nom;
            gbxEquipe2.Text = equipes[1].Nom;


            List<TextBox> e1j1 = new List<TextBox>() { tbxE1J1, tbxE1J1Buts, tbxE1J1Arrets };
            List<TextBox> e1j2 = new List<TextBox>() { tbxE1J2, tbxE1J2Buts, tbxE1J2Arrets };
            List<TextBox> e1j3 = new List<TextBox>() { tbxE1J3, tbxE1J3Buts, tbxE1J3Arrets };
            List<TextBox> e2j1 = new List<TextBox>() { tbxE2J1, tbxE2J1Buts, tbxE2J1Arrets };
            List<TextBox> e2j2 = new List<TextBox>() { tbxE2J2, tbxE2J2Buts, tbxE2J2Arrets };
            List<TextBox> e2j3 = new List<TextBox>() { tbxE2J3, tbxE2J3Buts, tbxE2J3Arrets };

            List<List<TextBox>> e1 = new List<List<TextBox>>() { e1j1, e1j2, e1j3 };
            List<List<TextBox>> e2 = new List<List<TextBox>>() { e2j1, e2j2, e2j3 };

            EquipeJoueurTextBoxes = new List<List<List<TextBox>>>() { e1, e2 };

            Tournoi tournoi = Tournoi.GetTournoiById(Serie.IdTournoi);

            List<Joueur> joueursE1 = equipes[0].GetJoueursFromTournoi(tournoi);
            List<Joueur> joueursE2 = equipes[1].GetJoueursFromTournoi(tournoi);

            for(int noEquipe = 0;noEquipe < equipes.Count; ++noEquipe)
            {
                List<Joueur> joueurs = equipes[noEquipe].GetJoueursFromTournoi(tournoi);
                for(int noJoueur = 0; noJoueur < joueurs.Count; ++noJoueur)
                {
                    LoadInformationsJoueurs(joueurs[noJoueur], null, EquipeJoueurTextBoxes[noEquipe][noJoueur]);
                }
            }

            foreach (List<List<TextBox>> equipesTextbox in equipeJoueurTextBoxes)
            {
                foreach (List<TextBox> joueursTextBox in equipesTextbox)
                {
                    joueursTextBox[1].Enabled = btnAjoutMatch.Visible;
                    joueursTextBox[1].ReadOnly = !btnAjoutMatch.Visible;

                    joueursTextBox[2].Enabled = btnAjoutMatch.Visible;
                    joueursTextBox[2].ReadOnly = !btnAjoutMatch.Visible;
                }
            }
        }

        private void ChargeMatchs()
        {
            lbxMatchs.Items.Clear();
            lbxMatchs.Items.AddRange(Serie.GetMatches().ToArray());
        }

        private void lbxMatchs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatch((Match)lbxMatchs.SelectedItem);
        }

        private List<JoueurMatchData> CreationInfosMatch(int idMatch)
        {
            List<JoueurMatchData> datas = new List<JoueurMatchData>();

            #region Equipe 1
            {

                JoueurMatchData j1 = new JoueurMatchData((int)EquipeJoueurTextBoxes[0][0][0].Tag, idMatch, Serie.Id, Serie.NoTour, Serie.IdTournoi,
                                                         EquipeJoueurTextBoxes[0][0][1].Text,
                                                         EquipeJoueurTextBoxes[0][0][2].Text);
                JoueurMatchData j2 = new JoueurMatchData((int)EquipeJoueurTextBoxes[0][1][0].Tag, idMatch, Serie.Id, Serie.NoTour, Serie.IdTournoi,
                                                         EquipeJoueurTextBoxes[0][1][1].Text,
                                                         EquipeJoueurTextBoxes[0][1][2].Text);
                JoueurMatchData j3 = new JoueurMatchData((int)EquipeJoueurTextBoxes[0][2][0].Tag, idMatch, Serie.Id, Serie.NoTour, Serie.IdTournoi,
                                                         EquipeJoueurTextBoxes[0][2][1].Text,
                                                         EquipeJoueurTextBoxes[0][2][2].Text);

                datas.Add(j1);
                datas.Add(j2);
                datas.Add(j3);
            }
            #endregion

            #region Equipe 2
            {
                JoueurMatchData j1 = new JoueurMatchData((int)EquipeJoueurTextBoxes[1][0][0].Tag, idMatch, Serie.Id, Serie.NoTour, Serie.IdTournoi,
                                                         EquipeJoueurTextBoxes[1][0][1].Text,
                                                         EquipeJoueurTextBoxes[1][0][2].Text);
                JoueurMatchData j2 = new JoueurMatchData((int)EquipeJoueurTextBoxes[1][1][0].Tag, idMatch, Serie.Id, Serie.NoTour, Serie.IdTournoi,
                                                         EquipeJoueurTextBoxes[1][1][1].Text,
                                                         EquipeJoueurTextBoxes[1][1][2].Text);
                JoueurMatchData j3 = new JoueurMatchData((int)EquipeJoueurTextBoxes[1][2][0].Tag, idMatch, Serie.Id, Serie.NoTour, Serie.IdTournoi,
                                                         EquipeJoueurTextBoxes[1][2][1].Text,
                                                         EquipeJoueurTextBoxes[1][2][2].Text);

                datas.Add(j1);
                datas.Add(j2);
                datas.Add(j3);
            }
            #endregion

            return datas;
        }

        private void LoadMatch(Match m)
        {
            if (m == null) return;
            List<Equipe> equipes = Serie.GetEquipes();

            List<Joueur> joueurs;

            Tournoi tournoi = Tournoi.GetTournoiById(m.IdTournoi);

            #region Equipe 1

            joueurs = equipes[0].GetJoueursFromTournoi(Tournoi.GetTournoiById(Serie.IdTournoi));
            LoadInformationsJoueurs(joueurs[0], m, EquipeJoueurTextBoxes[0][0]);
            LoadInformationsJoueurs(joueurs[1], m, EquipeJoueurTextBoxes[0][1]);
            LoadInformationsJoueurs(joueurs[2], m, EquipeJoueurTextBoxes[0][2]);

            #endregion

            #region Equipe 2

            joueurs = equipes[1].GetJoueursFromTournoi(Tournoi.GetTournoiById(Serie.IdTournoi));
            LoadInformationsJoueurs(joueurs[0], m, EquipeJoueurTextBoxes[1][0]);
            LoadInformationsJoueurs(joueurs[1], m, EquipeJoueurTextBoxes[1][1]);
            LoadInformationsJoueurs(joueurs[2], m, EquipeJoueurTextBoxes[1][2]);

            #endregion
        }

        private void LoadInformationsJoueurs(Joueur joueur, Match match, List<TextBox> textBoxes)
        {
            textBoxes[0].Text = joueur.Pseudo;
            textBoxes[0].Tag = joueur.Id;


            if (match != null)
            {
                int[] data = match.GetDataJoueur(joueur);

                textBoxes[1].Text = data[0].ToString();
                textBoxes[2].Text = data[1].ToString();
            }
        }
    }
}
