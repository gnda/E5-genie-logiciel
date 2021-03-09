namespace Echecs.Domaine
{
    public class Case
    {
        // attributs
        public int x, y;

        // associations
        public Echiquier echiquier;
        public Piece piece;

        public Case(Echiquier echiquier, int x, int y)
        {
            this.echiquier = echiquier;
            this.x = x;
            this.y = y;
        }

        // methodes
        public void Link(Piece newPiece)
        {
            // 1. Deconnecter newPiece de l'ancienne case
            var old = newPiece.position;
            if (old != null)
            {
                old.UnLink();
            }

            // 2. Connecter newPiece à cette case
            piece = newPiece;
            newPiece.position = this;

            echiquier.partie.vue.ActualiserCase(x, y, piece.info);
        }

        public void UnLink()
        {
            // 1. Annule la référence sur l’objet Piece
            piece.position = null;
            piece = null;

            // 2. Soulève un événement ActualiserCase
            echiquier.partie.vue.ActualiserCase(x, y, null);
        }
    }
}
