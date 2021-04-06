using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Dame : Piece
    {
        public Dame(Joueur joueur) : base(joueur, TypePiece.Dame) {}

        public override bool Deplacer(Case destination)
        {
            if (CaseBloquee(destination) || !position.CheminLibre(destination))
            {
                return false;
            }

            destination.Link(this);

            return true;
        }
    }
}
