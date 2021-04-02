using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bibliotheque.IHM;
using Domaine;
using Service;

namespace IHM
{
    public partial class Fenetre : Form
    {
        ServiceExemplaires  serviceExemplaires;
        ServiceAdherents    serviceAdherents;
        ServiceOuvrages     serviceOuvrages;
        ServicePrets        servicePrets;

        IList<Exemplaire> exemplaires;
        List<Adherent>   adherents;
        List<Ouvrage>    ouvrages;
        IList<Pret>       prets;

        public Fenetre(ServiceAdherents adherents, ServiceOuvrages ouvrages, ServicePrets prets, ServiceExemplaires exemplaires)
        {
            InitializeComponent();

            InitialiserServices(adherents, ouvrages, prets, exemplaires);
            Actualiser();
        }

        public void Actualiser()
        {
            ActualiserAdherents();
            ActualiserOuvrages();
            ActualiserPrets();
        }

        void InitialiserServices(ServiceAdherents adherents, ServiceOuvrages ouvrages, ServicePrets prets, ServiceExemplaires exemplaires)
        {
            serviceExemplaires = exemplaires;
            serviceAdherents  = adherents;
            serviceOuvrages   = ouvrages;
            servicePrets      = prets;
        }

        void ActualiserAdherents()
        {
            adherents = serviceAdherents.ObtenirListe();
            AfficherListe(adherents, listBoxAdherents);
            ActualiserPrets();
        }

        void ActualiserOuvrages()
        {
            ouvrages = serviceOuvrages.ObtenirListe();

            AfficherListe(ouvrages, listBoxOuvrages);
            ActualiserExemplaires();
        }

        void ActualiserPrets()
        {
            int idx = listBoxAdherents.SelectedIndex;
            // TODO:
            // 1. Recuperer l'identifiant de l'adherent selectionné
            int identifiant = adherents[idx].Id - 1;

            if (identifiant >= 0)
            {
                // 2. Recuperer la liste des prets associés à l'adherent
                Adherent adh = adherents[idx];
                prets = adh.Prets;
                // 3. Afficher la liste des prets
                AfficheList(prets, listBoxPrets);
            }
            else
            {
                MessageBox.Show("Probleme actu pret", "Erreur : adhérent négatif", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ActualiserExemplaires()
        {
            int idx = listBoxOuvrages.SelectedIndex;

            // TODO:
            // 1. Recuperer l'identifiant de l'ouvrage selectionné
            int identifiant = ouvrages[idx].Id - 1;
            // 2. Recuperer la liste des exemplaires associés à l'ouvrage
            Ouvrage ouv = ouvrages[idx];
            exemplaires = ouv.Exemplaires;
            // 3. Afficher la liste des exemplaires
            AfficheList(exemplaires, listBoxExemplaires);

        }

        private void listBoxOuvrages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserExemplaires();
        }

        private void listBoxAhderents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserPrets();
        }

        void AfficherListe<T>(List<T> items, ListBox box)
        {
            List<string> liste = new List<string>();
            foreach (T a in items)
                liste.Add(a.ToString());
            box.DataSource = liste;
        }

        void AfficheList<T>(IList<T> items,ListBox box)
        {
            List<string> liste = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                liste.Add(items[i].ToString());
            }
            box.DataSource = liste;
        }

