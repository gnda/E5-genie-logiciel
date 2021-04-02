using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Adherent
    {
        public virtual int Id { get; set; }
        public virtual string Nom { get; set; }

        public virtual IList<Pret> Prets { get; set; }

        public Adherent()
        {
            Prets = new List<Pret>();
        }

        public Adherent(string nom)
        {
            this.Nom = nom;
            Prets = new List<Pret>();
        }


        public virtual Pret Emprunte(Exemplaire ex)
        {
            if (ex.EstDisponible())
            {
                ex.Adherent = this;
                Pret pret = new Pret();
                pret.DateEmprunt = DateTime.Now;
                pret.Adherent = this;
                pret.Exemplaire = ex;
                Prets.Add(pret);
                return pret;
            }
            else
                throw new Exception("L'exemplaire est dejà emprunté");
        }

        public virtual void Retourne(Exemplaire exemplaire)

        {
            
            Pret pret = ObtenirLePret(exemplaire);
            if (pret != null)
            {
                exemplaire.Adherent = null;
                pret.DateRetour = DateTime.Now;

            }
            else
                throw new Exception("L'exemplaire est déjà retourné");
        }

        private Pret ObtenirLePret(Exemplaire livre)
        {

            return Prets.FirstOrDefault(
                pret => (pret.Exemplaire.Id == livre.Id && !pret.EstTermine())

            );

        }

        public override string ToString()
        {
            return
                  "Id : " + this.Id
                + " Nom : " + this.Nom
            ;
        }
    }
}
