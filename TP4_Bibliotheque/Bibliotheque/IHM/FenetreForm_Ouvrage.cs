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
    public partial class FenetreForm_Ouvrage : Form
    {

        ServiceOuvrages serviceOuvrages;
        List<Ouvrage> ouvrages;
        int idx;

        public FenetreForm_Ouvrage(ServiceOuvrages serviceOuvrages, List<Ouvrage> ouvrages, string titre, int idx)
        {
            InitializeComponent();
            this.serviceOuvrages = serviceOuvrages;
            this.ouvrages = ouvrages;
            this.idx = idx;
            label_title.Text = titre;
            btn.Text = titre;
            if (this.idx != -1)
            {
                textBox_nom.Text = ouvrages[idx].Titre;
                textBox_auteur.Text = ouvrages[idx].Auteur;
            }
        }

        private void label_title_Click(object sender, EventArgs e)
        {

        }

        private void actualiser()
        {
            var mainForm = Application.OpenForms.OfType<Fenetre>().Single();
            mainForm.Actualiser();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // verifier si c'est remplie
            if (textBox_nom.Text != "" && textBox_auteur.Text !="")
            {
                // déjà existant ?
                bool to_return = false;
                for (int i = 0; (i < this.ouvrages.Count) && to_return == false; i++)
                {
                    if (this.ouvrages[i].Titre == textBox_nom.Text && this.ouvrages[i].Auteur == textBox_auteur.Text)
                    {
                        to_return = true;
                    }
                }
                if (!to_return)
                {
                    if (this.idx == -1)
                    {
                        // ajouter
                        serviceOuvrages.Ajouter(new Ouvrage(textBox_nom.Text, textBox_nom.Text));
                        //actualiser
                        actualiser();
                        // message box reussite 
                        MessageBox.Show("L'ouvrage a été ajouté", "Ajout terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        // modifier
                        this.ouvrages[this.idx].Titre = textBox_nom.Text;
                        serviceOuvrages.Modifier(this.ouvrages[this.idx]);
                        //actualiser
                        actualiser();

                        // message box reussite 
                        MessageBox.Show("L'ouvrage a été modifié", "Modification terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                else
                {
                    // message box echec
                    MessageBox.Show("Un ouvrage avec le même nom et auteur est existant", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // message box echec
                MessageBox.Show("Le champ nom est obligatoire", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
