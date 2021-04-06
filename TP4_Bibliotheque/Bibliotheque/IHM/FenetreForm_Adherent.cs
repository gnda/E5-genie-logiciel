using Domaine;
using IHM;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bibliotheque.IHM
{
    public partial class FenetreForm_Adherent : Form
    {
        ServiceAdherents serviceAdherents;
        List<Adherent> adherents;
        Adherent adherent;

        public FenetreForm_Adherent(ServiceAdherents serviceAdherents, 
            List<Adherent> adherents, string titre, Adherent adherent = null)
        {
            
            InitializeComponent();
            this.serviceAdherents = serviceAdherents;
            this.adherents = adherents;
            if (adherent != null)
            {
                this.adherent = adherents.Find(a => a.Id == adherent.Id);
            }
            label_title.Text = titre;
            btn.Text = titre;
            if (this.adherent != null)
            {
                textBox_nom.Text = adherent.Nom;
            }
        }

        private void Actualiser()
        {
            var mainForm = Application.OpenForms.OfType<Fenetre>().Single();
            mainForm.Actualiser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_nom.Text != "")
            {
                // déjà existant ?
                bool to_return = false;
                for(int i = 0; (i < adherents.Count) && to_return==false; i++)
                {
                    if (adherents[i].Nom == textBox_nom.Text)
                    {
                        to_return = true;
                    }
                }
                if (!to_return)
                {
                    if (adherent == null)
                    {
                        // ajouter
                        serviceAdherents.Ajouter(new Adherent(textBox_nom.Text));
                        // actualiser
                        Actualiser();
                        // message box reussite 
                        MessageBox.Show("L'adhérent a été ajouté", "Ajout terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        // modifier
                        adherent.Nom = textBox_nom.Text;
                        serviceAdherents.Modifier(adherent);
                        // actualiser
                        Actualiser();

                        // message box reussite 
                        MessageBox.Show("L'adhérent a été modifié", "Modification terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
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
    }
}
