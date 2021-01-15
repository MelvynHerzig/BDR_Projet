
namespace GestionnaireTournois
{
    partial class frmAjoutTournoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAjoutTournoi));
            this.btnAjouterTournoi = new System.Windows.Forms.Button();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.dtpHeureDebut = new System.Windows.Forms.DateTimePicker();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.lblHeureDebut = new System.Windows.Forms.Label();
            this.tbxNomTournoi = new System.Windows.Forms.TextBox();
            this.lblNomTournoi = new System.Windows.Forms.Label();
            this.nudEquipes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudEquipes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAjouterTournoi
            // 
            this.btnAjouterTournoi.Location = new System.Drawing.Point(30, 187);
            this.btnAjouterTournoi.Name = "btnAjouterTournoi";
            this.btnAjouterTournoi.Size = new System.Drawing.Size(220, 36);
            this.btnAjouterTournoi.TabIndex = 0;
            this.btnAjouterTournoi.Text = "Ajouter";
            this.btnAjouterTournoi.UseVisualStyleBackColor = true;
            this.btnAjouterTournoi.Click += new System.EventHandler(this.btnAjouterTournoi_Click);
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.CustomFormat = "";
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDebut.Location = new System.Drawing.Point(148, 111);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(102, 20);
            this.dtpDateDebut.TabIndex = 1;
            // 
            // dtpHeureDebut
            // 
            this.dtpHeureDebut.CustomFormat = "";
            this.dtpHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHeureDebut.Location = new System.Drawing.Point(148, 137);
            this.dtpHeureDebut.Name = "dtpHeureDebut";
            this.dtpHeureDebut.ShowUpDown = true;
            this.dtpHeureDebut.Size = new System.Drawing.Size(102, 20);
            this.dtpHeureDebut.TabIndex = 2;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Location = new System.Drawing.Point(44, 117);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(81, 13);
            this.lblDateDebut.TabIndex = 3;
            this.lblDateDebut.Text = "Date du début :";
            // 
            // lblHeureDebut
            // 
            this.lblHeureDebut.AutoSize = true;
            this.lblHeureDebut.Location = new System.Drawing.Point(38, 143);
            this.lblHeureDebut.Name = "lblHeureDebut";
            this.lblHeureDebut.Size = new System.Drawing.Size(87, 13);
            this.lblHeureDebut.TabIndex = 4;
            this.lblHeureDebut.Text = "Heure du début :";
            // 
            // tbxNomTournoi
            // 
            this.tbxNomTournoi.Location = new System.Drawing.Point(148, 35);
            this.tbxNomTournoi.Name = "tbxNomTournoi";
            this.tbxNomTournoi.Size = new System.Drawing.Size(102, 20);
            this.tbxNomTournoi.TabIndex = 5;
            // 
            // lblNomTournoi
            // 
            this.lblNomTournoi.AutoSize = true;
            this.lblNomTournoi.Location = new System.Drawing.Point(37, 38);
            this.lblNomTournoi.Name = "lblNomTournoi";
            this.lblNomTournoi.Size = new System.Drawing.Size(88, 13);
            this.lblNomTournoi.TabIndex = 6;
            this.lblNomTournoi.Text = "Nom du tournoi : ";
            // 
            // nudEquipes
            // 
            this.nudEquipes.Location = new System.Drawing.Point(148, 72);
            this.nudEquipes.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudEquipes.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudEquipes.Name = "nudEquipes";
            this.nudEquipes.Size = new System.Drawing.Size(102, 20);
            this.nudEquipes.TabIndex = 7;
            this.nudEquipes.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre d\'équipes :";
            // 
            // frmAjoutTournoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 249);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudEquipes);
            this.Controls.Add(this.lblNomTournoi);
            this.Controls.Add(this.tbxNomTournoi);
            this.Controls.Add(this.lblHeureDebut);
            this.Controls.Add(this.lblDateDebut);
            this.Controls.Add(this.dtpHeureDebut);
            this.Controls.Add(this.dtpDateDebut);
            this.Controls.Add(this.btnAjouterTournoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAjoutTournoi";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter un tournoi ";
            ((System.ComponentModel.ISupportInitialize)(this.nudEquipes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAjouterTournoi;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.DateTimePicker dtpHeureDebut;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.Label lblHeureDebut;
        private System.Windows.Forms.TextBox tbxNomTournoi;
        private System.Windows.Forms.Label lblNomTournoi;
        private System.Windows.Forms.NumericUpDown nudEquipes;
        private System.Windows.Forms.Label label1;
    }
}