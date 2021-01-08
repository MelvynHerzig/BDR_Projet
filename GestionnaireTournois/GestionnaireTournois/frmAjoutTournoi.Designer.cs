
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
            this.btnAjouterTournoi = new System.Windows.Forms.Button();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnAjouterTournoi
            // 
            this.btnAjouterTournoi.Location = new System.Drawing.Point(226, 205);
            this.btnAjouterTournoi.Name = "btnAjouterTournoi";
            this.btnAjouterTournoi.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterTournoi.TabIndex = 0;
            this.btnAjouterTournoi.Text = "Ajouter";
            this.btnAjouterTournoi.UseVisualStyleBackColor = true;
            this.btnAjouterTournoi.Click += new System.EventHandler(this.btnAjouterTournoi_Click);
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.Location = new System.Drawing.Point(147, 155);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(200, 20);
            this.dtpDateDebut.TabIndex = 1;
            // 
            // frmAjoutTournoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpDateDebut);
            this.Controls.Add(this.btnAjouterTournoi);
            this.Name = "frmAjoutTournoi";
            this.Text = "frmAjoutTournoi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAjouterTournoi;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
    }
}