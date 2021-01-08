
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.dtpDatedebut = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.tbxMaxJoueurs = new System.Windows.Forms.TextBox();
            this.lblNombreMaxJoueurs = new System.Windows.Forms.Label();
            this.gbxInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(106, 28);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(25, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id : ";
            // 
            // gbxInfos
            // 
            this.gbxInfos.Controls.Add(this.tbxMaxJoueurs);
            this.gbxInfos.Controls.Add(this.lblNombreMaxJoueurs);
            this.gbxInfos.Controls.Add(this.dtpDateFin);
            this.gbxInfos.Controls.Add(this.lblDateFin);
            this.gbxInfos.Controls.Add(this.dtpDatedebut);
            this.gbxInfos.Controls.Add(this.lblDateDebut);
            this.gbxInfos.Controls.Add(this.tbxName);
            this.gbxInfos.Controls.Add(this.tbxId);
            this.gbxInfos.Controls.Add(this.lblName);
            this.gbxInfos.Controls.Add(this.lblId);
            this.gbxInfos.Location = new System.Drawing.Point(12, 12);
            this.gbxInfos.Name = "gbxInfos";
            this.gbxInfos.Size = new System.Drawing.Size(264, 192);
            this.gbxInfos.TabIndex = 1;
            this.gbxInfos.TabStop = false;
            this.gbxInfos.Text = "Informations sur le tournoi";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(96, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nom :";
            // 
            // tbxId
            // 
            this.tbxId.Enabled = false;
            this.tbxId.Location = new System.Drawing.Point(142, 25);
            this.tbxId.Name = "tbxId";
            this.tbxId.ReadOnly = true;
            this.tbxId.Size = new System.Drawing.Size(103, 20);
            this.tbxId.TabIndex = 2;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(142, 55);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(103, 20);
            this.tbxName.TabIndex = 3;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Location = new System.Drawing.Point(65, 123);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(66, 13);
            this.lblDateDebut.TabIndex = 4;
            this.lblDateDebut.Text = "Date début :";
            // 
            // dtpDatedebut
            // 
            this.dtpDatedebut.CustomFormat = "dd.MM.yyyy";
            this.dtpDatedebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatedebut.Location = new System.Drawing.Point(142, 117);
            this.dtpDatedebut.MaxDate = new System.DateTime(2020, 11, 16, 14, 35, 27, 0);
            this.dtpDatedebut.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtpDatedebut.Name = "dtpDatedebut";
            this.dtpDatedebut.Size = new System.Drawing.Size(103, 20);
            this.dtpDatedebut.TabIndex = 9;
            this.dtpDatedebut.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.CustomFormat = "dd.MM.yyyy";
            this.dtpDateFin.Enabled = false;
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFin.Location = new System.Drawing.Point(142, 152);
            this.dtpDateFin.MaxDate = new System.DateTime(2020, 11, 16, 14, 35, 27, 0);
            this.dtpDateFin.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(103, 20);
            this.dtpDateFin.TabIndex = 11;
            this.dtpDateFin.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDateFin.Visible = false;
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Location = new System.Drawing.Point(81, 158);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(50, 13);
            this.lblDateFin.TabIndex = 10;
            this.lblDateFin.Text = "Date fin :";
            this.lblDateFin.Visible = false;
            // 
            // tbxMaxJoueurs
            // 
            this.tbxMaxJoueurs.Enabled = false;
            this.tbxMaxJoueurs.Location = new System.Drawing.Point(142, 81);
            this.tbxMaxJoueurs.Name = "tbxMaxJoueurs";
            this.tbxMaxJoueurs.ReadOnly = true;
            this.tbxMaxJoueurs.Size = new System.Drawing.Size(103, 20);
            this.tbxMaxJoueurs.TabIndex = 13;
            // 
            // lblNombreMaxJoueurs
            // 
            this.lblNombreMaxJoueurs.AutoSize = true;
            this.lblNombreMaxJoueurs.Location = new System.Drawing.Point(22, 84);
            this.lblNombreMaxJoueurs.Name = "lblNombreMaxJoueurs";
            this.lblNombreMaxJoueurs.Size = new System.Drawing.Size(109, 13);
            this.lblNombreMaxJoueurs.TabIndex = 12;
            this.lblNombreMaxJoueurs.Text = "Nombre joueurs max :";
            // 
            // frmTournamentProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 450);
            this.Controls.Add(this.gbxInfos);
            this.Name = "frmTournamentProperties";
            this.Text = "frmTournamentProperties";
            this.gbxInfos.ResumeLayout(false);
            this.gbxInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.GroupBox gbxInfos;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxId;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.DateTimePicker dtpDatedebut;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.TextBox tbxMaxJoueurs;
        private System.Windows.Forms.Label lblNombreMaxJoueurs;
    }
}