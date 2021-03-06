using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Case
    {
        // attributs
        private Boolean color;
        private int col;
        private int row;

        // associations
        public Piece piece;

        // methodes
        public void Link(Piece newPiece)
        {
            // 1. Deconnecter newPiece de l'ancienne case
            UnLink(newPiece);
            // 2. Connecter newPiece à cette case
            this.piece = newPiece;
        }

        public void UnLink(Piece newPiece)
        {
            //1. Annule la référence sur l’objet Piece
            this.piece = null; 

            //2. Soulève un événement ActualiserCase
            // comment car ds Partie ???
        }


    }
}
