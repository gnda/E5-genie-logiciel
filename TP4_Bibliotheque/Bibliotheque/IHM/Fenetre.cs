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
            // TODO:
            // 1. Recuperer l'identifiant de l'adherent selectionné
            string selectedTxt = listBoxAdherents.SelectedItem as string;
            Adherent adherent = serviceAdherents.ObtenirListe()
                .Find(a => a.ToString() == selectedTxt);

            if (adherent != null && adherents.Count > 0) { 
                // 2. Recuperer la liste des prets associés à l'adherent
                Adherent adh = adherents.Find(a => a.Id == adherent.Id);
                prets = adh.Prets;
                // 3. Afficher la liste des prets
                AfficheList(prets, listBoxPrets);
            }
        }

        void ActualiserExemplaires()
        {
            // TODO:
            // 1. Recuperer l'identifiant de l'ouvrage selectionné
            string selectedTxt = listBoxOuvrages.SelectedItem as string;
            Ouvrage ouvrage = serviceOuvrages.ObtenirListe()
                .Find(o => o.ToString() == selectedTxt);

            // 2. Recuperer la liste des exemplaires associés à l'ouvrage
            if (ouvrage != null && ouvrages != null && ouvrages.Count > 0) {
                exemplaires = serviceExemplaires.ObtenirListeParOuvrage(ouvrage.Id);
            }
            else if (exemplaires != null)
            {
                exemplaires.Clear();
            }

            // 3. Afficher la liste des exemplaires
            if (exemplaires != null) { 
                AfficheList(exemplaires, listBoxExemplaires);
            }
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
            if (adherents.Count > 0 && exemplaires.Count > 0) {
                // 1. Recuperer l'identifiant de l'adherent selectionné
                string selectedTxt = listBoxAdherents.SelectedItem as string;
                Adherent adherent = adherents
                    .Find(a => a.ToString() == selectedTxt);
                // 2. Recuperer l'identifiant de l'exemplaire selectionné
                selectedTxt = listBoxExemplaires.SelectedItem as string;
                Exemplaire exemplaire = (exemplaires as List<Exemplaire>)
                    .Find(ex => ex.ToString() == selectedTxt);
                try
                {
                    // 3. Execution de l'emprunt
                    adherent.Emprunte(exemplaire);
                    // 4. Mis à jour de l'IHM
                    Actualiser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Emprunt échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Pas d'adhérent ou d'exemplaire !", "Emprunt échoué", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRetourner_Click(object sender, EventArgs e)
        {
            // TODO:
            if (exemplaires != null && exemplaires.Count > 0) {
                // 1. Recuperer l'identifiant de l'exemplaire selectionné
                string selectedTxt = listBoxExemplaires.SelectedItem as string;
                Exemplaire exemplaire = (exemplaires as List<Exemplaire>)
                    .Find(ex => ex.ToString() == selectedTxt);
                try
                {
                    // 2. Execution du retour
                    if (exemplaire.Adherent != null)
                    {
                        exemplaire.Adherent.Retourne(exemplaire);
                    } else
                    {
                        throw new Exception("Exemplaire non emprunté !");
                    }
                    
                    // 3. Mis à jour de l'IHM
                    Actualiser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Retour échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Pas d'exemplaire !", "Retour échoué", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAjouterAdherent_Click(object sender, EventArgs e)
        {
            FenetreForm_Adherent frm = new FenetreForm_Adherent(serviceAdherents, adherents, "Ajouter Adhérent");
            frm.Show();
        }

        private void buttonModifierAdherent_Click(object sender, EventArgs e)
        {
            string selectedTxt = listBoxAdherents.SelectedItem as string;
            Adherent adherent = adherents
                .Find(a => a.ToString() == selectedTxt);
            if (adherent != null)
            {
                FenetreForm_Adherent frm = new FenetreForm_Adherent(serviceAdherents, adherents, "Modifier Adhérent", adherent);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un adhérent", "Erreur : Absence de selection d'un adhérent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSupprimerAdherent_Click(object sender, EventArgs e)
        {
            string selectedTxt = listBoxAdherents.SelectedItem as string;
            Adherent adherent = adherents
                .Find(a => a.ToString() == selectedTxt);
            if (adherent != null) {
                if (MessageBox.Show("Etes-vous certain de supprimer :" + adherent.Nom + " ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try { 
                        serviceAdherents.Supprimer(adherent);
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Actualiser();
                }
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un adhérent", "Erreur : Absence de selection d'un adhérent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void buttonAjouterOuvrage_Click(object sender, EventArgs e)
        {
            FenetreForm_Ouvrage frm = new FenetreForm_Ouvrage(serviceOuvrages, ouvrages, "Ajouter Ouvrage");
            frm.Show();
        }

        private void buttonModifierOuvrage_Click(object sender, EventArgs e)
        {
            string selectedTxt = listBoxOuvrages.SelectedItem as string;
            Ouvrage ouvrage = ouvrages
                .Find(o => o.ToString() == selectedTxt);
            if (ouvrage != null)
            {
                FenetreForm_Ouvrage frm = new FenetreForm_Ouvrage(serviceOuvrages, ouvrages, "Modifier Ouvrage", ouvrage);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un ouvrage", "Erreur : Absence de selection d'un ouvrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSupprimerOuvrage_Click(object sender, EventArgs e)
        {
            string selectedTxt = listBoxOuvrages.SelectedItem as string;
            Ouvrage ouvrage = ouvrages
                .Find(o => o.ToString() == selectedTxt);
            if (ouvrage != null)
            {
                if (MessageBox.Show("Etes-vous certain de supprimer :" + ouvrage + " ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    serviceOuvrages.Supprimer(ouvrage);
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
            FenetreForm_Exemplaire frm = new FenetreForm_Exemplaire(serviceOuvrages, ouvrages, serviceExemplaires, exemplaires, "Ajouter Exemplaire");
            frm.Show();
        }

        private void buttonModifierExemplaire_Click(object sender, EventArgs e)
        {
            string selectedTxt = listBoxExemplaires.SelectedItem as string;
            Exemplaire exemplaire = (exemplaires as List<Exemplaire>)
                .Find(ex => ex.ToString() == selectedTxt);
            if (exemplaire != null)
            {
                FenetreForm_Exemplaire frm = new FenetreForm_Exemplaire(serviceOuvrages, ouvrages, serviceExemplaires, exemplaires, "Modifier Exemplaire", exemplaire);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un exemplaire", "Erreur : Absence de selection d'un exemplaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSupprimerExemplaire_Click(object sender, EventArgs e)
        {
            string selectedTxt = listBoxExemplaires.SelectedItem as string;
            Exemplaire exemplaire = (exemplaires as List<Exemplaire>)
                .Find(ex => ex.ToString() == selectedTxt);
            if (exemplaire != null)
            {
                if (MessageBox.Show("Etes-vous certain de supprimer :" + exemplaire + " ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    serviceExemplaires.Supprimer(exemplaire);
                    Actualiser();
                }
            }
            else
            {
                MessageBox.Show("Vous devez sélectionner un Exemplaire", "Erreur : Absence de sélection d'un exemplaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}