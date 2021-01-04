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

            lbxTournament.SelectedIndex = 0;

        }


    
        private void wbrTreeStruct_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbrTreeStruct.Document.Click += Document_Click;
        }

        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument doc = (HtmlDocument)sender;

            HtmlElement elem = doc.ActiveElement;

            if(elem.Name == "edit")
            {
                // Do something
            }
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxTournament.Items.Clear();
            foreach (Tournoi t in DataBaseConnector.GetTournois())
            {
                lbxTournament.Items.Add(t);
            }
        }

        private void lbxTournament_SelectedIndexChanged(object sender, EventArgs e)
        {
            wbrTreeStruct.DocumentText = TournamentArborescenceGenerator.Generate((Tournoi)lbxTournament.SelectedItem, "Editer");
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            Tournoi t = (Tournoi)lbxTournament.SelectedItem;

            frmTournamentProperties properties = new frmTournamentProperties(t.Id);

            properties.ShowDialog();

            lbxTournament.SelectedIndex = lbxTournament.SelectedIndex;
        }
    }
}


// https://stackoverflow.com/questions/9732347/c-sharp-how-to-generate-a-tournament-bracket-html-table
// https://stackoverflow.com/questions/15901997/c-sharp-reach-click-button-in-webbrowser