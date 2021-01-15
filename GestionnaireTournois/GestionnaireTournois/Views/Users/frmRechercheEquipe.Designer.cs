
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
            this.lbxRecherche = new System.Windows.Forms.ListBox();
            this.btnRejoindre = new System.Windows.Forms.Button();
            this.gbxRecherche = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreer = new System.Windows.Forms.Button();
            this.tbxNom = new System.Windows.Forms.TextBox();
            this.tbxAcronyme = new System.Windows.Forms.TextBox();
            this.lblAcronyme = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.gbxRecherche.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxRecherche
            // 
            this.lbxRecherche.FormattingEnabled = true;
            this.lbxRecherche.ItemHeight = 16;
            this.lbxRecherche.Location = new System.Drawing.Point(24, 30);
            this.lbxRecherche.Name = "lbxRecherche";
            this.lbxRecherche.Size = new System.Drawing.Size(167, 132);
            this.lbxRecherche.TabIndex = 12;
            // 
            // btnRejoindre
            // 
            this.btnRejoindre.Location = new System.Drawing.Point(24, 168);
            this.btnRejoindre.Name = "btnRejoindre";
            this.btnRejoindre.Size = new System.Drawing.Size(167, 29);
            this.btnRejoindre.TabIndex = 13;
            this.btnRejoindre.Text = "Rejoindre";
            this.btnRejoindre.UseVisualStyleBackColor = true;
            this.btnRejoindre.Click += new System.EventHandler(this.btnRejoindre_Click);
            // 
            // gbxRecherche
            // 
            this.gbxRecherche.Controls.Add(this.btnRejoindre);
            this.gbxRecherche.Controls.Add(this.lbxRecherche);
            this.gbxRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRecherche.Location = new System.Drawing.Point(12, 12);
            this.gbxRecherche.Name = "gbxRecherche";
            this.gbxRecherche.Size = new System.Drawing.Size(217, 210);
            this.gbxRecherche.TabIndex = 14;
            this.gbxRecherche.TabStop = false;
            this.gbxRecherche.Text = "Recherche d\'équipe";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNom);
            this.groupBox1.Controls.Add(this.lblAcronyme);
            this.groupBox1.Controls.Add(this.tbxAcronyme);
            this.groupBox1.Controls.Add(this.tbxNom);
            this.groupBox1.Controls.Add(this.btnCreer);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 196);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créer une équipe";
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(20, 154);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(167, 29);
            this.btnCreer.TabIndex = 13;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // tbxNom
            // 
            this.tbxNom.Location = new System.Drawing.Point(16, 110);
            this.tbxNom.Name = "tbxNom";
            this.tbxNom.Size = new System.Drawing.Size(167, 22);
            this.tbxNom.TabIndex = 14;
            // 
            // tbxAcronyme
            // 
            this.tbxAcronyme.Location = new System.Drawing.Point(16, 52);
            this.tbxAcronyme.Name = "tbxAcronyme";
            this.tbxAcronyme.Size = new System.Drawing.Size(167, 22);
            this.tbxAcronyme.TabIndex = 15;
            // 
            // lblAcronyme
            // 
            this.lblAcronyme.AutoSize = true;
            this.lblAcronyme.Location = new System.Drawing.Point(17, 33);
            this.lblAcronyme.Name = "lblAcronyme";
            this.lblAcronyme.Size = new System.Drawing.Size(75, 16);
            this.lblAcronyme.TabIndex = 16;
            this.lblAcronyme.Text = "Acronyme :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(17, 91);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(94, 16);
            this.lblNom.TabIndex = 17;
            this.lblNom.Text = "Nom complet :";
            // 
            // frmRechercheEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxRecherche);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmRechercheEquipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRechercheEquipe";
            this.Load += new System.EventHandler(this.frmRechercheEquipe_Load);
            this.gbxRecherche.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbxRecherche;
        private System.Windows.Forms.Button btnRejoindre;
        private System.Windows.Forms.GroupBox gbxRecherche;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreer;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblAcronyme;
        private System.Windows.Forms.TextBox tbxAcronyme;
        private System.Windows.Forms.TextBox tbxNom;
    }
}