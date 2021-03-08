using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Exemplaire
    {
        public virtual int Id { get; set; }
        public virtual string Etat { get; set; }
        public virtual Adherent Adherent { get; set; }
        public virtual Ouvrage Ouvrage { get; set; }
        public Exemplaire()
        {

        }
        public Exemplaire(string etat, Ouvrage ouvrage)
        {
            this.Etat = etat;
            this.Ouvrage = ouvrage;
        }
        public virtual bool EstDisponible()
        {
            if (Adherent == null)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return
                  " Ouvrage : " + this.Ouvrage.ToString()
                + " Id : " + this.Id
                + " Etat : " + this.Etat
            ;
        }

    }
}
