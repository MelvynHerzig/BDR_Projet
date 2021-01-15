
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.mstrpAdmin = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModeChoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAjoutTournoi = new System.Windows.Forms.ToolStripMenuItem();
            this.lbxTournament = new System.Windows.Forms.ListBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.wbrTreeStruct = new System.Windows.Forms.WebBrowser();
            this.btnProperties = new System.Windows.Forms.Button();
            this.gbxStatistiques = new System.Windows.Forms.GroupBox();
            this.tbxEquipesJoueur = new System.Windows.Forms.TextBox();
            this.lblEquipeJoueur = new System.Windows.Forms.Label();
            this.tbxVitesseInscription = new System.Windows.Forms.TextBox();
            this.lblVitesseInscription = new System.Windows.Forms.Label();
            this.cbxStatVitesseInscription = new System.Windows.Forms.ComboBox();
            this.mstrpAdmin.SuspendLayout();
            this.gbxStatistiques.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstrpAdmin
            // 
            this.mstrpAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiAjoutTournoi});
            this.mstrpAdmin.Location = new System.Drawing.Point(0, 0);
            this.mstrpAdmin.Name = "mstrpAdmin";
            this.mstrpAdmin.Size = new System.Drawing.Size(776, 24);
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
            this.tsmiModeChoice.Size = new System.Drawing.Size(155, 22);
            this.tsmiModeChoice.Text = "Choix du mode";
            this.tsmiModeChoice.Click += new System.EventHandler(this.tsmiModeChoice_Click);
            // 
            // tsmiAjoutTournoi
            // 
            this.tsmiAjoutTournoi.Name = "tsmiAjoutTournoi";
            this.tsmiAjoutTournoi.Size = new System.Drawing.Size(117, 20);
            this.tsmiAjoutTournoi.Text = "Ajouter un tournoi";
            this.tsmiAjoutTournoi.Click += new System.EventHandler(this.tsmiAjoutTournoi_Click);
            // 
            // lbxTournament
            // 
            this.lbxTournament.FormattingEnabled = true;
            this.lbxTournament.Location = new System.Drawing.Point(12, 67);
            this.lbxTournament.Name = "lbxTournament";
            this.lbxTournament.Size = new System.Drawing.Size(239, 290);
            this.lbxTournament.TabIndex = 1;
            this.lbxTournament.SelectedIndexChanged += new System.EventHandler(this.lbxTournament_SelectedIndexChanged);
            // 
            // cbxFilter
            // 
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.Location = new System.Drawing.Point(12, 40);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(239, 21);
            this.cbxFilter.TabIndex = 2;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 24);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(129, 13);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Filtre par état du tournois :";
            // 
            // wbrTreeStruct
            // 
            this.wbrTreeStruct.Location = new System.Drawing.Point(282, 67);
            this.wbrTreeStruct.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrTreeStruct.Name = "wbrTreeStruct";
            this.wbrTreeStruct.Size = new System.Drawing.Size(487, 506);
            this.wbrTreeStruct.TabIndex = 4;
            // 
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(661, 32);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(108, 29);
            this.btnProperties.TabIndex = 5;
            this.btnProperties.Text = "Propriétés";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // gbxStatistiques
            // 
            this.gbxStatistiques.Controls.Add(this.tbxEquipesJoueur);
            this.gbxStatistiques.Controls.Add(this.lblEquipeJoueur);
            this.gbxStatistiques.Controls.Add(this.tbxVitesseInscription);
            this.gbxStatistiques.Controls.Add(this.lblVitesseInscription);
            this.gbxStatistiques.Controls.Add(this.cbxStatVitesseInscription);
            this.gbxStatistiques.Location = new System.Drawing.Point(12, 371);
            this.gbxStatistiques.Name = "gbxStatistiques";
            this.gbxStatistiques.Size = new System.Drawing.Size(239, 202);
            this.gbxStatistiques.TabIndex = 6;
            this.gbxStatistiques.TabStop = false;
            this.gbxStatistiques.Text = "Statistiques";
            // 
            // tbxEquipesJoueur
            // 
            this.tbxEquipesJoueur.Enabled = false;
            this.tbxEquipesJoueur.Location = new System.Drawing.Point(9, 144);
            this.tbxEquipesJoueur.Name = "tbxEquipesJoueur";
            this.tbxEquipesJoueur.ReadOnly = true;
            this.tbxEquipesJoueur.Size = new System.Drawing.Size(195, 20);
            this.tbxEquipesJoueur.TabIndex = 4;
            // 
            // lblEquipeJoueur
            // 
            this.lblEquipeJoueur.AutoSize = true;
            this.lblEquipeJoueur.Location = new System.Drawing.Point(6, 115);
            this.lblEquipeJoueur.Name = "lblEquipeJoueur";
            this.lblEquipeJoueur.Size = new System.Drawing.Size(155, 26);
            this.lblEquipeJoueur.TabIndex = 3;
            this.lblEquipeJoueur.Text = "Moyenne du nombre d\'équipes \r\npar joueur :\r\n";
            // 
            // tbxVitesseInscription
            // 
            this.tbxVitesseInscription.Enabled = false;
            this.tbxVitesseInscription.Location = new System.Drawing.Point(9, 67);
            this.tbxVitesseInscription.Name = "tbxVitesseInscription";
            this.tbxVitesseInscription.ReadOnly = true;
            this.tbxVitesseInscription.Size = new System.Drawing.Size(195, 20);
            this.tbxVitesseInscription.TabIndex = 2;
            // 
            // lblVitesseInscription
            // 
            this.lblVitesseInscription.AutoSize = true;
            this.lblVitesseInscription.Location = new System.Drawing.Point(6, 35);
            this.lblVitesseInscription.Name = "lblVitesseInscription";
            this.lblVitesseInscription.Size = new System.Drawing.Size(150, 26);
            this.lblVitesseInscription.TabIndex = 1;
            this.lblVitesseInscription.Text = "Moyenne vitesse d\'inscriptions\r\npour un tournoi de :";
            // 
            // cbxStatVitesseInscription
            // 
            this.cbxStatVitesseInscription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatVitesseInscription.FormattingEnabled = true;
            this.cbxStatVitesseInscription.Location = new System.Drawing.Point(162, 40);
            this.cbxStatVitesseInscription.Name = "cbxStatVitesseInscription";
            this.cbxStatVitesseInscription.Size = new System.Drawing.Size(42, 21);
            this.cbxStatVitesseInscription.TabIndex = 0;
            this.cbxStatVitesseInscription.SelectedIndexChanged += new System.EventHandler(this.cbxStatVitesseInscription_SelectedIndexChanged);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 585);
            this.Controls.Add(this.gbxStatistiques);
            this.Controls.Add(this.btnProperties);
            this.Controls.Add(this.wbrTreeStruct);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.lbxTournament);
            this.Controls.Add(this.mstrpAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mstrpAdmin;
            this.MaximizeBox = false;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administration";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.mstrpAdmin.ResumeLayout(false);
            this.mstrpAdmin.PerformLayout();
            this.gbxStatistiques.ResumeLayout(false);
            this.gbxStatistiques.PerformLayout();
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
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.ToolStripMenuItem tsmiAjoutTournoi;
        private System.Windows.Forms.GroupBox gbxStatistiques;
        private System.Windows.Forms.ComboBox cbxStatVitesseInscription;
        private System.Windows.Forms.TextBox tbxEquipesJoueur;
        private System.Windows.Forms.Label lblEquipeJoueur;
        private System.Windows.Forms.TextBox tbxVitesseInscription;
        private System.Windows.Forms.Label lblVitesseInscription;
    }
}