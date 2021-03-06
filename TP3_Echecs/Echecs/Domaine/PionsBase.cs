using Echecs.IHM;

namespace Echecs.Domaine
{
    public class PionsBase : Piece
    {
        public PionsBase(Joueur joueur) : base(joueur, TypePiece.Pion) { }

        public override bool Deplacer(Case destination)
        {
            destination.Link(this);

            return true;
        }
    }
}s