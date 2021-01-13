
namespace GestionnaireTournois.Views.Users
{
    partial class frmGestionEquipe
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
            this.cbxTournois = new System.Windows.Forms.ComboBox();
            this.lbxTournois = new System.Windows.Forms.ListBox();
            this.lblTournois = new System.Windows.Forms.Label();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.dgvMembresEquipe = new System.Windows.Forms.DataGridView();
            this.dgvDemandes = new System.Windows.Forms.DataGridView();
            this.lblDemandes = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresEquipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemandes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxTournois
            // 
            this.cbxTournois.FormattingEnabled = true;
            this.cbxTournois.Location = new System.Drawing.Point(730, 104);
            this.cbxTournois.Name = "cbxTournois";
            this.cbxTournois.Size = new System.Drawing.Size(156, 21);
            this.cbxTournois.TabIndex = 0;
            this.cbxTournois.SelectedIndexChanged += new System.EventHandler(this.cbxTournois_SelectedIndexChanged);
            // 
            // lbxTournois
            // 
            this.lbxTournois.FormattingEnabled = true;
            this.lbxTournois.Location = new System.Drawing.Point(730, 158);
            this.lbxTournois.Name = "lbxTournois";
            this.lbxTournois.Size = new System.Drawing.Size(156, 420);
            this.lbxTournois.TabIndex = 1;
            // 
            // lblTournois
            // 
            this.lblTournois.AutoSize = true;
            this.lblTournois.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournois.Location = new System.Drawing.Point(726, 30);
            this.lblTournois.Name = "lblTournois";
            this.lblTournois.Size = new System.Drawing.Size(95, 24);
            this.lblTournois.TabIndex = 11;
            this.lblTournois.Text = "Tournois :";
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipe.Location = new System.Drawing.Point(30, 30);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(81, 24);
            this.lblEquipe.TabIndex = 12;
            this.lblEquipe.Text = "Equipe :";
            // 
            // dgvMembresEquipe
            // 
            this.dgvMembresEquipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembresEquipe.Location = new System.Drawing.Point(34, 92);
            this.dgvMembresEquipe.Name = "dgvMembresEquipe";
            this.dgvMembresEquipe.Size = new System.Drawing.Size(639, 198);
            this.dgvMembresEquipe.TabIndex = 15;
            // 
            // dgvDemandes
            // 
            this.dgvDemandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemandes.Location = new System.Drawing.Point(34, 380);
            this.dgvDemandes.Name = "dgvDemandes";
            this.dgvDemandes.Size = new System.Drawing.Size(639, 198);
            this.dgvDemandes.TabIndex = 16;
            // 
            // lblDemandes
            // 
            this.lblDemandes.AutoSize = true;
            this.lblDemandes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemandes.Location = new System.Drawing.Point(30, 329);
            this.lblDemandes.Name = "lblDemandes";
            this.lblDemandes.Size = new System.Drawing.Size(112, 24);
            this.lblDemandes.TabIndex = 17;
            this.lblDemandes.Text = "Demandes :";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(909, 555);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 18;
            this.btnAction.Text = "S\'inscrire";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // frmGestionEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 609);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblDemandes);
            this.Controls.Add(this.dgvDemandes);
            this.Controls.Add(this.dgvMembresEquipe);
            this.Controls.Add(this.lblEquipe);
            this.Controls.Add(this.lblTournois);
            this.Controls.Add(this.lbxTournois);
            this.Controls.Add(this.cbxTournois);
            this.Name = "frmGestionEquipe";
            this.Text = "frmGestionEquipe";
            this.Load += new System.EventHandler(this.frmGestionEquipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresEquipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemandes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTournois;
        private System.Windows.Forms.ListBox lbxTournois;
        private System.Windows.Forms.Label lblTournois;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.DataGridView dgvMembresEquipe;
        private System.Windows.Forms.DataGridView dgvDemandes;
        private System.Windows.Forms.Label lblDemandes;
        private System.Windows.Forms.Button btnAction;
    }
}