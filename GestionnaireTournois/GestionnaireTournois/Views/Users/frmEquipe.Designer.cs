
namespace GestionnaireTournois.Views.Users
{
    partial class frmEquipe
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
            this.btnQuitter = new System.Windows.Forms.Button();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.dgvMembresEquipe = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresEquipe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(16, 55);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(158, 23);
            this.btnQuitter.TabIndex = 0;
            this.btnQuitter.Text = "Quitter l\'équipe";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipe.Location = new System.Drawing.Point(236, 9);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(71, 24);
            this.lblEquipe.TabIndex = 13;
            this.lblEquipe.Text = "Equipe";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(12, 9);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(172, 24);
            this.lblTitre.TabIndex = 12;
            this.lblTitre.Text = "Equipe du joueur : ";
            // 
            // dgvMembresEquipe
            // 
            this.dgvMembresEquipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembresEquipe.Location = new System.Drawing.Point(16, 101);
            this.dgvMembresEquipe.Name = "dgvMembresEquipe";
            this.dgvMembresEquipe.Size = new System.Drawing.Size(772, 337);
            this.dgvMembresEquipe.TabIndex = 14;
            // 
            // frmEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMembresEquipe);
            this.Controls.Add(this.lblEquipe);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnQuitter);
            this.Name = "frmEquipe";
            this.Text = "frmEquipe";
            this.Load += new System.EventHandler(this.frmEquipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresEquipe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.DataGridView dgvMembresEquipe;
    }
}