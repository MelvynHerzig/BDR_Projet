
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
            this.lblId = new System.Windows.Forms.Label();
            this.gbxInfos = new System.Windows.Forms.GroupBox();
            this.tbxMaxJoueurs = new System.Windows.Forms.TextBox();
            this.lblNombreMaxJoueurs = new System.Windows.Forms.Label();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gbxStatistiques = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.gbxTours = new System.Windows.Forms.GroupBox();
            this.btnSaveTours = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoTour = new System.Windows.Forms.Label();
            this.tbxDateDebut = new System.Windows.Forms.TextBox();
            this.tbxDateFin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.gbxInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbxTours.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(90, 28);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(25, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id : ";
            // 
            // gbxInfos
            // 
            this.gbxInfos.Controls.Add(this.btnSaveInfo);
            this.gbxInfos.Controls.Add(this.tbxDateFin);
            this.gbxInfos.Controls.Add(this.tbxDateDebut);
            this.gbxInfos.Controls.Add(this.tbxMaxJoueurs);
            this.gbxInfos.Controls.Add(this.lblNombreMaxJoueurs);
            this.gbxInfos.Controls.Add(this.lblDateFin);
            this.gbxInfos.Controls.Add(this.lblDateDebut);
            this.gbxInfos.Controls.Add(this.tbxName);
            this.gbxInfos.Controls.Add(this.tbxId);
            this.gbxInfos.Controls.Add(this.lblName);
            this.gbxInfos.Controls.Add(this.lblId);
            this.gbxInfos.Location = new System.Drawing.Point(12, 12);
            this.gbxInfos.Name = "gbxInfos";
            this.gbxInfos.Size = new System.Drawing.Size(264, 220);
            this.gbxInfos.TabIndex = 1;
            this.gbxInfos.TabStop = false;
            this.gbxInfos.Text = "Informations sur le tournoi";
            // 
            // tbxMaxJoueurs
            // 
            this.tbxMaxJoueurs.Enabled = false;
            this.tbxMaxJoueurs.Location = new System.Drawing.Point(128, 153);
            this.tbxMaxJoueurs.Name = "tbxMaxJoueurs";
            this.tbxMaxJoueurs.ReadOnly = true;
            this.tbxMaxJoueurs.Size = new System.Drawing.Size(117, 20);
            this.tbxMaxJoueurs.TabIndex = 13;
            // 
            // lblNombreMaxJoueurs
            // 
            this.lblNombreMaxJoueurs.AutoSize = true;
            this.lblNombreMaxJoueurs.Location = new System.Drawing.Point(6, 156);
            this.lblNombreMaxJoueurs.Name = "lblNombreMaxJoueurs";
            this.lblNombreMaxJoueurs.Size = new System.Drawing.Size(109, 13);
            this.lblNombreMaxJoueurs.TabIndex = 12;
            this.lblNombreMaxJoueurs.Text = "Nombre joueurs max :";
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Location = new System.Drawing.Point(65, 123);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(50, 13);
            this.lblDateFin.TabIndex = 10;
            this.lblDateFin.Text = "Date fin :";
            this.lblDateFin.Visible = false;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Location = new System.Drawing.Point(49, 97);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(66, 13);
            this.lblDateDebut.TabIndex = 4;
            this.lblDateDebut.Text = "Date début :";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(128, 55);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(117, 20);
            this.tbxName.TabIndex = 3;
            // 
            // tbxId
            // 
            this.tbxId.Enabled = false;
            this.tbxId.Location = new System.Drawing.Point(128, 25);
            this.tbxId.Name = "tbxId";
            this.tbxId.ReadOnly = true;
            this.tbxId.Size = new System.Drawing.Size(117, 20);
            this.tbxId.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(80, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nom :";
            // 
            // gbxStatistiques
            // 
            this.gbxStatistiques.Location = new System.Drawing.Point(300, 12);
            this.gbxStatistiques.Name = "gbxStatistiques";
            this.gbxStatistiques.Size = new System.Drawing.Size(264, 220);
            this.gbxStatistiques.TabIndex = 2;
            this.gbxStatistiques.TabStop = false;
            this.gbxStatistiques.Text = " Statistiques";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(127, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(128, 50);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(117, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // gbxTours
            // 
            this.gbxTours.Controls.Add(this.btnSaveTours);
            this.gbxTours.Controls.Add(this.label2);
            this.gbxTours.Controls.Add(this.lblNoTour);
            this.gbxTours.Controls.Add(this.comboBox1);
            this.gbxTours.Controls.Add(this.numericUpDown1);
            this.gbxTours.Location = new System.Drawing.Point(12, 248);
            this.gbxTours.Name = "gbxTours";
            this.gbxTours.Size = new System.Drawing.Size(264, 115);
            this.gbxTours.TabIndex = 5;
            this.gbxTours.TabStop = false;
            this.gbxTours.Text = "Propriétés des tours";
            // 
            // btnSaveTours
            // 
            this.btnSaveTours.Location = new System.Drawing.Point(16, 85);
            this.btnSaveTours.Name = "btnSaveTours";
            this.btnSaveTours.Size = new System.Drawing.Size(229, 25);
            this.btnSaveTours.TabIndex = 6;
            this.btnSaveTours.Text = "Enregistrer";
            this.btnSaveTours.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Longueur des séries :";
            // 
            // lblNoTour
            // 
            this.lblNoTour.AutoSize = true;
            this.lblNoTour.Location = new System.Drawing.Point(35, 18);
            this.lblNoTour.Name = "lblNoTour";
            this.lblNoTour.Size = new System.Drawing.Size(86, 13);
            this.lblNoTour.TabIndex = 5;
            this.lblNoTour.Text = "Numéro du tour :";
            // 
            // tbxDateDebut
            // 
            this.tbxDateDebut.Enabled = false;
            this.tbxDateDebut.Location = new System.Drawing.Point(128, 94);
            this.tbxDateDebut.Name = "tbxDateDebut";
            this.tbxDateDebut.ReadOnly = true;
            this.tbxDateDebut.Size = new System.Drawing.Size(117, 20);
            this.tbxDateDebut.TabIndex = 14;
            // 
            // tbxDateFin
            // 
            this.tbxDateFin.Enabled = false;
            this.tbxDateFin.Location = new System.Drawing.Point(128, 120);
            this.tbxDateFin.Name = "tbxDateFin";
            this.tbxDateFin.ReadOnly = true;
            this.tbxDateFin.Size = new System.Drawing.Size(117, 20);
            this.tbxDateFin.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(300, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 115);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prix";
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Location = new System.Drawing.Point(16, 186);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(229, 25);
            this.btnSaveInfo.TabIndex = 7;
            this.btnSaveInfo.Text = "Enregistrer";
            this.btnSaveInfo.UseVisualStyleBackColor = true;
            // 
            // frmTournamentProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 375);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxTours);
            this.Controls.Add(this.gbxStatistiques);
            this.Controls.Add(this.gbxInfos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmTournamentProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Propriétés et statisques du tournoi";
            this.Load += new System.EventHandler(this.frmTournamentProperties_Load);
            this.gbxInfos.ResumeLayout(false);
            this.gbxInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbxTours.ResumeLayout(false);
            this.gbxTours.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbxStatistiques;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox gbxTours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoTour;
        private System.Windows.Forms.Button btnSaveTours;
        private System.Windows.Forms.TextBox tbxDateFin;
        private System.Windows.Forms.TextBox tbxDateDebut;
        private System.Windows.Forms.Button btnSaveInfo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}