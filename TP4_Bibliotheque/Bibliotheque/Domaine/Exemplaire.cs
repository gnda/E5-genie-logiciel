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
            Etat = etat;
            Ouvrage = ouvrage;
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
            return " Ouvrage : " + Ouvrage.ToString()
                 + " : { Id : " + Id
                 + " | Etat : " + Etat
                 + " | Emprunté : " + (Adherent != null ? "Oui" : "Non")
                 + " }"
            ;
        }

    }
}
