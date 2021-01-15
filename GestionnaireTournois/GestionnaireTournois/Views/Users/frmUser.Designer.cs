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
            this.dgvTournois = new System.Windows.Forms.DataGridView();
            this.colNomTournoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateDebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNbEquipes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mstrpUser = new System.Windows.Forms.MenuStrip();
            this.tsmiFIchier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChoixMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStats = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEquipes = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxTypeTournois = new System.Windows.Forms.ComboBox();
            this.lblTypeTournoi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournois)).BeginInit();
            this.mstrpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTournois
            // 
            this.dgvTournois.AllowUserToAddRows = false;
            this.dgvTournois.AllowUserToDeleteRows = false;
            this.dgvTournois.AllowUserToResizeRows = false;
            this.dgvTournois.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTournois.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomTournoi,
            this.colDateDebut,
            this.colDateFin,
            this.colNbEquipes,
            this.colActions});
            this.dgvTournois.Location = new System.Drawing.Point(15, 61);
            this.dgvTournois.Name = "dgvTournois";
            this.dgvTournois.ReadOnly = true;
            this.dgvTournois.RowHeadersVisible = false;
            this.dgvTournois.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvTournois.RowTemplate.ReadOnly = true;
            this.dgvTournois.Size = new System.Drawing.Size(454, 332);
            this.dgvTournois.TabIndex = 4;
            this.dgvTournois.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTournois_CellClick);
            // 
            // colNomTournoi
            // 
            this.colNomTournoi.HeaderText = "Nom Tournoi";
            this.colNomTournoi.Name = "colNomTournoi";
            this.colNomTournoi.ReadOnly = true;
            // 
            // colDateDebut
            // 
            this.colDateDebut.HeaderText = "Date de début";
            this.colDateDebut.Name = "colDateDebut";
            this.colDateDebut.ReadOnly = true;
            // 
            // colDateFin
            // 
            this.colDateFin.HeaderText = "Date de fin";
            this.colDateFin.Name = "colDateFin";
            this.colDateFin.ReadOnly = true;
            // 
            // colNbEquipes
            // 
            this.colNbEquipes.HeaderText = "Nombre d\'équipes";
            this.colNbEquipes.Name = "colNbEquipes";
            this.colNbEquipes.ReadOnly = true;
            // 
            // colActions
            // 
            this.colActions.HeaderText = "Actions";
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Text = "Voir";
            this.colActions.ToolTipText = "Voir";
            this.colActions.Width = 50;
            // 
            // mstrpUser
            // 
            this.mstrpUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFIchier,
            this.tsmiStats,
            this.tsmiEquipes});
            this.mstrpUser.Location = new System.Drawing.Point(0, 0);
            this.mstrpUser.Name = "mstrpUser";
            this.mstrpUser.Size = new System.Drawing.Size(478, 24);
            this.mstrpUser.TabIndex = 9;
            this.mstrpUser.Text = "menuStrip1";
            // 
            // tsmiFIchier
            // 
            this.tsmiFIchier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChoixMode});
            this.tsmiFIchier.Name = "tsmiFIchier";
            this.tsmiFIchier.Size = new System.Drawing.Size(54, 20);
            this.tsmiFIchier.Text = "Fichier";
            // 
            // tsmiChoixMode
            // 
            this.tsmiChoixMode.Name = "tsmiChoixMode";
            this.tsmiChoixMode.Size = new System.Drawing.Size(156, 22);
            this.tsmiChoixMode.Text = "Choix du mode";
            this.tsmiChoixMode.Click += new System.EventHandler(this.tsmiChoixMode_Click);
            // 
            // tsmiStats
            // 
            this.tsmiStats.Name = "tsmiStats";
            this.tsmiStats.Size = new System.Drawing.Size(79, 20);
            this.tsmiStats.Text = "Statistiques";
            this.tsmiStats.Click += new System.EventHandler(this.tsmiStats_Click);
            // 
            // tsmiEquipes
            // 
            this.tsmiEquipes.Name = "tsmiEquipes";
            this.tsmiEquipes.Size = new System.Drawing.Size(83, 20);
            this.tsmiEquipes.Text = "Mon équipe";
            this.tsmiEquipes.Click += new System.EventHandler(this.tsmiEquipes_Click);
            // 
            // cbxTypeTournois
            // 
            this.cbxTypeTournois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypeTournois.FormattingEnabled = true;
            this.cbxTypeTournois.Items.AddRange(new object[] {
            "Tournois participés",
            "Tournois rejoignables"});
            this.cbxTypeTournois.Location = new System.Drawing.Point(113, 34);
            this.cbxTypeTournois.Name = "cbxTypeTournois";
            this.cbxTypeTournois.Size = new System.Drawing.Size(173, 21);
            this.cbxTypeTournois.TabIndex = 10;
            this.cbxTypeTournois.SelectedIndexChanged += new System.EventHandler(this.cbxTypeTournois_SelectedIndexChanged);
            // 
            // lblTypeTournoi
            // 
            this.lblTypeTournoi.AutoSize = true;
            this.lblTypeTournoi.Location = new System.Drawing.Point(12, 37);
            this.lblTypeTournoi.Name = "lblTypeTournoi";
            this.lblTypeTournoi.Size = new System.Drawing.Size(92, 13);
            this.lblTypeTournoi.TabIndex = 11;
            this.lblTypeTournoi.Text = "Type de tournois :";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 405);
            this.Controls.Add(this.lblTypeTournoi);
            this.Controls.Add(this.cbxTypeTournois);
            this.Controls.Add(this.dgvTournois);
            this.Controls.Add(this.mstrpUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.mstrpUser;
            this.MaximizeBox = false;
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournois)).EndInit();
            this.mstrpUser.ResumeLayout(false);
            this.mstrpUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTournois;
        private System.Windows.Forms.MenuStrip mstrpUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiFIchier;
        private System.Windows.Forms.ToolStripMenuItem tsmiChoixMode;
        private System.Windows.Forms.ToolStripMenuItem tsmiEquipes;
        private System.Windows.Forms.ToolStripMenuItem tsmiStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomTournoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateDebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNbEquipes;
        private System.Windows.Forms.DataGridViewButtonColumn colActions;
        private System.Windows.Forms.ComboBox cbxTypeTournois;
        private System.Windows.Forms.Label lblTypeTournoi;
    }
}