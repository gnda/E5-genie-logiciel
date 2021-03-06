using Echecs.IHM;

namespace Echecs.Domaine
{
    public class CavalierBase : Piece
    {
        public CavalierBase(Joueur joueur) : base(joueur, TypePiece.Cavalier) { }

    public override bool Deplacer(Case destination)
    {
        destination.Link(this);

        return true;
    }
}
}