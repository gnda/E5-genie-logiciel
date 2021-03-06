using Echecs.IHM;

namespace Echecs.Domaine
{
    public class FouBase :  Piece
    {
        public FouBase(Joueur joueur) : base(joueur, TypePiece.Fou) { }

        public override bool Deplacer(Case destination)
        {
            destination.Link(this);

            return true;
        }
    }
}