﻿using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Dame : Piece
    {
        public Dame(Joueur joueur) : base(joueur, TypePiece.Dame) {
            peutGlisser = true;
            decDeplacements = new int[] { -11, -10, -9, -1, 1, 9, 10, 11 };
            InitTabDeplacements();
        }       
    }
}
