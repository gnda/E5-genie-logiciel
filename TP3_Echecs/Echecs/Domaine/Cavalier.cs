using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Cavalier : Piece
    {
        public Cavalier(Joueur joueur) : base(joueur, TypePiece.Cavalier) {
            peutGlisser = false;
            decDeplacements = new int[] { -21, -19, -12, -8, 8, 12, 19, 21 };
            InitTabDeplacements();
        }
    }
}