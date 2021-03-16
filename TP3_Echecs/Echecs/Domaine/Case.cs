using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Case
    {
        // attributs
        public int x, y;
        public CouleurCamp couleur;

        // associations
        public Echiquier echiquier;
        public Piece piece;

        public Case(Echiquier echiquier, int x, int y, CouleurCamp couleur)
        {
            this.echiquier = echiquier;
            this.x = x;
            this.y = y;
            this.couleur = couleur;
        }

        // methodes
        public void Link(Piece newPiece)
        {
            // On ne veut pas lier une piece nulle
            if (newPiece == null)
            {
                return;
            }

            // 1. Deconnecter newPiece de l'ancienne case
            var old = newPiece.position;
            if (old != null)
            {
                old.UnLink();
            }

            // Capturer la piece dans la case si on en a une
            if (piece != null)
            {
                newPiece.joueur.CapturerPiece(piece);
            }

            // 2. Connecter newPiece à cette case
            piece = newPiece;
            newPiece.position = this;

            echiquier.partie.vue.ActualiserCase(x, y, piece.info);
        }

        public void UnLink()
        {
            // 1. Annule la référence sur l’objet Piece
            piece = null;

            // 2. Soulève un événement ActualiserCase
            echiquier.partie.vue.ActualiserCase(x, y, null);
        }

        public bool CheminLibre(Case destination)
        {
            int deltaX = destination.x - x;
            int deltaY = destination.y - y;
            int distance = (deltaX == 0) ? deltaY : deltaX;

            bool deplacementVertical = deltaX == 0;
            bool deplacementHorizontal = deltaY == 0;
            bool deplacementDiagonal = Math.Abs(deltaX) == Math.Abs(deltaY);

            // Si on est dans aucun de ces 3 cas, alors le déplacement n'est pas autorisé
            if (!(deplacementVertical || deplacementHorizontal || deplacementDiagonal))
            {
                return false;
            }

            for (int i = 1; i < distance; i++)
            {
                int testX = x + i * Math.Sign(deltaX);
                int testY = y + i * Math.Sign(deltaY);

                // Deplacement interdit s'il y a une pièce sur le chemin
                if (echiquier.cases[testX, testY].piece != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
