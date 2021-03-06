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
        private Piece piece;

        // methodes
        public void Link(Piece newPiece)
        {
            // 1. Deconnecter newPiece de l'ancienne case

            // 2. Connecter newPiece à cette case
        }

        
    }
}
