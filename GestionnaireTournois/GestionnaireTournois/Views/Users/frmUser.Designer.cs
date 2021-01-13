﻿
namespace GestionnaireTournois
{
    partial class frmUser
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
            this.btnStats = new System.Windows.Forms.Button();
            this.btnEquipe = new System.Windows.Forms.Button();
            this.cbxTournois = new System.Windows.Forms.ComboBox();
            this.dgvTournois = new System.Windows.Forms.DataGridView();
            this.NomTournoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChoixMode = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournois)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(12, 38);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(140, 23);
            this.btnStats.TabIndex = 1;
            this.btnStats.Text = "Voir statistiques";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnEquipe
            // 
            this.btnEquipe.Location = new System.Drawing.Point(12, 67);
            this.btnEquipe.Name = "btnEquipe";
            this.btnEquipe.Size = new System.Drawing.Size(140, 23);
            this.btnEquipe.TabIndex = 2;
            this.btnEquipe.Text = "Voir équipe";
            this.btnEquipe.UseVisualStyleBackColor = true;
            this.btnEquipe.Click += new System.EventHandler(this.btnEquipe_Click);
            // 
            // cbxTournois
            // 
            this.cbxTournois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTournois.FormattingEnabled = true;
            this.cbxTournois.Location = new System.Drawing.Point(182, 38);
            this.cbxTournois.Name = "cbxTournois";
            this.cbxTournois.Size = new System.Drawing.Size(121, 21);
            this.cbxTournois.TabIndex = 3;
            this.cbxTournois.SelectedIndexChanged += new System.EventHandler(this.cbxTournois_SelectedIndexChanged);
            // 
            // dgvTournois
            // 
            this.dgvTournois.AllowUserToAddRows = false;
            this.dgvTournois.AllowUserToDeleteRows = false;
            this.dgvTournois.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTournois.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomTournoi});
            this.dgvTournois.Location = new System.Drawing.Point(12, 105);
            this.dgvTournois.Name = "dgvTournois";
            this.dgvTournois.ReadOnly = true;
            this.dgvTournois.RowHeadersVisible = false;
            this.dgvTournois.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvTournois.Size = new System.Drawing.Size(776, 333);
            this.dgvTournois.TabIndex = 4;
            this.dgvTournois.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTournois_CellClick);
            // 
            // NomTournoi
            // 
            this.NomTournoi.HeaderText = "Nom Tournoi";
            this.NomTournoi.Name = "NomTournoi";
            this.NomTournoi.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFichier});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFichier
            // 
            this.tsmiFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChoixMode});
            this.tsmiFichier.Name = "tsmiFichier";
            this.tsmiFichier.Size = new System.Drawing.Size(54, 20);
            this.tsmiFichier.Text = "Fichier";
            // 
            // tsmiChoixMode
            // 
            this.tsmiChoixMode.Name = "tsmiChoixMode";
            this.tsmiChoixMode.Size = new System.Drawing.Size(180, 22);
            this.tsmiChoixMode.Text = "Choix du mode";
            this.tsmiChoixMode.Click += new System.EventHandler(this.tsmiChoixMode_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTournois);
            this.Controls.Add(this.cbxTournois);
            this.Controls.Add(this.btnEquipe);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmUser";
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournois)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnEquipe;
        private System.Windows.Forms.ComboBox cbxTournois;
        private System.Windows.Forms.DataGridView dgvTournois;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomTournoi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFichier;
        private System.Windows.Forms.ToolStripMenuItem tsmiChoixMode;
    }
}