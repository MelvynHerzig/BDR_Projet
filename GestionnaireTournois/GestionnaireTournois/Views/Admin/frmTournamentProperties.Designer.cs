
namespace GestionnaireTournois
{
    partial class frmTournamentProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTournamentProperties));
            this.lblId = new System.Windows.Forms.Label();
            this.gbxInfos = new System.Windows.Forms.GroupBox();
            this.lblHeureFin = new System.Windows.Forms.Label();
            this.lblHeureDebut = new System.Windows.Forms.Label();
            this.dtpHeureFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpHeureDebut = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.btnSupprimerTournoi = new System.Windows.Forms.Button();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.tbxMaxJoueurs = new System.Windows.Forms.TextBox();
            this.lblNombreMaxJoueurs = new System.Windows.Forms.Label();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbxTours = new System.Windows.Forms.ComboBox();
            this.nudLongueurSerie = new System.Windows.Forms.NumericUpDown();
            this.gbxTours = new System.Windows.Forms.GroupBox();
            this.btnSaveTours = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoTour = new System.Windows.Forms.Label();
            this.gbxPrix = new System.Windows.Forms.GroupBox();
            this.btn2emePrix = new System.Windows.Forms.Button();
            this.btn1erPrix = new System.Windows.Forms.Button();
            this.gbxEquipesInscrites = new System.Windows.Forms.GroupBox();
            this.lbxEquipesInscrites = new System.Windows.Forms.ListBox();
            this.btnRetirerEquipe = new System.Windows.Forms.Button();
            this.gbxInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurSerie)).BeginInit();
            this.gbxTours.SuspendLayout();
            this.gbxPrix.SuspendLayout();
            this.gbxEquipesInscrites.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(120, 34);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 16);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id : ";
            // 
            // gbxInfos
            // 
            this.gbxInfos.Controls.Add(this.lblHeureFin);
            this.gbxInfos.Controls.Add(this.lblHeureDebut);
            this.gbxInfos.Controls.Add(this.dtpHeureFin);
            this.gbxInfos.Controls.Add(this.dtpDateFin);
            this.gbxInfos.Controls.Add(this.dtpHeureDebut);
            this.gbxInfos.Controls.Add(this.dtpDateDebut);
            this.gbxInfos.Controls.Add(this.btnSupprimerTournoi);
            this.gbxInfos.Controls.Add(this.btnSaveInfo);
            this.gbxInfos.Controls.Add(this.tbxMaxJoueurs);
            this.gbxInfos.Controls.Add(this.lblNombreMaxJoueurs);
            this.gbxInfos.Controls.Add(this.lblDateFin);
            this.gbxInfos.Controls.Add(this.lblDateDebut);
            this.gbxInfos.Controls.Add(this.tbxName);
            this.gbxInfos.Controls.Add(this.tbxId);
            this.gbxInfos.Controls.Add(this.lblName);
            this.gbxInfos.Controls.Add(this.lblId);
            this.gbxInfos.Location = new System.Drawing.Point(16, 15);
            this.gbxInfos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxInfos.Name = "gbxInfos";
            this.gbxInfos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxInfos.Size = new System.Drawing.Size(352, 400);
            this.gbxInfos.TabIndex = 1;
            this.gbxInfos.TabStop = false;
            this.gbxInfos.Text = "Informations sur le tournoi";
            // 
            // lblHeureFin
            // 
            this.lblHeureFin.AutoSize = true;
            this.lblHeureFin.Location = new System.Drawing.Point(77, 225);
            this.lblHeureFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeureFin.Name = "lblHeureFin";
            this.lblHeureFin.Size = new System.Drawing.Size(67, 16);
            this.lblHeureFin.TabIndex = 21;
            this.lblHeureFin.Text = "Heure fin :";
            // 
            // lblHeureDebut
            // 
            this.lblHeureDebut.AutoSize = true;
            this.lblHeureDebut.Location = new System.Drawing.Point(56, 151);
            this.lblHeureDebut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeureDebut.Name = "lblHeureDebut";
            this.lblHeureDebut.Size = new System.Drawing.Size(88, 16);
            this.lblHeureDebut.TabIndex = 20;
            this.lblHeureDebut.Text = "Heure début :";
            // 
            // dtpHeureFin
            // 
            this.dtpHeureFin.Enabled = false;
            this.dtpHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHeureFin.Location = new System.Drawing.Point(171, 218);
            this.dtpHeureFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHeureFin.Name = "dtpHeureFin";
            this.dtpHeureFin.ShowUpDown = true;
            this.dtpHeureFin.Size = new System.Drawing.Size(156, 22);
            this.dtpHeureFin.TabIndex = 19;
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Enabled = false;
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFin.Location = new System.Drawing.Point(171, 186);
            this.dtpDateFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(156, 22);
            this.dtpDateFin.TabIndex = 18;
            // 
            // dtpHeureDebut
            // 
            this.dtpHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHeureDebut.Location = new System.Drawing.Point(171, 144);
            this.dtpHeureDebut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHeureDebut.Name = "dtpHeureDebut";
            this.dtpHeureDebut.ShowUpDown = true;
            this.dtpHeureDebut.Size = new System.Drawing.Size(156, 22);
            this.dtpHeureDebut.TabIndex = 17;
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDebut.Location = new System.Drawing.Point(169, 112);
            this.dtpDateDebut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(156, 22);
            this.dtpDateDebut.TabIndex = 8;
            // 
            // btnSupprimerTournoi
            // 
            this.btnSupprimerTournoi.Location = new System.Drawing.Point(21, 346);
            this.btnSupprimerTournoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSupprimerTournoi.Name = "btnSupprimerTournoi";
            this.btnSupprimerTournoi.Size = new System.Drawing.Size(305, 39);
            this.btnSupprimerTournoi.TabIndex = 16;
            this.btnSupprimerTournoi.Text = "Supprimer le tournoi";
            this.btnSupprimerTournoi.UseVisualStyleBackColor = true;
            this.btnSupprimerTournoi.Click += new System.EventHandler(this.btnSupprimerTournoi_Click);
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Location = new System.Drawing.Point(21, 299);
            this.btnSaveInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(305, 39);
            this.btnSaveInfo.TabIndex = 7;
            this.btnSaveInfo.Text = "Enregistrer les modifications";
            this.btnSaveInfo.UseVisualStyleBackColor = true;
            this.btnSaveInfo.Click += new System.EventHandler(this.btnSaveInfo_Click);
            // 
            // tbxMaxJoueurs
            // 
            this.tbxMaxJoueurs.Enabled = false;
            this.tbxMaxJoueurs.Location = new System.Drawing.Point(171, 258);
            this.tbxMaxJoueurs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxMaxJoueurs.Name = "tbxMaxJoueurs";
            this.tbxMaxJoueurs.ReadOnly = true;
            this.tbxMaxJoueurs.Size = new System.Drawing.Size(155, 22);
            this.tbxMaxJoueurs.TabIndex = 13;
            // 
            // lblNombreMaxJoueurs
            // 
            this.lblNombreMaxJoueurs.AutoSize = true;
            this.lblNombreMaxJoueurs.Location = new System.Drawing.Point(8, 262);
            this.lblNombreMaxJoueurs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreMaxJoueurs.Name = "lblNombreMaxJoueurs";
            this.lblNombreMaxJoueurs.Size = new System.Drawing.Size(138, 16);
            this.lblNombreMaxJoueurs.TabIndex = 12;
            this.lblNombreMaxJoueurs.Text = "Nombre joueurs max :";
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Location = new System.Drawing.Point(85, 193);
            this.lblDateFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(59, 16);
            this.lblDateFin.TabIndex = 10;
            this.lblDateFin.Text = "Date fin :";
            this.lblDateFin.Visible = false;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Location = new System.Drawing.Point(65, 119);
            this.lblDateDebut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(80, 16);
            this.lblDateDebut.TabIndex = 4;
            this.lblDateDebut.Text = "Date début :";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(171, 68);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(155, 22);
            this.tbxName.TabIndex = 3;
            // 
            // tbxId
            // 
            this.tbxId.Enabled = false;
            this.tbxId.Location = new System.Drawing.Point(171, 31);
            this.tbxId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxId.Name = "tbxId";
            this.tbxId.ReadOnly = true;
            this.tbxId.Size = new System.Drawing.Size(155, 22);
            this.tbxId.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(107, 71);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nom :";
            // 
            // cbxTours
            // 
            this.cbxTours.FormattingEnabled = true;
            this.cbxTours.Location = new System.Drawing.Point(20, 63);
            this.cbxTours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTours.Name = "cbxTours";
            this.cbxTours.Size = new System.Drawing.Size(156, 24);
            this.cbxTours.TabIndex = 3;
            this.cbxTours.SelectedIndexChanged += new System.EventHandler(this.cbxTours_SelectedIndexChanged);
            // 
            // nudLongueurSerie
            // 
            this.nudLongueurSerie.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLongueurSerie.Location = new System.Drawing.Point(20, 112);
            this.nudLongueurSerie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudLongueurSerie.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudLongueurSerie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLongueurSerie.Name = "nudLongueurSerie";
            this.nudLongueurSerie.Size = new System.Drawing.Size(156, 22);
            this.nudLongueurSerie.TabIndex = 4;
            this.nudLongueurSerie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLongueurSerie.ValueChanged += new System.EventHandler(this.nudLongueurSerie_ValueChanged);
            // 
            // gbxTours
            // 
            this.gbxTours.Controls.Add(this.btnSaveTours);
            this.gbxTours.Controls.Add(this.label2);
            this.gbxTours.Controls.Add(this.lblNoTour);
            this.gbxTours.Controls.Add(this.cbxTours);
            this.gbxTours.Controls.Add(this.nudLongueurSerie);
            this.gbxTours.Location = new System.Drawing.Point(412, 15);
            this.gbxTours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxTours.Name = "gbxTours";
            this.gbxTours.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxTours.Size = new System.Drawing.Size(199, 208);
            this.gbxTours.TabIndex = 5;
            this.gbxTours.TabStop = false;
            this.gbxTours.Text = "Propriétés des tours";
            // 
            // btnSaveTours
            // 
            this.btnSaveTours.Location = new System.Drawing.Point(20, 144);
            this.btnSaveTours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveTours.Name = "btnSaveTours";
            this.btnSaveTours.Size = new System.Drawing.Size(156, 31);
            this.btnSaveTours.TabIndex = 6;
            this.btnSaveTours.Text = "Enregistrer";
            this.btnSaveTours.UseVisualStyleBackColor = true;
            this.btnSaveTours.Click += new System.EventHandler(this.btnSaveTours_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Longueur des séries :";
            // 
            // lblNoTour
            // 
            this.lblNoTour.AutoSize = true;
            this.lblNoTour.Location = new System.Drawing.Point(17, 43);
            this.lblNoTour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoTour.Name = "lblNoTour";
            this.lblNoTour.Size = new System.Drawing.Size(105, 16);
            this.lblNoTour.TabIndex = 5;
            this.lblNoTour.Text = "Numéro du tour :";
            // 
            // gbxPrix
            // 
            this.gbxPrix.Controls.Add(this.btn2emePrix);
            this.gbxPrix.Controls.Add(this.btn1erPrix);
            this.gbxPrix.Location = new System.Drawing.Point(412, 240);
            this.gbxPrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxPrix.Name = "gbxPrix";
            this.gbxPrix.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxPrix.Size = new System.Drawing.Size(199, 175);
            this.gbxPrix.TabIndex = 7;
            this.gbxPrix.TabStop = false;
            this.gbxPrix.Text = "Prix";
            // 
            // btn2emePrix
            // 
            this.btn2emePrix.Location = new System.Drawing.Point(20, 103);
            this.btn2emePrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn2emePrix.Name = "btn2emePrix";
            this.btn2emePrix.Size = new System.Drawing.Size(156, 42);
            this.btn2emePrix.TabIndex = 1;
            this.btn2emePrix.Text = "Deuxième prix";
            this.btn2emePrix.UseVisualStyleBackColor = true;
            this.btn2emePrix.Click += new System.EventHandler(this.btn2emePrix_Click);
            // 
            // btn1erPrix
            // 
            this.btn1erPrix.Location = new System.Drawing.Point(20, 33);
            this.btn1erPrix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn1erPrix.Name = "btn1erPrix";
            this.btn1erPrix.Size = new System.Drawing.Size(156, 42);
            this.btn1erPrix.TabIndex = 0;
            this.btn1erPrix.Text = "Premier prix";
            this.btn1erPrix.UseVisualStyleBackColor = true;
            this.btn1erPrix.Click += new System.EventHandler(this.btn1erPrix_Click);
            // 
            // gbxEquipesInscrites
            // 
            this.gbxEquipesInscrites.Controls.Add(this.btnRetirerEquipe);
            this.gbxEquipesInscrites.Controls.Add(this.lbxEquipesInscrites);
            this.gbxEquipesInscrites.Location = new System.Drawing.Point(650, 15);
            this.gbxEquipesInscrites.Name = "gbxEquipesInscrites";
            this.gbxEquipesInscrites.Size = new System.Drawing.Size(200, 400);
            this.gbxEquipesInscrites.TabIndex = 9;
            this.gbxEquipesInscrites.TabStop = false;
            this.gbxEquipesInscrites.Text = "Équipes inscrites";
            // 
            // lbxEquipesInscrites
            // 
            this.lbxEquipesInscrites.FormattingEnabled = true;
            this.lbxEquipesInscrites.ItemHeight = 16;
            this.lbxEquipesInscrites.Location = new System.Drawing.Point(18, 43);
            this.lbxEquipesInscrites.Name = "lbxEquipesInscrites";
            this.lbxEquipesInscrites.Size = new System.Drawing.Size(162, 292);
            this.lbxEquipesInscrites.TabIndex = 0;
            // 
            // btnRetirerEquipe
            // 
            this.btnRetirerEquipe.Location = new System.Drawing.Point(18, 347);
            this.btnRetirerEquipe.Name = "btnRetirerEquipe";
            this.btnRetirerEquipe.Size = new System.Drawing.Size(162, 38);
            this.btnRetirerEquipe.TabIndex = 1;
            this.btnRetirerEquipe.Text = "Retirer équipe";
            this.btnRetirerEquipe.UseVisualStyleBackColor = true;
            this.btnRetirerEquipe.Click += new System.EventHandler(this.btnRetirerEquipe_Click);
            // 
            // frmTournamentProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 431);
            this.Controls.Add(this.gbxEquipesInscrites);
            this.Controls.Add(this.gbxPrix);
            this.Controls.Add(this.gbxTours);
            this.Controls.Add(this.gbxInfos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmTournamentProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Propriétés du tournoi";
            this.Load += new System.EventHandler(this.frmTournamentProperties_Load);
            this.gbxInfos.ResumeLayout(false);
            this.gbxInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongueurSerie)).EndInit();
            this.gbxTours.ResumeLayout(false);
            this.gbxTours.PerformLayout();
            this.gbxPrix.ResumeLayout(false);
            this.gbxEquipesInscrites.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.GroupBox gbxInfos;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxId;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.TextBox tbxMaxJoueurs;
        private System.Windows.Forms.Label lblNombreMaxJoueurs;
        private System.Windows.Forms.ComboBox cbxTours;
        private System.Windows.Forms.NumericUpDown nudLongueurSerie;
        private System.Windows.Forms.GroupBox gbxTours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoTour;
        private System.Windows.Forms.Button btnSaveTours;
        private System.Windows.Forms.Button btnSaveInfo;
        private System.Windows.Forms.GroupBox gbxPrix;
        private System.Windows.Forms.Button btn2emePrix;
        private System.Windows.Forms.Button btn1erPrix;
        private System.Windows.Forms.Button btnSupprimerTournoi;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.DateTimePicker dtpHeureDebut;
        private System.Windows.Forms.Label lblHeureFin;
        private System.Windows.Forms.Label lblHeureDebut;
        private System.Windows.Forms.DateTimePicker dtpHeureFin;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.GroupBox gbxEquipesInscrites;
        private System.Windows.Forms.Button btnRetirerEquipe;
        private System.Windows.Forms.ListBox lbxEquipesInscrites;
    }
}