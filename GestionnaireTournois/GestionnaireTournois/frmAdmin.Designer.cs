
namespace GestionnaireTournois
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mstrpAdmin = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModeChoice = new System.Windows.Forms.ToolStripMenuItem();
            this.lbxTournament = new System.Windows.Forms.ListBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.wbrTreeStruct = new System.Windows.Forms.WebBrowser();
            this.mstrpAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstrpAdmin
            // 
            this.mstrpAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.mstrpAdmin.Location = new System.Drawing.Point(0, 0);
            this.mstrpAdmin.Name = "mstrpAdmin";
            this.mstrpAdmin.Size = new System.Drawing.Size(862, 24);
            this.mstrpAdmin.TabIndex = 0;
            this.mstrpAdmin.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiModeChoice});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(54, 20);
            this.tsmiFile.Text = "Fichier";
            // 
            // tsmiModeChoice
            // 
            this.tsmiModeChoice.Name = "tsmiModeChoice";
            this.tsmiModeChoice.Size = new System.Drawing.Size(156, 22);
            this.tsmiModeChoice.Text = "Choix du mode";
            this.tsmiModeChoice.Click += new System.EventHandler(this.tsmiModeChoice_Click);
            // 
            // lbxTournament
            // 
            this.lbxTournament.FormattingEnabled = true;
            this.lbxTournament.Location = new System.Drawing.Point(12, 128);
            this.lbxTournament.Name = "lbxTournament";
            this.lbxTournament.Size = new System.Drawing.Size(239, 498);
            this.lbxTournament.TabIndex = 1;
            // 
            // cbxFilter
            // 
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.Items.AddRange(new object[] {
            "Tous",
            "En attente",
            "En cours",
            "Terminé",
            "Annulé"});
            this.cbxFilter.Location = new System.Drawing.Point(12, 101);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(239, 21);
            this.cbxFilter.TabIndex = 2;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 85);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(129, 13);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Filtre par état du tournois :";
            // 
            // wbrTreeStruct
            // 
            this.wbrTreeStruct.Location = new System.Drawing.Point(347, 128);
            this.wbrTreeStruct.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrTreeStruct.Name = "wbrTreeStruct";
            this.wbrTreeStruct.Size = new System.Drawing.Size(487, 498);
            this.wbrTreeStruct.TabIndex = 4;
            this.wbrTreeStruct.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbrTreeStruct_DocumentCompleted);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 646);
            this.Controls.Add(this.wbrTreeStruct);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.lbxTournament);
            this.Controls.Add(this.mstrpAdmin);
            this.MainMenuStrip = this.mstrpAdmin;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.mstrpAdmin.ResumeLayout(false);
            this.mstrpAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstrpAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiModeChoice;
        private System.Windows.Forms.ListBox lbxTournament;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.WebBrowser wbrTreeStruct;
    }
}