
namespace Bibliotheque.IHM
{
    partial class FenetreForm_Exemplaire
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_nom = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.comboBox_ouvrage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_etat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AccessibleDescription = "label_title";
            this.label_title.AccessibleName = "label_title";
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label_title.Location = new System.Drawing.Point(69, 50);
            this.label_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(312, 35);
            this.label_title.TabIndex = 7;
            this.label_title.Text = "Ajouter un exemplaire";
            // 
            // label_nom
            // 
            this.label_nom.AccessibleDescription = "label_nom";
            this.label_nom.AccessibleName = "label_nom";
            this.label_nom.AutoSize = true;
            this.label_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label_nom.Location = new System.Drawing.Point(71, 113);
            this.label_nom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(50, 25);
            this.label_nom.TabIndex = 8;
            this.label_nom.Text = "État";
            // 
            // btn
            // 
            this.btn.AccessibleDescription = "btn";
            this.btn.AccessibleName = "btn";
            this.btn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn.BackColor = System.Drawing.Color.ForestGreen;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn.Location = new System.Drawing.Point(76, 293);
            this.btn.Margin = new System.Windows.Forms.Padding(4);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(467, 60);
            this.btn.TabIndex = 10;
            this.btn.Text = "Ajouter";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // comboBox_ouvrage
            // 
            this.comboBox_ouvrage.AccessibleDescription = "comboBox_ouvrage";
            this.comboBox_ouvrage.AccessibleName = "comboBox_ouvrage";
            this.comboBox_ouvrage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ouvrage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.comboBox_ouvrage.FormattingEnabled = true;
            this.comboBox_ouvrage.Location = new System.Drawing.Point(76, 238);
            this.comboBox_ouvrage.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_ouvrage.Name = "comboBox_ouvrage";
            this.comboBox_ouvrage.Size = new System.Drawing.Size(465, 33);
            this.comboBox_ouvrage.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "label_nom";
            this.label2.AccessibleName = "label_nom";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(71, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nom ouvrage";
            // 
            // comboBox_etat
            // 
            this.comboBox_etat.AccessibleDescription = "comboBox_etat";
            this.comboBox_etat.AccessibleName = "comboBox_etat";
            this.comboBox_etat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_etat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.comboBox_etat.FormattingEnabled = true;
            this.comboBox_etat.Location = new System.Drawing.Point(75, 142);
            this.comboBox_etat.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_etat.Name = "comboBox_etat";
            this.comboBox_etat.Size = new System.Drawing.Size(465, 33);
            this.comboBox_etat.TabIndex = 15;
            // 
            // FenetreForm_Exemplaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 411);
            this.Controls.Add(this.comboBox_etat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_ouvrage);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.label_nom);
            this.Controls.Add(this.label_title);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FenetreForm_Exemplaire";
            this.Text = "FenetreForm_Exemplaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_nom;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox comboBox_ouvrage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_etat;
    }
}