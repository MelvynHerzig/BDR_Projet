
namespace GestionnaireTournois
{
    partial class frmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbxAdmin = new System.Windows.Forms.GroupBox();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.gbxUser = new System.Windows.Forms.GroupBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblModeChoice = new System.Windows.Forms.Label();
            this.gbxAdmin.SuspendLayout();
            this.gbxUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAdmin
            // 
            this.gbxAdmin.Controls.Add(this.btnAdmin);
            this.gbxAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAdmin.Location = new System.Drawing.Point(12, 78);
            this.gbxAdmin.Name = "gbxAdmin";
            this.gbxAdmin.Size = new System.Drawing.Size(328, 151);
            this.gbxAdmin.TabIndex = 0;
            this.gbxAdmin.TabStop = false;
            this.gbxAdmin.Text = "Mode administrateur";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(90, 55);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(150, 48);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Text = "Administration";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // gbxUser
            // 
            this.gbxUser.Controls.Add(this.btnSignUp);
            this.gbxUser.Controls.Add(this.btnSignIn);
            this.gbxUser.Controls.Add(this.lblEmail);
            this.gbxUser.Controls.Add(this.tbxEmail);
            this.gbxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxUser.Location = new System.Drawing.Point(12, 235);
            this.gbxUser.Name = "gbxUser";
            this.gbxUser.Size = new System.Drawing.Size(328, 132);
            this.gbxUser.TabIndex = 1;
            this.gbxUser.TabStop = false;
            this.gbxUser.Text = "Mode utilisateur";
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(28, 83);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(100, 23);
            this.btnSignUp.TabIndex = 4;
            this.btnSignUp.Text = "S\'inscrire";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Enabled = false;
            this.btnSignIn.Location = new System.Drawing.Point(188, 83);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(100, 23);
            this.btnSignIn.TabIndex = 3;
            this.btnSignIn.Text = "Se connecter";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(25, 29);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(87, 16);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Entrez email :";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmail.Location = new System.Drawing.Point(28, 48);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(260, 21);
            this.tbxEmail.TabIndex = 0;
            this.tbxEmail.TextChanged += new System.EventHandler(this.tbxEmail_TextChanged);
            // 
            // lblModeChoice
            // 
            this.lblModeChoice.AutoSize = true;
            this.lblModeChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeChoice.Location = new System.Drawing.Point(66, 29);
            this.lblModeChoice.Name = "lblModeChoice";
            this.lblModeChoice.Size = new System.Drawing.Size(224, 33);
            this.lblModeChoice.TabIndex = 2;
            this.lblModeChoice.Text = "Choix du mode";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 378);
            this.Controls.Add(this.lblModeChoice);
            this.Controls.Add(this.gbxUser);
            this.Controls.Add(this.gbxAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionnaire de tournois";
            this.gbxAdmin.ResumeLayout(false);
            this.gbxUser.ResumeLayout(false);
            this.gbxUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAdmin;
        private System.Windows.Forms.GroupBox gbxUser;
        private System.Windows.Forms.Label lblModeChoice;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Button btnAdmin;
    }
}

