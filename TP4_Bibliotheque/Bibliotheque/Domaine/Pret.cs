using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Pret
    {
        public virtual int Id { get; set; }
        public virtual DateTime DateEmprunt { get; set; }
        public virtual DateTime DateRetour { get; set; }
        public virtual Exemplaire Exemplaire { get; set; }
        public virtual Adherent Adherent { get; set; }

        public virtual bool EstTermine()
        {
            if (DateRetour == DateTime.MinValue)
                return false;
            else
                return true;
        }

        public override string ToString()
        {
            return
                //  "Id : " + this.Id
                //+ 
                  Exemplaire.ToString()
                + " E : " + this.DateEmprunt.ToShortDateString()
                + " R : " + this.DateRetour.ToShortDateString()
                
            ;
        }
    }
}
