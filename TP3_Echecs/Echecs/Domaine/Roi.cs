using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Roi : Piece
    {
        public Roi(Joueur joueur) : base(joueur, TypePiece.Roi) {
            peutGlisser = false;
            decDeplacements = new int[] { -11, -10, -9, -1, 1, 9, 10, 11 };
            InitTabDeplacements();
        }
    }
}