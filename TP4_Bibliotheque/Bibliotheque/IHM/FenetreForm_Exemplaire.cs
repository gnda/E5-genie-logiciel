using Domaine;
using IHM;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bibliotheque.IHM
{
    public partial class FenetreForm_Exemplaire : Form
    {
        ServiceOuvrages serviceOuvrages;
        List<Ouvrage> ouvrages;
        ServiceExemplaires serviceExemplaires;
        IList<Exemplaire> exemplaires;
        Exemplaire exemplaire;

        public FenetreForm_Exemplaire(
            ServiceOuvrages serviceOuvrages,
            List<Ouvrage> ouvrages,
            ServiceExemplaires serviceExemplaires,
            IList<Exemplaire> exemplaires,
            string titre,
            Exemplaire exemplaire = null
            )
        {
            InitializeComponent();
            this.ouvrages = ouvrages;
            this.serviceExemplaires = serviceExemplaires;
            this.serviceOuvrages = serviceOuvrages;
            this.exemplaires = exemplaires;
            if (exemplaire != null)
            {
                this.exemplaire = (exemplaires as List<Exemplaire>)
                    .Find(ex => ex.Id == exemplaire.Id);
            }
            label_title.Text = titre;
            btn.Text = titre;

            for (int i = 0; i < this.ouvrages.Count; i++)
            {
                comboBox_ouvrage.Items.Add(this.ouvrages[i].ToString());
            }

            comboBox_etat.Items.Add("Neuf");
            comboBox_etat.Items.Add("Abîmé");
            comboBox_etat.Items.Add("Usé");
            comboBox_etat.Items.Add("Correct");

            if (this.exemplaire != null)
            {
                int index = comboBox_ouvrage.FindString(this.exemplaire.Ouvrage.ToString());
                comboBox_ouvrage.SelectedIndex = index;
                index = comboBox_etat.FindString(this.exemplaire.Etat);
                comboBox_etat.SelectedIndex = index;
            }
        }

        private void Actualiser()
        {
            var mainForm = Application.OpenForms.OfType<Fenetre>().Single();
            mainForm.Actualiser();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (comboBox_etat.Text != "" && comboBox_ouvrage.Text != "")
            {
                bool to_return = true;
                if (to_return)
                {
                    int id_ouvrage = comboBox_ouvrage.FindString(comboBox_ouvrage.Text);
                    if (id_ouvrage < 0)
                    {
                        MessageBox.Show("L'ouvrage n'existe pas");
                        comboBox_ouvrage.Text = String.Empty;
                        return;
                    }
                    else
                    {
                        comboBox_ouvrage.SelectedIndex = id_ouvrage;
                    }
                    if (exemplaire == null)
                    {
                        serviceExemplaires.Ajouter(new Exemplaire(comboBox_etat.Text, ouvrages[id_ouvrage]));
                        //actualiser
                        Actualiser();
                        // message box reussite 
                        MessageBox.Show("L'exemplaire a été ajouté", "Ajout terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        // modifier
                        exemplaire.Etat = comboBox_etat.Text;
                        exemplaire.Ouvrage = ouvrages[id_ouvrage];
                        serviceExemplaires.Modifier(exemplaire);
                        // actualiser
                        Actualiser();

                        // message box reussite 
                        MessageBox.Show("L'exemplaire a été modifié", "Modification terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
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
