using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Tour : Piece
    {
        public Tour(Joueur joueur) : base(joueur, TypePiece.Tour) {}

        public override bool Deplacer(Case destination)
        {
            if (CaseBloquee(destination) || 
                !DeplacementValide(destination) ||
                !position.CheminLibre(destination))
            {
                return false;
            }

            destination.Link(this);

            return true;
        }

        private bool DeplacementValide(Case destination)
        {
            int deltaX = destination.x - position.x;
            int deltaY = destination.y - position.y;

            return (deltaX == 0 && deltaY != 0) ||
                   (deltaX != 0 && deltaY == 0);
        }
    }
}