using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Pion: Piece
    {
        private bool premierDeplacement = true;
        private bool enPassantPossible;
        public Pion(Joueur joueur) : base(joueur, TypePiece.Pion) {}

        public override bool Deplacer(Case destination)
        {
            var sauvePremierDeplacement = premierDeplacement;

            if (!DeplacementValide(destination) ||
                CaseBloquee(destination) ||
                !position.CheminLibre(destination))
            {
                premierDeplacement = sauvePremierDeplacement;
                return false;
            }

            premierDeplacement = false;

            if (DeplacementEnPassant(destination, true))
            {
                destination.Link(this);
            }
            else if (!DeplacementDiagonal(destination))
            {
                if (destination.piece != null)
                {
                    return false;
                }
                else
                {
                    destination.Link(this);
                }
            }
            else if (DeplacementDiagonal(destination) && destination.piece != null)
            {
                destination.Link(this);
            }
            else
            {
                return false;
            }

            // Promotion
            if (DetecterPromotion(destination))
            {
                Dame d = new Dame(joueur);
                d.position = destination;
                destination.piece = d;
                position.echiquier.partie.vue
                    .ActualiserCase(destination.x, destination.y, d.info);
            }

            return true;
        }

        private bool DeplacementValide(Case destination)
        {
            return DeplacementVertical(destination) ||
                   DeplacementEnPassant(destination) || 
                   DeplacementDiagonal(destination);
        }

        private bool DeplacementVertical(Case destination)
        {
            int deltaX = destination.x - position.x;
            int deltaY = destination.y - position.y;
            int YAutorise = (joueur.couleur == CouleurCamp.Blanche) ? -1 : 1;

            if (premierDeplacement)
            {
                if (!enPassantPossible)
                {
                    if ((deltaX == 0) && (deltaY == 2 * YAutorise))
                    {
                        enPassantPossible = true;
                        return true;
                    }
                }
            }
            
            return (deltaX) == 0 && ((deltaY) == 1 * YAutorise);
        }

        private bool DeplacementDiagonal(Case destination)
        {
            int deltaX = Math.Abs(destination.x - position.x);
            int deltaY = Math.Abs(destination.y - position.y);

            return (deltaX == deltaY) && deltaX == 1;
        }

        private bool DetecterPromotion(Case destination)
        {
            return ((joueur.couleur == CouleurCamp.Blanche) ? 
                (destination.y == 0) : (destination.y == 7));
        }

        private bool DeplacementEnPassant(Case destination, bool effectuerCapture = false)
        {
            int y = (joueur.couleur == CouleurCamp.Blanche) ? 2 : 5; 
            
            if (!DeplacementDiagonal(destination) || !(destination.y == y))
            {
                return false;
            }

            int YPieceACapture = y + ((joueur.couleur == CouleurCamp.Blanche) ? 1 : -1);
            Piece pieceACapture = position.echiquier.cases[destination.x, YPieceACapture].piece;

            InfoPiece typePionAdverse = (joueur.couleur == CouleurCamp.Blanche) ? 
                InfoPiece.PionNoir : InfoPiece.PionBlanc;

            if (pieceACapture != null) { 
                if (pieceACapture.info != typePionAdverse)
                {
                    return false;
                }

                Pion pionCapture = (pieceACapture as Pion);

                if (pionCapture.enPassantPossible)
                {
                    if (effectuerCapture)
                    {
                        pieceACapture.position.UnLink();
                        joueur.CapturerPiece(pieceACapture);
                    }
                    return true;
                }
            }

            return false;
        }
    }
}