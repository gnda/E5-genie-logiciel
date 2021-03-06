using Echecs.IHM;

namespace Echecs.Domaine
{
    public class ToursBase : Piece
    {
        public ToursBase(Joueur joueur) : base(joueur, TypePiece.Tour) { }

        public override bool Deplacer(Case destination)
        {
            destination.Link(this);

            return true;
        }
    }
}