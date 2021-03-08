
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
            this.textBox_nom = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.comboBox_ouvrage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AccessibleDescription = "label_title";
            this.label_title.AccessibleName = "label_title";
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label_title.Location = new System.Drawing.Point(52, 41);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(259, 29);
            this.label_title.TabIndex = 7;
            this.label_title.Text = "Ajouter un exemplaire";
            // 
            // label_nom
            // 
            this.label_nom.AccessibleDescription = "label_nom";
            this.label_nom.AccessibleName = "label_nom";
            this.label_nom.AutoSize = true;
            this.label_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label_nom.Location = new System.Drawing.Point(53, 92);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(44, 20);
            this.label_nom.TabIndex = 8;
            this.label_nom.Text = "Nom";
            // 
            // textBox_nom
            // 
            this.textBox_nom.AccessibleDescription = "textBox_nom";
            this.textBox_nom.AccessibleName = "textBox_nom";
            this.textBox_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.textBox_nom.Location = new System.Drawing.Point(57, 125);
            this.textBox_nom.Name = "textBox_nom";
            this.textBox_nom.Size = new System.Drawing.Size(350, 26);
            this.textBox_nom.TabIndex = 9;
            // 
            // btn
            // 
            this.btn.AccessibleDescription = "btn";
            this.btn.AccessibleName = "btn";
            this.btn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn.BackColor = System.Drawing.Color.ForestGreen;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn.Location = new System.Drawing.Point(57, 238);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(350, 49);
            this.btn.TabIndex = 10;
            this.btn.Text = "Ajouter";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // comboBox_ouvrage
            // 
            this.comboBox_ouvrage.AccessibleDescription = "comboBox_ouvrage";
            this.comboBox_ouvrage.AccessibleName = "comboBox_ouvrage";
            this.comboBox_ouvrage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.comboBox_ouvrage.FormattingEnabled = true;
            this.comboBox_ouvrage.Location = new System.Drawing.Point(57, 193);
            this.comboBox_ouvrage.Name = "comboBox_ouvrage";
            this.comboBox_ouvrage.Size = new System.Drawing.Size(350, 28);
            this.comboBox_ouvrage.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "label_nom";
            this.label2.AccessibleName = "label_nom";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(53, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nom";
            // 
            // FenetreForm_Exemplaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 334);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_ouvrage);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.textBox_nom);
            this.Controls.Add(this.label_nom);
            this.Controls.Add(this.label_title);
            this.Name = "FenetreForm_Exemplaire";
            this.Text = "FenetreForm_Exemplaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_nom;
        private System.Windows.Forms.TextBox textBox_nom;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox comboBox_ouvrage;
        private System.Windows.Forms.Label label2;
    }
}