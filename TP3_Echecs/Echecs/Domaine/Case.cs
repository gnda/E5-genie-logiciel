using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Case : IEvenements
    {
        // attributs
        private CouleurCamp color;
        private int col;
        private int row;

        // associations
        public Piece piece;

        // methodes
        public void Link(Piece newPiece)
        {
            //old = position
            // 1. Deconnecter newPiece de l'ancienne case
            UnLink(newPiece);

            // 2. Connecter newPiece à cette case
            this.piece = newPiece;
            //private ==> InfoPiece ip = new InfoPiece(newPiece.GetType(),this.color);
            //this.ActualiserCase(col,row,info_piece); // info_piece(type ?,couleur ok)
        }

        public void UnLink(Piece newPiece)
        {
            
            //1. Annule la référence sur l’objet Piece
            this.piece = null; 

            //2. Soulève un événement ActualiserCase
            // comment car ds Partie ???
        }
        
        public void ActualiserPartie(StatusPartie status)
        {
            throw new NotImplementedException();
        }

        public void ActualiserCase(int x, int y, InfoPiece info)
        {
            this.col = x;
            this.row = y;
            this.color = info.couleur;
            throw new NotImplementedException();
        }

        public void ActualiserCaptures(List<InfoPiece> pieces)
        {
            throw new NotImplementedException();
        }
    }
}
