﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTournoi));
            this.wbrTreeStruct = new System.Windows.Forms.WebBrowser();
            this.gbxEquipe = new System.Windows.Forms.GroupBox();
            this.lblJ3 = new System.Windows.Forms.Label();
            this.lblJ2 = new System.Windows.Forms.Label();
            this.lblJ1 = new System.Windows.Forms.Label();
            this.btnAbandonnerTournoi = new System.Windows.Forms.Button();
            this.gbxEquipe.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbrTreeStruct
            // 
            this.wbrTreeStruct.Location = new System.Drawing.Point(12, 9);
            this.wbrTreeStruct.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrTreeStruct.Name = "wbrTreeStruct";
            this.wbrTreeStruct.Size = new System.Drawing.Size(487, 395);
            this.wbrTreeStruct.TabIndex = 8;
            // 
            // gbxEquipe
            // 
            this.gbxEquipe.Controls.Add(this.lblJ3);
            this.gbxEquipe.Controls.Add(this.lblJ2);
            this.gbxEquipe.Controls.Add(this.lblJ1);
            this.gbxEquipe.Location = new System.Drawing.Point(12, 445);
            this.gbxEquipe.Name = "gbxEquipe";
            this.gbxEquipe.Size = new System.Drawing.Size(487, 55);
            this.gbxEquipe.TabIndex = 10;
            this.gbxEquipe.TabStop = false;
            this.gbxEquipe.Text = "Équipe";
            // 
            // lblJ3
            // 
            this.lblJ3.AutoSize = true;
            this.lblJ3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJ3.Location = new System.Drawing.Point(378, 25);
            this.lblJ3.Name = "lblJ3";
            this.lblJ3.Size = new System.Drawing.Size(0, 15);
            this.lblJ3.TabIndex = 2;
            // 
            // lblJ2
            // 
            this.lblJ2.AutoSize = true;
            this.lblJ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJ2.Location = new System.Drawing.Point(213, 25);
            this.lblJ2.Name = "lblJ2";
            this.lblJ2.Size = new System.Drawing.Size(11, 15);
            this.lblJ2.TabIndex = 1;
            this.lblJ2.Text = " ";
            // 
            // lblJ1
            // 
            this.lblJ1.AutoSize = true;
            this.lblJ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJ1.Location = new System.Drawing.Point(64, 25);
            this.lblJ1.Name = "lblJ1";
            this.lblJ1.Size = new System.Drawing.Size(11, 15);
            this.lblJ1.TabIndex = 0;
            this.lblJ1.Text = " ";
            // 
            // btnAbandonnerTournoi
            // 
            this.btnAbandonnerTournoi.Location = new System.Drawing.Point(12, 410);
            this.btnAbandonnerTournoi.Name = "btnAbandonnerTournoi";
            this.btnAbandonnerTournoi.Size = new System.Drawing.Size(487, 29);
            this.btnAbandonnerTournoi.TabIndex = 3;
            this.btnAbandonnerTournoi.Text = "Se désinscrire";
            this.btnAbandonnerTournoi.UseVisualStyleBackColor = true;
            this.btnAbandonnerTournoi.Visible = false;
            this.btnAbandonnerTournoi.Click += new System.EventHandler(this.btnAbandonnerTournoi_Click);
            // 
            // frmTournoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 515);
            this.Controls.Add(this.btnAbandonnerTournoi);
            this.Controls.Add(this.gbxEquipe);
            this.Controls.Add(this.wbrTreeStruct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTournoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTournoi";
            this.Load += new System.EventHandler(this.frmTournoi_Load);
            this.gbxEquipe.ResumeLayout(false);
            this.gbxEquipe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbrTreeStruct;
        private System.Windows.Forms.GroupBox gbxEquipe;
        private System.Windows.Forms.Label lblJ3;
        private System.Windows.Forms.Label lblJ2;
        private System.Windows.Forms.Label lblJ1;
        private System.Windows.Forms.Button btnAbandonnerTournoi;
    }
}