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
    public partial class FenetreForm_Exemplaire : Form
    {
        ServiceOuvrages serviceOuvrages;
        List<Ouvrage> ouvrages;
        ServiceExemplaires serviceExemplaires;
        IList<Exemplaire> exemplaires;
        int idx;

        public FenetreForm_Exemplaire(
            ServiceOuvrages serviceOuvrages,
            List<Ouvrage> ouvrages,
            ServiceExemplaires serviceExemplaires,
            IList<Exemplaire> exemplaires,
            string titre,
            int idx
            )
        {
            InitializeComponent();
            this.idx = idx;
            this.ouvrages = ouvrages;
            this.serviceExemplaires = serviceExemplaires;
            this.serviceOuvrages = serviceOuvrages;
            this.exemplaires = exemplaires;
            label_title.Text = titre;
            btn.Text = titre;

            for (int i = 0; i < this.ouvrages.Count; i++)
            {
                comboBox_ouvrage.Items.Add(this.ouvrages[i].ToString());
            }
            if (this.idx != -1)
            {
                int index = comboBox_ouvrage.FindString(this.exemplaires[idx].Ouvrage.ToString());
                comboBox_ouvrage.SelectedIndex = index;
                textBox_nom.Text = exemplaires[idx].Etat;
            }

            
        }

        private void actualiser()
        {
            var mainForm = Application.OpenForms.OfType<Fenetre>().Single();
            mainForm.Actualiser();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
            // verifier si c'est remplie
            if (textBox_nom.Text != "" && comboBox_ouvrage.Text != "")
            {
                bool to_return = true;
                if (to_return)
                {
                    int id_ouvrage = comboBox_ouvrage.FindString(comboBox_ouvrage.Text);
                    if (id_ouvrage < 0)
                    {
                        MessageBox.Show("Item not found.");
                        comboBox_ouvrage.Text = String.Empty;
                    }
                    else
                    {
                        comboBox_ouvrage.SelectedIndex = id_ouvrage;
                    }
                    if (this.idx == -1)
                    {
                        serviceExemplaires.Ajouter(new Exemplaire(textBox_nom.Text, this.ouvrages[id_ouvrage]));
                        //actualiser
                        actualiser();
                        // message box reussite 
                        MessageBox.Show("L'exemplaire a été ajouté", "Ajout terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        // modifier
                        this.exemplaires[this.idx].Etat = textBox_nom.Text;
                        this.exemplaires[this.idx].Ouvrage = this.ouvrages[id_ouvrage];
                        serviceExemplaires.Modifier(this.exemplaires[this.idx]);
                        //actualiser
                        actualiser();

                        // message box reussite 
                        MessageBox.Show("L'exemplaire a été modifié", "Modification terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                else
                {
                    // message box echec
                    MessageBox.Show("Un exemplaire avec le même nom et auteur est existant", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
