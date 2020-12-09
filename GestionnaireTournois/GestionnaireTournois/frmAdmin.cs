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

            wbrTreeStruct.DocumentText = TournamentArborescenceGenerator.Generate(4, "Editer");
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
    }
}


// https://stackoverflow.com/questions/9732347/c-sharp-how-to-generate-a-tournament-bracket-html-table
// https://stackoverflow.com/questions/15901997/c-sharp-reach-click-button-in-webbrowser