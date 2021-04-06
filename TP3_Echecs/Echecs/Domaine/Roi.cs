using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Roi : Piece
    {
        public Roi(Joueur joueur) : base(joueur, TypePiece.Roi) {}

        public override bool Deplacer(Case destination)
        {
            if (CaseBloquee(destination) ||
               !position.CheminLibre(destination))
            {
                return false;
            }

            if (!TraiterPetitRoque(destination) &&
                !TraiterGrandRoque(destination))
            {
                if (!DeplacementValide(destination))
                {
                    return false;
                }
            }

            destination.Link(this);

            return true;
        }

        private bool DeplacementValide(Case destination)
        {
            int deltaX = Math.Abs(destination.x - position.x);
            int deltaY = Math.Abs(destination.y - position.y);

            return deltaX <= 1 && deltaY <= 1;
        }

        private bool TraiterPetitRoque(Case destination)
        {
            int y = (joueur.couleur == CouleurCamp.Blanche) ? 7 : 0;

            if ((destination.y == y) && ((destination.x + 1) <= 7))
            {
                InfoPiece typeTour = (joueur.couleur == CouleurCamp.Blanche) ?
                    InfoPiece.TourBlanche : InfoPiece.TourNoire;
                Piece p = position.echiquier.cases[destination.x + 1, y].piece;

                if (((destination.x - position.x) == 2) && (p.info == typeTour)
                    && ((destination.x - 1) >= 0))
                {
                    position.echiquier.cases[destination.x - 1, y].Link(p);
                    return true;
                }
            }

            return false;
        }

        private bool TraiterGrandRoque(Case destination)
        {
            int y = (joueur.couleur == CouleurCamp.Blanche) ? 7 : 0;

            if ((destination.y == y) && ((destination.x - 2) >= 0)) {
                InfoPiece typeTour = (joueur.couleur == CouleurCamp.Blanche) ?
                    InfoPiece.TourBlanche : InfoPiece.TourNoire;
                Piece p = position.echiquier.cases[destination.x - 2, y].piece;

                if (((destination.x - position.x) == -2) && (p.info == typeTour)
                    && ((destination.x + 1) <= 7))
                {
                    position.echiquier.cases[destination.x + 1, y].Link(p);
                    return true;
                }
            }

            return false;
        }
    }
}