        private void buttonEmprunter_Click(object sender, EventArgs e)
        {
            // TODO:
            // 1. Recuperer l'identifiant de l'adherent selectionné
            int idx_adh = listBoxAdherents.SelectedIndex;
            // 2. Recuperer l'identifiant de l'exemplaire selectionné
            int idx_exe = listBoxExemplaires.SelectedIndex;
            try
            {
                // 3. Execution de l'emprunt
                adherents[idx_adh].Emprunte(exemplaires[idx_exe]);
                // 4. Mis à jour de l'IHM
                Actualiser();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Emprunt échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRetourner_Click(object sender, EventArgs e)
        {
            // TODO:
            // 1. Recuperer l'identifiant de l'exemplaire selectionné
            int idx_exe = listBoxExemplaires.SelectedIndex;
            try
            {
                // 2. Execution du retour
                Exemplaire exe = exemplaires[idx_exe];
                exe.Adherent.Retourne(exe);
                // 3. Mis à jour de l'IHM
                Actualiser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retour échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_ClickExemplaire(EventArgs e)
        {
        }

        private void buttonAjouterAdherent_Click(object sender, EventArgs e)
        {
            FenetreForm_Adherent frm = new FenetreForm_Adherent(serviceAdherents, adherents, "Ajouter Adhérent", -1);
            frm.Show();
        }

        private void buttonModifierAdherent_Click(object sender, EventArgs e)
        {
            int idx_adh = listBoxAdherents.SelectedIndex;
            if (idx_adh >= 0)
            {
                FenetreForm_Adherent frm = new FenetreForm_Adherent(serviceAdherents, adherents, "Modifier Adhérent", idx_adh);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un adhérent", "Erreur : Absence de selection d'un adhérent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSupprimerAdherent_Click(object sender, EventArgs e)
        {
            int idx_adh = listBoxAdherents.SelectedIndex;
            if (idx_adh >= 0) {
                if (MessageBox.Show("Etes-vous certain de supprimer :" + this.adherents[idx_adh].Nom + " ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    serviceAdherents.Supprimer(this.adherents[idx_adh]);
                    Actualiser();
                }
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un adhérent", "Erreur : Absence de selection d'un adhérent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonAjouterOuvrage_Click(object sender, EventArgs e)
        {
            FenetreForm_Ouvrage frm = new FenetreForm_Ouvrage(serviceOuvrages, ouvrages, "Ajouter Ouvrage", -1);
            frm.Show();
        }

        private void buttonModifierOuvrage_Click(object sender, EventArgs e)
        {
            int idx_ouv = listBoxOuvrages.SelectedIndex;
            if (idx_ouv >= 0)
            {
                FenetreForm_Ouvrage frm = new FenetreForm_Ouvrage(serviceOuvrages, ouvrages, "Modifier Ouvrage", idx_ouv);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un ouvrage", "Erreur : Absence de selection d'un ouvrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSupprimerOuvrage_Click(object sender, EventArgs e)
        {
            int idx_ouv = listBoxOuvrages.SelectedIndex;
            if (idx_ouv >= 0)
            {
                if (MessageBox.Show("Etes-vous certain de supprimer :" + this.ouvrages[idx_ouv].Titre + " " + this.ouvrages[idx_ouv].Auteur + " ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    serviceOuvrages.Supprimer(this.ouvrages[idx_ouv]);
                    Actualiser();
                }
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un ouvrage", "Erreur : Absence de selection d'un ouvrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAjouterExemplaire_Click(object sender, EventArgs e)
        {
            FenetreForm_Exemplaire frm = new FenetreForm_Exemplaire(serviceOuvrages, ouvrages, serviceExemplaires, exemplaires, "Ajouter Exemplaire", -1);
            frm.Show();
        }

        private void buttonModifierExemplaire_Click(object sender, EventArgs e)
        {
            int idx_exe = listBoxExemplaires.SelectedIndex;
            if (idx_exe >= 0)
            {
                FenetreForm_Exemplaire frm = new FenetreForm_Exemplaire(serviceOuvrages, ouvrages, serviceExemplaires, exemplaires, "Modifier Exemplaire", idx_exe);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un exemplaire", "Erreur : Absence de selection d'un exemplaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSupprimerExemplaire_Click(object sender, EventArgs e)
        {
            int idx_exe = listBoxExemplaires.SelectedIndex;
            if (idx_exe >= 0)
            {
                if (MessageBox.Show("Etes-vous certain de supprimer :" + this.exemplaires[idx_exe].Ouvrage.Titre + " " + this.exemplaires[idx_exe].Ouvrage.Auteur + " Etat: " + this.exemplaires[idx_exe].Etat+ " ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    serviceExemplaires.Supprimer(this.exemplaires[idx_exe]);
                    Actualiser();
                }
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un Exemplaire", "Erreur : Absence de selection d'un exemplaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}