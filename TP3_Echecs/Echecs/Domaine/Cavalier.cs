using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Cavalier : Piece
    {
        public Cavalier(Joueur joueur) : base(joueur, TypePiece.Cavalier) {}

        public override bool Deplacer(Case destination)
        {
            if (CaseBloquee(destination) ||
                !DeplacementValide(destination))
            {
                return false;
            }

            destination.Link(this);

            return true;
        }

        private bool DeplacementValide(Case destination)
        {
            int deltaX = Math.Abs(destination.x - position.x);
            int deltaY = Math.Abs(destination.y - position.y);

            return (deltaX != 0 && deltaY != 0 ) && ((deltaX + deltaY) == 3);
        }
    }
}