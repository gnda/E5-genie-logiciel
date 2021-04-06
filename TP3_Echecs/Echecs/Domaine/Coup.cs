namespace Echecs.Domaine
{
    public class Coup
    {
        Piece piece;
        Case depart;
        Case arrivee;

        public Coup(Case depart, Case arrivee)
        {
            this.depart = depart;
            this.arrivee = arrivee;
            piece = this.depart.piece;
        }

        public bool Effectuer()
        {
            return piece.Deplacer(arrivee);
        }
    }
}
