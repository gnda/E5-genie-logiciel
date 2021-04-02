using Domaine;
using IHM;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotheque.IHM
{
    public partial class FenetreForm_Adherent : Form
    {
        ServiceAdherents serviceAdherents;
        List<Adherent> adherents;
        int idx;

        public FenetreForm_Adherent(ServiceAdherents serviceAdherents, List<Adherent> adherents, string title, int idx)
        {
            
            InitializeComponent();
            this.idx = idx;
            this.serviceAdherents = serviceAdherents;
            this.adherents = adherents;
            label_title.Text = title;
            btn.Text = title;
            if (this.idx != -1)
            {
                textBox_nom.Text = adherents[idx].Nom;
            }
        }

        private void actualiser()
        {
            var mainForm = Application.OpenForms.OfType<Fenetre>().Single();
            mainForm.Actualiser();
        }

        private void FenetreForm_Adherent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // verifier si c'est remplie
            if(textBox_nom.Text != "" )
            {
                // déjà existant ?
                bool to_return = false;
                for(int i = 0; (i<this.adherents.Count) && to_return==false; i++)
                {
                    if (this.adherents[i].Nom == textBox_nom.Text)
                    {
                        to_return = true;
                    }
                }
                if (!to_return)
                {
                    if (this.idx == -1)
                    {
                        // ajouter
                        serviceAdherents.Ajouter(new Adherent(textBox_nom.Text));
                        //actualiser
                        actualiser();
                        // message box reussite 
                        MessageBox.Show("L'adhérent a été ajouté", "Ajout terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        // modifier
                        this.adherents[this.idx].Nom = textBox_nom.Text;
                        serviceAdherents.Modifier(this.adherents[this.idx]);
                        //actualiser
                        actualiser();

                        // message box reussite 
                        MessageBox.Show("L'adhérent a été modifié", "Modification terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close();
                    }
                }
                else
                {
                    // message box echec
                    MessageBox.Show("Un adhérent avec le même nom est existant", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // message box echec
                MessageBox.Show("Le champ nom est obligatoire", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_nom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_nom_Click(object sender, EventArgs e)
        {

        }
    }
}
