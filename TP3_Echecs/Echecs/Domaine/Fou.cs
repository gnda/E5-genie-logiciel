using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Fou : Piece
    {
        public Fou(Joueur joueur) : base(joueur, TypePiece.Fou) {
            peutGlisser = true;
            decDeplacements = new int[] { -11, -9, 9, 11 };
            InitTabDeplacements();
        }
    }
}