using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Ouvrage
    {
        public virtual int Id { get; set; }
        public virtual string Titre { get; set; }
        public virtual string Auteur { get; set; }

        public virtual IList<Exemplaire> Exemplaires { get; set; }

        public Ouvrage()
        {
            Exemplaires = new List<Exemplaire>();
        }

        public Ouvrage(string titre, string auteur)
        {
            this.Titre = titre;
            this.Auteur = auteur;
            Exemplaires = new List<Exemplaire>();
        }

        public override string ToString()
        {
            return
                  "Titre : " + this.Titre
                + " Auteur : " + this.Auteur
            ;
        }
    }
}
