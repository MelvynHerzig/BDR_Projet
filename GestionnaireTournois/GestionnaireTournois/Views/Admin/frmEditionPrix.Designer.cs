
namespace GestionnaireTournois.Views.Admin
{
    partial class frmEditionPrix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditionPrix));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRetirerObjet = new System.Windows.Forms.Button();
            this.nudMontantArgent = new System.Windows.Forms.NumericUpDown();
            this.btnEnregistrerPrixAssignés = new System.Windows.Forms.Button();
            this.lbxObjets = new System.Windows.Forms.ListBox();
            this.lblObjets = new System.Windows.Forms.Label();
            this.lblMontantArgent = new System.Windows.Forms.Label();
            this.gbxPrix = new System.Windows.Forms.GroupBox();
            this.lblAjouterObjet = new System.Windows.Forms.Label();
            this.tbxNouvelObjet = new System.Windows.Forms.TextBox();
            this.btnAddObjet = new System.Windows.Forms.Button();
            this.lbxTousObjets = new System.Windows.Forms.ListBox();
            this.btnAddToPrix = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontantArgent)).BeginInit();
            this.gbxPrix.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRetirerObjet);
            this.groupBox1.Controls.Add(this.nudMontantArgent);
            this.groupBox1.Controls.Add(this.btnEnregistrerPrixAssignés);
            this.groupBox1.Controls.Add(this.lbxObjets);
            this.groupBox1.Controls.Add(this.lblObjets);
            this.groupBox1.Controls.Add(this.lblMontantArgent);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 339);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prix assignés";
            // 
            // btnRetirerObjet
            // 
            this.btnRetirerObjet.Location = new System.Drawing.Point(22, 265);
            this.btnRetirerObjet.Name = "btnRetirerObjet";
            this.btnRetirerObjet.Size = new System.Drawing.Size(132, 29);
            this.btnRetirerObjet.TabIndex = 6;
            this.btnRetirerObjet.Text = "Retirer";
            this.btnRetirerObjet.UseVisualStyleBackColor = true;
            this.btnRetirerObjet.Click += new System.EventHandler(this.btnRetirerObjet_Click);
            // 
            // nudMontantArgent
            // 
            this.nudMontantArgent.DecimalPlaces = 2;
            this.nudMontantArgent.Location = new System.Drawing.Point(22, 48);
            this.nudMontantArgent.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontantArgent.Name = "nudMontantArgent";
            this.nudMontantArgent.Size = new System.Drawing.Size(132, 20);
            this.nudMontantArgent.TabIndex = 5;
            // 
            // btnEnregistrerPrixAssignés
            // 
            this.btnEnregistrerPrixAssignés.Location = new System.Drawing.Point(22, 304);
            this.btnEnregistrerPrixAssignés.Name = "btnEnregistrerPrixAssignés";
            this.btnEnregistrerPrixAssignés.Size = new System.Drawing.Size(132, 29);
            this.btnEnregistrerPrixAssignés.TabIndex = 4;
            this.btnEnregistrerPrixAssignés.Text = "Enregistrer";
            this.btnEnregistrerPrixAssignés.UseVisualStyleBackColor = true;
            this.btnEnregistrerPrixAssignés.Click += new System.EventHandler(this.btnEnregistrerPrixAssignés_Click);
            // 
            // lbxObjets
            // 
            this.lbxObjets.FormattingEnabled = true;
            this.lbxObjets.Location = new System.Drawing.Point(22, 107);
            this.lbxObjets.Name = "lbxObjets";
            this.lbxObjets.Size = new System.Drawing.Size(132, 147);
            this.lbxObjets.TabIndex = 3;
            // 
            // lblObjets
            // 
            this.lblObjets.AutoSize = true;
            this.lblObjets.Location = new System.Drawing.Point(19, 91);
            this.lblObjets.Name = "lblObjets";
            this.lblObjets.Size = new System.Drawing.Size(74, 13);
            this.lblObjets.TabIndex = 2;
            this.lblObjets.Text = "Liste d\'objets :";
            // 
            // lblMontantArgent
            // 
            this.lblMontantArgent.AutoSize = true;
            this.lblMontantArgent.Location = new System.Drawing.Point(19, 32);
            this.lblMontantArgent.Name = "lblMontantArgent";
            this.lblMontantArgent.Size = new System.Drawing.Size(93, 13);
            this.lblMontantArgent.TabIndex = 1;
            this.lblMontantArgent.Text = "Montant d\'argent :";
            // 
            // gbxPrix
            // 
            this.gbxPrix.Controls.Add(this.lblAjouterObjet);
            this.gbxPrix.Controls.Add(this.tbxNouvelObjet);
            this.gbxPrix.Controls.Add(this.btnAddObjet);
            this.gbxPrix.Controls.Add(this.lbxTousObjets);
            this.gbxPrix.Location = new System.Drawing.Point(279, 17);
            this.gbxPrix.Name = "gbxPrix";
            this.gbxPrix.Size = new System.Drawing.Size(166, 334);
            this.gbxPrix.TabIndex = 6;
            this.gbxPrix.TabStop = false;
            this.gbxPrix.Text = "Tous les objets";
            // 
            // lblAjouterObjet
            // 
            this.lblAjouterObjet.AutoSize = true;
            this.lblAjouterObjet.Location = new System.Drawing.Point(19, 253);
            this.lblAjouterObjet.Name = "lblAjouterObjet";
            this.lblAjouterObjet.Size = new System.Drawing.Size(72, 13);
            this.lblAjouterObjet.TabIndex = 6;
            this.lblAjouterObjet.Text = "Ajouter objet :";
            // 
            // tbxNouvelObjet
            // 
            this.tbxNouvelObjet.Location = new System.Drawing.Point(22, 269);
            this.tbxNouvelObjet.Name = "tbxNouvelObjet";
            this.tbxNouvelObjet.Size = new System.Drawing.Size(123, 20);
            this.tbxNouvelObjet.TabIndex = 5;
            // 
            // btnAddObjet
            // 
            this.btnAddObjet.Location = new System.Drawing.Point(22, 299);
            this.btnAddObjet.Name = "btnAddObjet";
            this.btnAddObjet.Size = new System.Drawing.Size(123, 29);
            this.btnAddObjet.TabIndex = 4;
            this.btnAddObjet.Text = "Ajouter";
            this.btnAddObjet.UseVisualStyleBackColor = true;
            this.btnAddObjet.Click += new System.EventHandler(this.btnAddObjet_Click);
            // 
            // lbxTousObjets
            // 
            this.lbxTousObjets.FormattingEnabled = true;
            this.lbxTousObjets.Location = new System.Drawing.Point(22, 37);
            this.lbxTousObjets.Name = "lbxTousObjets";
            this.lbxTousObjets.Size = new System.Drawing.Size(123, 212);
            this.lbxTousObjets.TabIndex = 3;
            // 
            // btnAddToPrix
            // 
            this.btnAddToPrix.Location = new System.Drawing.Point(197, 187);
            this.btnAddToPrix.Name = "btnAddToPrix";
            this.btnAddToPrix.Size = new System.Drawing.Size(76, 29);
            this.btnAddToPrix.TabIndex = 7;
            this.btnAddToPrix.Text = "<- Ajouter";
            this.btnAddToPrix.UseVisualStyleBackColor = true;
            this.btnAddToPrix.Click += new System.EventHandler(this.btnAddToPrix_Click);
            // 
            // frmEditionPrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 363);
            this.Controls.Add(this.btnAddToPrix);
            this.Controls.Add(this.gbxPrix);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditionPrix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editions des prix";
            this.Load += new System.EventHandler(this.frmEditionPrix_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontantArgent)).EndInit();
            this.gbxPrix.ResumeLayout(false);
            this.gbxPrix.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnregistrerPrixAssignés;
        private System.Windows.Forms.ListBox lbxObjets;
        private System.Windows.Forms.Label lblObjets;
        private System.Windows.Forms.Label lblMontantArgent;
        private System.Windows.Forms.NumericUpDown nudMontantArgent;
        private System.Windows.Forms.GroupBox gbxPrix;
        private System.Windows.Forms.Button btnAddObjet;
        private System.Windows.Forms.ListBox lbxTousObjets;
        private System.Windows.Forms.TextBox tbxNouvelObjet;
        private System.Windows.Forms.Label lblAjouterObjet;
        private System.Windows.Forms.Button btnRetirerObjet;
        private System.Windows.Forms.Button btnAddToPrix;
    }
}