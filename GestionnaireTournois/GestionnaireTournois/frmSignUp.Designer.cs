
namespace GestionnaireTournois
{
    partial class frmSignUp
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
            this.lblSignUp = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cbxCountry = new System.Windows.Forms.ComboBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxPseudo = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.gbxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSignUp
            // 
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignUp.Location = new System.Drawing.Point(71, 28);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(193, 33);
            this.lblSignUp.TabIndex = 3;
            this.lblSignUp.Text = "S\'enregistrer";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(144, 53);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(143, 22);
            this.tbxName.TabIndex = 4;
            // 
            // gbxInfo
            // 
            this.gbxInfo.Controls.Add(this.lblCountry);
            this.gbxInfo.Controls.Add(this.label3);
            this.gbxInfo.Controls.Add(this.lblEmail);
            this.gbxInfo.Controls.Add(this.lblPseudo);
            this.gbxInfo.Controls.Add(this.lblFirstname);
            this.gbxInfo.Controls.Add(this.lblName);
            this.gbxInfo.Controls.Add(this.cbxCountry);
            this.gbxInfo.Controls.Add(this.dtpBirthday);
            this.gbxInfo.Controls.Add(this.tbxEmail);
            this.gbxInfo.Controls.Add(this.tbxPseudo);
            this.gbxInfo.Controls.Add(this.tbxFirstName);
            this.gbxInfo.Controls.Add(this.tbxName);
            this.gbxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInfo.Location = new System.Drawing.Point(12, 83);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(312, 237);
            this.gbxInfo.TabIndex = 5;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "Informations";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(88, 197);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(45, 16);
            this.lblCountry.TabIndex = 15;
            this.lblCountry.Text = "Pays :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Date de naissance :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(85, 130);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 16);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email :";
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Location = new System.Drawing.Point(77, 102);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(61, 16);
            this.lblPseudo.TabIndex = 12;
            this.lblPseudo.Text = "Pseudo :";
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.Location = new System.Drawing.Point(72, 28);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(61, 16);
            this.lblFirstname.TabIndex = 11;
            this.lblFirstname.Text = "Prénom :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(85, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 16);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Nom :";
            // 
            // cbxCountry
            // 
            this.cbxCountry.FormattingEnabled = true;
            this.cbxCountry.Location = new System.Drawing.Point(144, 194);
            this.cbxCountry.Name = "cbxCountry";
            this.cbxCountry.Size = new System.Drawing.Size(143, 24);
            this.cbxCountry.TabIndex = 9;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CustomFormat = "dd.MM.yyyy";
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(144, 166);
            this.dtpBirthday.MaxDate = new System.DateTime(2020, 11, 16, 14, 35, 27, 0);
            this.dtpBirthday.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(143, 22);
            this.dtpBirthday.TabIndex = 8;
            this.dtpBirthday.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(144, 127);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(143, 22);
            this.tbxEmail.TabIndex = 7;
            // 
            // tbxPseudo
            // 
            this.tbxPseudo.Location = new System.Drawing.Point(144, 99);
            this.tbxPseudo.Name = "tbxPseudo";
            this.tbxPseudo.Size = new System.Drawing.Size(143, 22);
            this.tbxPseudo.TabIndex = 6;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Location = new System.Drawing.Point(144, 25);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(143, 22);
            this.tbxFirstName.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(41, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSignUp
            // 
            this.btnSignUp.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.Location = new System.Drawing.Point(224, 337);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(75, 23);
            this.btnSignUp.TabIndex = 7;
            this.btnSignUp.Text = "S\'inscrire";
            this.btnSignUp.UseVisualStyleBackColor = true;
            // 
            // frmSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 378);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxInfo);
            this.Controls.Add(this.lblSignUp);
            this.Name = "frmSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inscription";
            this.Load += new System.EventHandler(this.frmSignUp_Load);
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSignUp;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.TextBox tbxPseudo;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.ComboBox cbxCountry;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFirstname;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSignUp;
    }
}