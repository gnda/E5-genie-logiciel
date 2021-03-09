using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Pion: Piece
    {
        public Pion(Joueur joueur) : base(joueur, TypePiece.Pion) {
            peutGlisser = false;
            //InitTabDeplacements();
        }

        public override bool Deplacer(Case destination)
        {
            destination.Link(this);

            return true;
        }
    }
}