using Echecs.IHM;

namespace Echecs.Domaine
{
    public class RoiBase : Piece
    {
        public RoiBase(Joueur joueur) : base(joueur, TypePiece.Roi) { }

        public override bool Deplacer(Case destination)
        {
            destination.Link(this);

            return true;
        }
    }
}