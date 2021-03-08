namespace IHM
{
    partial class Fenetre
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
            this.buttonModifierOuvrage = new System.Windows.Forms.Button();
            this.buttonSupprimerOuvrage = new System.Windows.Forms.Button();
            this.listBoxOuvrages = new System.Windows.Forms.ListBox();
            this.listBoxPrets = new System.Windows.Forms.ListBox();
            this.labelPrets = new System.Windows.Forms.Label();
            this.labelOuvrages = new System.Windows.Forms.Label();
            this.listBoxAdherents = new System.Windows.Forms.ListBox();
            this.labelAdherent = new System.Windows.Forms.Label();
            this.buttonAjouterAdherent = new System.Windows.Forms.Button();
            this.buttonModifierAdherent = new System.Windows.Forms.Button();
            this.buttonSupprimerAdherent = new System.Windows.Forms.Button();
            this.buttonAjouterOuvrage = new System.Windows.Forms.Button();
            this.listBoxExemplaires = new System.Windows.Forms.ListBox();
            this.labelExemplaires = new System.Windows.Forms.Label();
            this.buttonEmprunter = new System.Windows.Forms.Button();
            this.buttonRetourner = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAjouterExemplaire = new System.Windows.Forms.Button();
            this.buttonModifierExemplaire = new System.Windows.Forms.Button();
            this.buttonSupprimerExemplaire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonModifierOuvrage
            // 
            this.buttonModifierOuvrage.BackColor = System.Drawing.Color.Yellow;
            this.buttonModifierOuvrage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonModifierOuvrage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonModifierOuvrage.Location = new System.Drawing.Point(539, 118);
            this.buttonModifierOuvrage.Name = "buttonModifierOuvrage";
            this.buttonModifierOuvrage.Size = new System.Drawing.Size(102, 38);
            this.buttonModifierOuvrage.TabIndex = 1;
            this.buttonModifierOuvrage.Text = "Modifier";
            this.buttonModifierOuvrage.UseVisualStyleBackColor = false;
            this.buttonModifierOuvrage.Click += new System.EventHandler(this.buttonModifierOuvrage_Click);
            // 
            // buttonSupprimerOuvrage
            // 
            this.buttonSupprimerOuvrage.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSupprimerOuvrage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSupprimerOuvrage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSupprimerOuvrage.Location = new System.Drawing.Point(539, 161);
            this.buttonSupprimerOuvrage.Name = "buttonSupprimerOuvrage";
            this.buttonSupprimerOuvrage.Size = new System.Drawing.Size(102, 45);
            this.buttonSupprimerOuvrage.TabIndex = 2;
            this.buttonSupprimerOuvrage.Text = "Supprimer";
            this.buttonSupprimerOuvrage.UseVisualStyleBackColor = false;
            this.buttonSupprimerOuvrage.Click += new System.EventHandler(this.buttonSupprimerOuvrage_Click);
            // 
            // listBoxOuvrages
            // 
            this.listBoxOuvrages.ForeColor = System.Drawing.Color.Navy;
            this.listBoxOuvrages.FormattingEnabled = true;
            this.listBoxOuvrages.Location = new System.Drawing.Point(12, 73);
            this.listBoxOuvrages.Name = "listBoxOuvrages";
            this.listBoxOuvrages.Size = new System.Drawing.Size(521, 225);
            this.listBoxOuvrages.TabIndex = 4;
            this.listBoxOuvrages.SelectedIndexChanged += new System.EventHandler(this.listBoxOuvrages_SelectedIndexChanged);
            // 
            // listBoxPrets
            // 
            this.listBoxPrets.ForeColor = System.Drawing.Color.Navy;
            this.listBoxPrets.FormattingEnabled = true;
            this.listBoxPrets.Location = new System.Drawing.Point(647, 334);
            this.listBoxPrets.Name = "listBoxPrets";
            this.listBoxPrets.Size = new System.Drawing.Size(587, 355);
            this.listBoxPrets.TabIndex = 5;
            // 
            // labelPrets
            // 
            this.labelPrets.AutoSize = true;
            this.labelPrets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelPrets.ForeColor = System.Drawing.Color.Navy;
            this.labelPrets.Location = new System.Drawing.Point(644, 309);
            this.labelPrets.Name = "labelPrets";
            this.labelPrets.Size = new System.Drawing.Size(59, 20);
            this.labelPrets.TabIndex = 6;
            this.labelPrets.Text = "Prets :";
            // 
            // labelOuvrages
            // 
            this.labelOuvrages.AutoSize = true;
            this.labelOuvrages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelOuvrages.ForeColor = System.Drawing.Color.Navy;
            this.labelOuvrages.Location = new System.Drawing.Point(9, 48);
            this.labelOuvrages.Name = "labelOuvrages";
            this.labelOuvrages.Size = new System.Drawing.Size(91, 20);
            this.labelOuvrages.TabIndex = 7;
            this.labelOuvrages.Text = "Ouvrages :";
            // 
            // listBoxAdherents
            // 
            this.listBoxAdherents.ForeColor = System.Drawing.Color.Navy;
            this.listBoxAdherents.FormattingEnabled = true;
            this.listBoxAdherents.Location = new System.Drawing.Point(647, 73);
            this.listBoxAdherents.Name = "listBoxAdherents";
            this.listBoxAdherents.Size = new System.Drawing.Size(475, 225);
            this.listBoxAdherents.TabIndex = 8;
            this.listBoxAdherents.SelectedIndexChanged += new System.EventHandler(this.listBoxAhderents_SelectedIndexChanged);
            // 
            // labelAdherent
            // 
            this.labelAdherent.AutoSize = true;
            this.labelAdherent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelAdherent.ForeColor = System.Drawing.Color.Navy;
            this.labelAdherent.Location = new System.Drawing.Point(644, 48);
            this.labelAdherent.Name = "labelAdherent";
            this.labelAdherent.Size = new System.Drawing.Size(95, 20);
            this.labelAdherent.TabIndex = 9;
            this.labelAdherent.Text = "Adhèrents :";
            // 
            // buttonAjouterAdherent
            // 
            this.buttonAjouterAdherent.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonAjouterAdherent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonAjouterAdherent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAjouterAdherent.Location = new System.Drawing.Point(1128, 73);
            this.buttonAjouterAdherent.Name = "buttonAjouterAdherent";
            this.buttonAjouterAdherent.Size = new System.Drawing.Size(104, 39);
            this.buttonAjouterAdherent.TabIndex = 10;
            this.buttonAjouterAdherent.Text = "Ajouter";
            this.buttonAjouterAdherent.UseVisualStyleBackColor = false;
            this.buttonAjouterAdherent.Click += new System.EventHandler(this.buttonAjouterAdherent_Click);
            // 
            // buttonModifierAdherent
            // 
            this.buttonModifierAdherent.BackColor = System.Drawing.Color.Yellow;
            this.buttonModifierAdherent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonModifierAdherent.Location = new System.Drawing.Point(1128, 118);
            this.buttonModifierAdherent.Name = "buttonModifierAdherent";
            this.buttonModifierAdherent.Size = new System.Drawing.Size(104, 38);
            this.buttonModifierAdherent.TabIndex = 11;
            this.buttonModifierAdherent.Text = "Modifier";
            this.buttonModifierAdherent.UseVisualStyleBackColor = false;
            this.buttonModifierAdherent.Click += new System.EventHandler(this.buttonModifierAdherent_Click);
            // 
            // buttonSupprimerAdherent
            // 
            this.buttonSupprimerAdherent.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSupprimerAdherent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSupprimerAdherent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSupprimerAdherent.Location = new System.Drawing.Point(1128, 162);
            this.buttonSupprimerAdherent.Name = "buttonSupprimerAdherent";
            this.buttonSupprimerAdherent.Size = new System.Drawing.Size(104, 45);
            this.buttonSupprimerAdherent.TabIndex = 12;
            this.buttonSupprimerAdherent.Text = "Supprimer";
            this.buttonSupprimerAdherent.UseVisualStyleBackColor = false;
            this.buttonSupprimerAdherent.Click += new System.EventHandler(this.buttonSupprimerAdherent_Click);
            // 
            // buttonAjouterOuvrage
            // 
            this.buttonAjouterOuvrage.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonAjouterOuvrage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonAjouterOuvrage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAjouterOuvrage.Location = new System.Drawing.Point(539, 73);
            this.buttonAjouterOuvrage.Name = "buttonAjouterOuvrage";
            this.buttonAjouterOuvrage.Size = new System.Drawing.Size(102, 39);
            this.buttonAjouterOuvrage.TabIndex = 13;
            this.buttonAjouterOuvrage.Text = "Ajouter";
            this.buttonAjouterOuvrage.UseVisualStyleBackColor = false;
            this.buttonAjouterOuvrage.Click += new System.EventHandler(this.buttonAjouterOuvrage_Click);
            // 
            // listBoxExemplaires
            // 
            this.listBoxExemplaires.ForeColor = System.Drawing.Color.Navy;
            this.listBoxExemplaires.FormattingEnabled = true;
            this.listBoxExemplaires.Location = new System.Drawing.Point(12, 335);
            this.listBoxExemplaires.Name = "listBoxExemplaires";
            this.listBoxExemplaires.Size = new System.Drawing.Size(521, 355);
            this.listBoxExemplaires.TabIndex = 14;
            // 
            // labelExemplaires
            // 
            this.labelExemplaires.AutoSize = true;
            this.labelExemplaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelExemplaires.ForeColor = System.Drawing.Color.Navy;
            this.labelExemplaires.Location = new System.Drawing.Point(12, 311);
            this.labelExemplaires.Name = "labelExemplaires";
            this.labelExemplaires.Size = new System.Drawing.Size(111, 20);
            this.labelExemplaires.TabIndex = 15;
            this.labelExemplaires.Text = "Exemplaires :";
            // 
            // buttonEmprunter
            // 
            this.buttonEmprunter.BackColor = System.Drawing.Color.CadetBlue;
            this.buttonEmprunter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonEmprunter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEmprunter.Location = new System.Drawing.Point(539, 334);
            this.buttonEmprunter.Name = "buttonEmprunter";
            this.buttonEmprunter.Size = new System.Drawing.Size(100, 49);
            this.buttonEmprunter.TabIndex = 16;
            this.buttonEmprunter.Text = "Emprunter";
            this.buttonEmprunter.UseVisualStyleBackColor = false;
            this.buttonEmprunter.Click += new System.EventHandler(this.buttonEmprunter_Click);
            // 
            // buttonRetourner
            // 
            this.buttonRetourner.BackColor = System.Drawing.Color.DarkViolet;
            this.buttonRetourner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonRetourner.ForeColor = System.Drawing.Color.Snow;
            this.buttonRetourner.Location = new System.Drawing.Point(539, 389);
            this.buttonRetourner.Name = "buttonRetourner";
            this.buttonRetourner.Size = new System.Drawing.Size(100, 47);
            this.buttonRetourner.TabIndex = 17;
            this.buttonRetourner.Text = "Retourner";
            this.buttonRetourner.UseVisualStyleBackColor = false;
            this.buttonRetourner.Click += new System.EventHandler(this.buttonRetourner_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCoral;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(789, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Biblihothèque Texas Instrument Innovation Gateway de l\'ESIEE Paris";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonAjouterExemplaire
            // 
            this.buttonAjouterExemplaire.AccessibleDescription = "buttonAjouterExemplaire";
            this.buttonAjouterExemplaire.AccessibleName = "buttonAjouterExemplaire";
            this.buttonAjouterExemplaire.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonAjouterExemplaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonAjouterExemplaire.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAjouterExemplaire.Location = new System.Drawing.Point(537, 555);
            this.buttonAjouterExemplaire.Name = "buttonAjouterExemplaire";
            this.buttonAjouterExemplaire.Size = new System.Drawing.Size(102, 39);
            this.buttonAjouterExemplaire.TabIndex = 19;
            this.buttonAjouterExemplaire.Text = "Ajouter";
            this.buttonAjouterExemplaire.UseVisualStyleBackColor = false;
            this.buttonAjouterExemplaire.Click += new System.EventHandler(this.buttonAjouterExemplaire_Click);
            // 
            // buttonModifierExemplaire
            // 
            this.buttonModifierExemplaire.AccessibleDescription = "buttonModifierExemplaire";
            this.buttonModifierExemplaire.AccessibleName = "buttonModifierExemplaire";
            this.buttonModifierExemplaire.BackColor = System.Drawing.Color.Yellow;
            this.buttonModifierExemplaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonModifierExemplaire.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonModifierExemplaire.Location = new System.Drawing.Point(537, 600);
            this.buttonModifierExemplaire.Name = "buttonModifierExemplaire";
            this.buttonModifierExemplaire.Size = new System.Drawing.Size(102, 38);
            this.buttonModifierExemplaire.TabIndex = 20;
            this.buttonModifierExemplaire.Text = "Modifier";
            this.buttonModifierExemplaire.UseVisualStyleBackColor = false;
            this.buttonModifierExemplaire.Click += new System.EventHandler(this.buttonModifierExemplaire_Click);
            // 
            // buttonSupprimerExemplaire
            // 
            this.buttonSupprimerExemplaire.AccessibleDescription = "buttonSupprimerExemplaire";
            this.buttonSupprimerExemplaire.AccessibleName = "buttonSupprimerExemplaire";
            this.buttonSupprimerExemplaire.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSupprimerExemplaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonSupprimerExemplaire.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSupprimerExemplaire.Location = new System.Drawing.Point(537, 644);
            this.buttonSupprimerExemplaire.Name = "buttonSupprimerExemplaire";
            this.buttonSupprimerExemplaire.Size = new System.Drawing.Size(102, 45);
            this.buttonSupprimerExemplaire.TabIndex = 21;
            this.buttonSupprimerExemplaire.Text = "Supprimer";
            this.buttonSupprimerExemplaire.UseVisualStyleBackColor = false;
            this.buttonSupprimerExemplaire.Click += new System.EventHandler(this.buttonSupprimerExemplaire_Click);
            // 
            // Fenetre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1246, 707);
            this.Controls.Add(this.buttonSupprimerExemplaire);
            this.Controls.Add(this.buttonModifierExemplaire);
            this.Controls.Add(this.buttonAjouterExemplaire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRetourner);
            this.Controls.Add(this.buttonEmprunter);
            this.Controls.Add(this.labelExemplaires);
            this.Controls.Add(this.listBoxExemplaires);
            this.Controls.Add(this.buttonAjouterOuvrage);
            this.Controls.Add(this.buttonSupprimerAdherent);
            this.Controls.Add(this.buttonModifierAdherent);
            this.Controls.Add(this.buttonAjouterAdherent);
            this.Controls.Add(this.labelAdherent);
            this.Controls.Add(this.listBoxAdherents);
            this.Controls.Add(this.labelOuvrages);
            this.Controls.Add(this.labelPrets);
            this.Controls.Add(this.listBoxPrets);
            this.Controls.Add(this.listBoxOuvrages);
            this.Controls.Add(this.buttonSupprimerOuvrage);
            this.Controls.Add(this.buttonModifierOuvrage);
            this.Name = "Fenetre";
            this.Text = "Bibliothèque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonModifierOuvrage;
        private System.Windows.Forms.Button buttonSupprimerOuvrage;
        private System.Windows.Forms.ListBox listBoxOuvrages;
        private System.Windows.Forms.ListBox listBoxPrets;
        private System.Windows.Forms.Label labelPrets;
        private System.Windows.Forms.Label labelOuvrages;
        private System.Windows.Forms.Label labelAdherent;
        private System.Windows.Forms.Button buttonModifierAdherent;
        private System.Windows.Forms.Button buttonSupprimerAdherent;
        private System.Windows.Forms.Button buttonAjouterAdherent;
        private System.Windows.Forms.ListBox listBoxAdherents;
        private System.Windows.Forms.Button buttonAjouterOuvrage;
        private System.Windows.Forms.ListBox listBoxExemplaires;
        private System.Windows.Forms.Label labelExemplaires;
        private System.Windows.Forms.Button buttonEmprunter;
        private System.Windows.Forms.Button buttonRetourner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAjouterExemplaire;
        private System.Windows.Forms.Button buttonModifierExemplaire;
        private System.Windows.Forms.Button buttonSupprimerExemplaire;
    }
}

