
namespace Bibliotheque.IHM
{
    partial class FenetreForm_Adherent
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
            this.btn = new System.Windows.Forms.Button();
            this.textBox_nom = new System.Windows.Forms.TextBox();
            this.label_nom = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.AccessibleDescription = "btn";
            this.btn.AccessibleName = "btn";
            this.btn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn.BackColor = System.Drawing.Color.ForestGreen;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn.Location = new System.Drawing.Point(51, 121);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(242, 49);
            this.btn.TabIndex = 0;
            this.btn.Text = "Ajouter";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_nom
            // 
            this.textBox_nom.AccessibleDescription = "textBox_nom";
            this.textBox_nom.AccessibleName = "textBox_nom";
            this.textBox_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox_nom.Location = new System.Drawing.Point(51, 83);
            this.textBox_nom.Name = "textBox_nom";
            this.textBox_nom.Size = new System.Drawing.Size(242, 23);
            this.textBox_nom.TabIndex = 1;
            // 
            // label_nom
            // 
            this.label_nom.AccessibleDescription = "label_nom";
            this.label_nom.AccessibleName = "label_nom";
            this.label_nom.AutoSize = true;
            this.label_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label_nom.Location = new System.Drawing.Point(48, 59);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(44, 20);
            this.label_nom.TabIndex = 3;
            this.label_nom.Text = "Nom";
            // 
            // label_title
            // 
            this.label_title.AccessibleDescription = "label_title";
            this.label_title.AccessibleName = "label_title";
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label_title.Location = new System.Drawing.Point(46, 19);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(234, 29);
            this.label_title.TabIndex = 5;
            this.label_title.Text = "Ajouter un adhérent";
            // 
            // FenetreForm_Adherent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(355, 200);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_nom);
            this.Controls.Add(this.textBox_nom);
            this.Controls.Add(this.btn);
            this.Name = "FenetreForm_Adherent";
            this.Text = "Adhérent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.TextBox textBox_nom;
        private System.Windows.Forms.Label label_nom;
        private System.Windows.Forms.Label label_title;
    }
}