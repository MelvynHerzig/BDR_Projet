﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRechercheEquipe));
            this.lbxRecherche = new System.Windows.Forms.ListBox();
            this.btnRejoindre = new System.Windows.Forms.Button();
            this.gbxRecherche = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblAcronyme = new System.Windows.Forms.Label();
            this.tbxAcronyme = new System.Windows.Forms.TextBox();
            this.tbxNom = new System.Windows.Forms.TextBox();
            this.btnCreer = new System.Windows.Forms.Button();
            this.gbxRecherche.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxRecherche
            // 
            this.lbxRecherche.FormattingEnabled = true;
            this.lbxRecherche.ItemHeight = 16;
            this.lbxRecherche.Location = new System.Drawing.Point(32, 37);
            this.lbxRecherche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxRecherche.Name = "lbxRecherche";
            this.lbxRecherche.Size = new System.Drawing.Size(221, 148);
            this.lbxRecherche.TabIndex = 12;
            // 
            // btnRejoindre
            // 
            this.btnRejoindre.Location = new System.Drawing.Point(32, 207);
            this.btnRejoindre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRejoindre.Name = "btnRejoindre";
            this.btnRejoindre.Size = new System.Drawing.Size(223, 36);
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
            this.gbxRecherche.Location = new System.Drawing.Point(16, 15);
            this.gbxRecherche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxRecherche.Name = "gbxRecherche";
            this.gbxRecherche.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxRecherche.Size = new System.Drawing.Size(289, 258);
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
            this.groupBox1.Location = new System.Drawing.Point(21, 289);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(289, 241);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créer une équipe";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(23, 112);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(94, 16);
            this.lblNom.TabIndex = 17;
            this.lblNom.Text = "Nom complet :";
            // 
            // lblAcronyme
            // 
            this.lblAcronyme.AutoSize = true;
            this.lblAcronyme.Location = new System.Drawing.Point(23, 41);
            this.lblAcronyme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcronyme.Name = "lblAcronyme";
            this.lblAcronyme.Size = new System.Drawing.Size(75, 16);
            this.lblAcronyme.TabIndex = 16;
            this.lblAcronyme.Text = "Acronyme :";
            // 
            // tbxAcronyme
            // 
            this.tbxAcronyme.Location = new System.Drawing.Point(21, 64);
            this.tbxAcronyme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxAcronyme.Name = "tbxAcronyme";
            this.tbxAcronyme.Size = new System.Drawing.Size(221, 22);
            this.tbxAcronyme.TabIndex = 15;
            // 
            // tbxNom
            // 
            this.tbxNom.Location = new System.Drawing.Point(21, 135);
            this.tbxNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxNom.Name = "tbxNom";
            this.tbxNom.Size = new System.Drawing.Size(221, 22);
            this.tbxNom.TabIndex = 14;
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(27, 190);
            this.btnCreer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(223, 36);
            this.btnCreer.TabIndex = 13;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // frmRechercheEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 543);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxRecherche);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmRechercheEquipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recherche / Création d\'une équipe";
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