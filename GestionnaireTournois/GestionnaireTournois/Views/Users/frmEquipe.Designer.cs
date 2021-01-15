
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipe));
            this.btnQuitter = new System.Windows.Forms.Button();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.dgvAffichage = new System.Windows.Forms.DataGridView();
            this.colPseudo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNbSerieGagnee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotButs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotArrets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoyenneButs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoyenneArrets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbxInfosJoueur = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffichage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(21, 15);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(211, 38);
            this.btnQuitter.TabIndex = 0;
            this.btnQuitter.Text = "Quitter l\'équipe";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipe.Location = new System.Drawing.Point(315, 11);
            this.lblEquipe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(71, 24);
            this.lblEquipe.TabIndex = 13;
            this.lblEquipe.Text = "Equipe";
            // 
            // dgvAffichage
            // 
            this.dgvAffichage.AllowUserToAddRows = false;
            this.dgvAffichage.AllowUserToDeleteRows = false;
            this.dgvAffichage.AllowUserToResizeRows = false;
            this.dgvAffichage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAffichage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAffichage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPseudo,
            this.colNom,
            this.colPrenom,
            this.colEmail,
            this.colNbSerieGagnee,
            this.colTotButs,
            this.colTotArrets,
            this.colMoyenneButs,
            this.colMoyenneArrets,
            this.colActions});
            this.dgvAffichage.Location = new System.Drawing.Point(21, 84);
            this.dgvAffichage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAffichage.Name = "dgvAffichage";
            this.dgvAffichage.ReadOnly = true;
            this.dgvAffichage.RowHeadersVisible = false;
            this.dgvAffichage.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAffichage.Size = new System.Drawing.Size(864, 292);
            this.dgvAffichage.TabIndex = 14;
            this.dgvAffichage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAffichage_CellClick);
            // 
            // colPseudo
            // 
            this.colPseudo.HeaderText = "Pseudo";
            this.colPseudo.Name = "colPseudo";
            this.colPseudo.ReadOnly = true;
            // 
            // colNom
            // 
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            // 
            // colPrenom
            // 
            this.colPrenom.HeaderText = "Prénom";
            this.colPrenom.Name = "colPrenom";
            this.colPrenom.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colNbSerieGagnee
            // 
            this.colNbSerieGagnee.HeaderText = "Nombre de série gagnée";
            this.colNbSerieGagnee.Name = "colNbSerieGagnee";
            this.colNbSerieGagnee.ReadOnly = true;
            // 
            // colTotButs
            // 
            this.colTotButs.HeaderText = "Total des buts";
            this.colTotButs.Name = "colTotButs";
            this.colTotButs.ReadOnly = true;
            // 
            // colTotArrets
            // 
            this.colTotArrets.HeaderText = "Total des arrêts";
            this.colTotArrets.Name = "colTotArrets";
            this.colTotArrets.ReadOnly = true;
            // 
            // colMoyenneButs
            // 
            this.colMoyenneButs.HeaderText = "Moyenne des buts";
            this.colMoyenneButs.Name = "colMoyenneButs";
            this.colMoyenneButs.ReadOnly = true;
            // 
            // colMoyenneArrets
            // 
            this.colMoyenneArrets.HeaderText = "Moyenne des arrêts";
            this.colMoyenneArrets.Name = "colMoyenneArrets";
            this.colMoyenneArrets.ReadOnly = true;
            // 
            // colActions
            // 
            this.colActions.HeaderText = "Actions";
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            // 
            // cbxInfosJoueur
            // 
            this.cbxInfosJoueur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInfosJoueur.FormattingEnabled = true;
            this.cbxInfosJoueur.Items.AddRange(new object[] {
            "Joueurs actuels",
            "Anciens joueurs",
            "Joueurs en attente"});
            this.cbxInfosJoueur.Location = new System.Drawing.Point(724, 27);
            this.cbxInfosJoueur.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxInfosJoueur.Name = "cbxInfosJoueur";
            this.cbxInfosJoueur.Size = new System.Drawing.Size(160, 24);
            this.cbxInfosJoueur.TabIndex = 15;
            this.cbxInfosJoueur.SelectedIndexChanged += new System.EventHandler(this.cbxInfosJoueur_SelectedIndexChanged);
            // 
            // frmEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 390);
            this.Controls.Add(this.cbxInfosJoueur);
            this.Controls.Add(this.dgvAffichage);
            this.Controls.Add(this.lblEquipe);
            this.Controls.Add(this.btnQuitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmEquipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aperçu de l\'équipe";
            this.Load += new System.EventHandler(this.frmEquipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffichage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.DataGridView dgvAffichage;
        private System.Windows.Forms.ComboBox cbxInfosJoueur;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPseudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNbSerieGagnee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotButs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotArrets;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoyenneButs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoyenneArrets;
        private System.Windows.Forms.DataGridViewButtonColumn colActions;
    }
}