
namespace GestionnaireTournois.Views.Users
{
    partial class frmRechercheEquipe
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lbxEquipes = new System.Windows.Forms.ListBox();
            this.btnRejoindre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(21, 21);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(221, 24);
            this.lblTitre.TabIndex = 11;
            this.lblTitre.Text = "Recherche d\'une équipe";
            // 
            // lbxEquipes
            // 
            this.lbxEquipes.FormattingEnabled = true;
            this.lbxEquipes.Location = new System.Drawing.Point(25, 60);
            this.lbxEquipes.Name = "lbxEquipes";
            this.lbxEquipes.Size = new System.Drawing.Size(139, 368);
            this.lbxEquipes.TabIndex = 12;
            // 
            // btnRejoindre
            // 
            this.btnRejoindre.Location = new System.Drawing.Point(170, 405);
            this.btnRejoindre.Name = "btnRejoindre";
            this.btnRejoindre.Size = new System.Drawing.Size(75, 23);
            this.btnRejoindre.TabIndex = 13;
            this.btnRejoindre.Text = "Rejoindre";
            this.btnRejoindre.UseVisualStyleBackColor = true;
            this.btnRejoindre.Click += new System.EventHandler(this.btnRejoindre_Click);
            // 
            // frmRechercheEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 450);
            this.Controls.Add(this.btnRejoindre);
            this.Controls.Add(this.lbxEquipes);
            this.Controls.Add(this.lblTitre);
            this.Name = "frmRechercheEquipe";
            this.Text = "frmRechercheEquipe";
            this.Load += new System.EventHandler(this.frmRechercheEquipe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.ListBox lbxEquipes;
        private System.Windows.Forms.Button btnRejoindre;
    }
}