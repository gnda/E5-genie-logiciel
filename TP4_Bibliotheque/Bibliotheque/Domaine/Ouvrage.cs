using System.Collections.Generic;

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
            Titre = titre;
            Auteur = auteur;
            Exemplaires = new List<Exemplaire>();
        }

        public override string ToString()
        {
            return "Id : " + Id
                 + " | Titre : " + Titre
                 + " | Auteur : " + Auteur
            ;
        }
    }
}
