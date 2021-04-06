using Domaine;
using IHM;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bibliotheque.IHM
{
    public partial class FenetreForm_Ouvrage : Form
    {

        ServiceOuvrages serviceOuvrages;
        List<Ouvrage> ouvrages;
        Ouvrage ouvrage;

        public FenetreForm_Ouvrage(ServiceOuvrages serviceOuvrages, 
            List<Ouvrage> ouvrages, string titre, Ouvrage ouvrage = null)
        {
            InitializeComponent();
            this.serviceOuvrages = serviceOuvrages;
            this.ouvrages = ouvrages;
            if (ouvrage != null)
            {
                this.ouvrage = ouvrages.Find(o => o.Id == ouvrage.Id);
            }
            label_title.Text = titre;
            btn.Text = titre;
            if (this.ouvrage != null)
            {
                textBox_nom.Text = ouvrage.Titre;
                textBox_auteur.Text = ouvrage.Auteur;
            }
        }

        private void Actualiser()
        {
            var mainForm = Application.OpenForms.OfType<Fenetre>().Single();
            mainForm.Actualiser();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // verifier si c'est rempli
            if (textBox_nom.Text != "" && textBox_auteur.Text !="")
            {
                // déjà existant ?
                bool to_return = false;
                for (int i = 0; (i < ouvrages.Count) && to_return == false; i++)
                {
                    if (ouvrages[i].Titre == textBox_nom.Text && ouvrages[i].Auteur == textBox_auteur.Text)
                    {
                        to_return = true;
                    }
                }
                if (!to_return)
                {
                    if (ouvrage == null)
                    {
                        // ajouter
                        serviceOuvrages.Ajouter(new Ouvrage(textBox_nom.Text, textBox_auteur.Text));
                        // actualiser
                        Actualiser();
                        // message box reussite 
                        MessageBox.Show("L'ouvrage a été ajouté", "Ajout terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        // modifier
                        ouvrage.Titre = textBox_nom.Text;
                        ouvrage.Auteur = textBox_auteur.Text;
                        serviceOuvrages.Modifier(ouvrage);
                        // actualiser
                        Actualiser();

                        // message box reussite 
                        MessageBox.Show("L'ouvrage a été modifié", "Modification terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
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
