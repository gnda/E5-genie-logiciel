using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Fou : Piece
    {
        public Fou(Joueur joueur) : base(joueur, TypePiece.Fou) {}

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
            int deltaX = Math.Abs(destination.x - position.x);
            int deltaY = Math.Abs(destination.y - position.y);

            return deltaX == deltaY;
        }
    }
}