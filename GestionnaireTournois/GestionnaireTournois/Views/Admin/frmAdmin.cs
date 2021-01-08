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

namespace GestionnaireTournois
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void tsmiModeChoice_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            cbxFilter.SelectedIndex = 0;

            wbrTreeStruct.DocumentText = "";
            wbrTreeStruct.Document.Click += Document_Click;

        }



        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument doc = (HtmlDocument)sender;

            HtmlElement elem = doc.ActiveElement;

            if(elem.InnerHtml == "Editer")
            {
                Console.WriteLine(elem.GetAttribute("name"));
                string[] split = elem.GetAttribute("name").ToString().Split(';');
                Serie s = DataBaseConnector.GetSerieById(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));

                frmEditionSerie frm = new frmEditionSerie(s);
                frm.ShowDialog();
            }
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxTournament.Items.Clear();

            string condition = "";

            switch(cbxFilter.SelectedItem.ToString())
            {

                case "En attente":
                    condition = "WHERE Tournoi.dateHeureDebut > NOW() AND Tournoi.dateHeureFin IS NULL";
                    break;
                case "En cours":
                    condition = "WHERE Tournoi.dateHeureDebut <= NOW() AND Tournoi.dateHeureFin IS NULL";
                    break;
                case "Terminé":
                    condition = "WHERE Tournoi.dateHeureDebut <= NOW() AND Tournoi.dateHeureFin IS NOT NULL AND Tournoi.dateHeureFin <> Tournoi.dateHeureDebut";
                    break;
                case "Annulé":
                    condition = "WHERE Tournoi.dateHeureDebut = Tournoi.dateHeureFin";
                    break;
            }


            foreach (Tournoi t in DataBaseConnector.GetTournois(condition))
            {
                lbxTournament.Items.Add(t);
            }
        }

        private void lbxTournament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbxTournament.SelectedItem != null)
                wbrTreeStruct.DocumentText = TournamentArborescenceGenerator.Generate((Tournoi)lbxTournament.SelectedItem, "Editer");
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            Tournoi t = (Tournoi)lbxTournament.SelectedItem;

            frmTournamentProperties properties = new frmTournamentProperties(t.Id);

            properties.ShowDialog();

            lbxTournament.SelectedIndex = lbxTournament.SelectedIndex;
        }

        private void tsmiAjoutTournoi_Click(object sender, EventArgs e)
        {
            frmAjoutTournoi frm = new frmAjoutTournoi();

            frm.ShowDialog();


        }
    }
}


// https://stackoverflow.com/questions/9732347/c-sharp-how-to-generate-a-tournament-bracket-html-table
// https://stackoverflow.com/questions/15901997/c-sharp-reach-click-button-in-webbrowser