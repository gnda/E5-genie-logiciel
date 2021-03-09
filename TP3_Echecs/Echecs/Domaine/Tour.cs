using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Tour : Piece
    {
        public Tour(Joueur joueur) : base(joueur, TypePiece.Tour) {
            peutGlisser = true;
            decDeplacements = new int[] { -10, -1, 1, 10 };
            InitTabDeplacements();
        }
    }
}