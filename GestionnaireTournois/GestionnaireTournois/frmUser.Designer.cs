
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
            this.mstrpUser = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModeChoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mstrpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstrpUser
            // 
            this.mstrpUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.mstrpUser.Location = new System.Drawing.Point(0, 0);
            this.mstrpUser.Name = "mstrpUser";
            this.mstrpUser.Size = new System.Drawing.Size(800, 24);
            this.mstrpUser.TabIndex = 0;
            this.mstrpUser.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiModeChoice});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // tsmiModeChoice
            // 
            this.tsmiModeChoice.Name = "tsmiModeChoice";
            this.tsmiModeChoice.Size = new System.Drawing.Size(156, 22);
            this.tsmiModeChoice.Text = "Choix du mode";
            this.tsmiModeChoice.Click += new System.EventHandler(this.tsmiModeChoice_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mstrpUser);
            this.MainMenuStrip = this.mstrpUser;
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUser";
            this.mstrpUser.ResumeLayout(false);
            this.mstrpUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstrpUser;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiModeChoice;
    }
}