using Echecs.IHM;

namespace Echecs.Domaine
{
    abstract public class Piece
    {
        // attributs
        public InfoPiece info;

        // associations
        public Joueur joueur;
        public Case position;

        // methodes
        public Piece(Joueur joueur, TypePiece type)
        {
			this.joueur = joueur;
            info = InfoPiece.GetInfo(joueur.couleur, type);
        }

        // Déplacement vers la case c
        public abstract bool Deplacer(Case destination);

        // On ne peut pas aller sur une case occupée ou une case contenant une pièce
        // qui est de la même couleur que la pièce actuelle
        protected bool CaseBloquee(Case destination)
        {
            return destination.piece != null && destination.piece.info.couleur == info.couleur;
        }
    }
}
