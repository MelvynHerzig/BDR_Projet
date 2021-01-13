
namespace GestionnaireTournois.Views.Users
{
    partial class frmTournoi
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
            this.wbrTreeStruct = new System.Windows.Forms.WebBrowser();
            this.lbxJoueursEquipe = new System.Windows.Forms.ListBox();
            this.lblJoueurs = new System.Windows.Forms.Label();
            this.lblTournoi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wbrTreeStruct
            // 
            this.wbrTreeStruct.Location = new System.Drawing.Point(12, 64);
            this.wbrTreeStruct.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrTreeStruct.Name = "wbrTreeStruct";
            this.wbrTreeStruct.Size = new System.Drawing.Size(487, 506);
            this.wbrTreeStruct.TabIndex = 8;
            // 
            // lbxJoueursEquipe
            // 
            this.lbxJoueursEquipe.FormattingEnabled = true;
            this.lbxJoueursEquipe.Location = new System.Drawing.Point(602, 59);
            this.lbxJoueursEquipe.Name = "lbxJoueursEquipe";
            this.lbxJoueursEquipe.Size = new System.Drawing.Size(239, 511);
            this.lbxJoueursEquipe.TabIndex = 9;
            // 
            // lblJoueurs
            // 
            this.lblJoueurs.AutoSize = true;
            this.lblJoueurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueurs.Location = new System.Drawing.Point(598, 9);
            this.lblJoueurs.Name = "lblJoueurs";
            this.lblJoueurs.Size = new System.Drawing.Size(225, 24);
            this.lblJoueurs.TabIndex = 12;
            this.lblJoueurs.Text = "Joueurs de votre équipe :";
            // 
            // lblTournoi
            // 
            this.lblTournoi.AutoSize = true;
            this.lblTournoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournoi.Location = new System.Drawing.Point(8, 9);
            this.lblTournoi.Name = "lblTournoi";
            this.lblTournoi.Size = new System.Drawing.Size(86, 24);
            this.lblTournoi.TabIndex = 13;
            this.lblTournoi.Text = "Tournoi :";
            // 
            // frmTournoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 582);
            this.Controls.Add(this.lblTournoi);
            this.Controls.Add(this.lblJoueurs);
            this.Controls.Add(this.lbxJoueursEquipe);
            this.Controls.Add(this.wbrTreeStruct);
            this.Name = "frmTournoi";
            this.Text = "frmTournoi";
            this.Load += new System.EventHandler(this.frmTournoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbrTreeStruct;
        private System.Windows.Forms.ListBox lbxJoueursEquipe;
        private System.Windows.Forms.Label lblJoueurs;
        private System.Windows.Forms.Label lblTournoi;
    }
}