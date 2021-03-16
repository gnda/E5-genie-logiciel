using System.Collections.Generic;
using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Joueur
    {
        // attributs
        public CouleurCamp couleur;

        // associations
        public Partie partie;
        public List<Piece> pieces = new List<Piece>();
        public List<InfoPiece> piecesCapturees = new List<InfoPiece>();

        // methodes
        public Joueur(Partie partie, CouleurCamp couleur)
        {
            this.couleur = couleur;
            this.partie = partie;

            // TODO : creation des pieces du joueur
            pieces.Add(new Tour(this));
            pieces.Add(new Cavalier(this));
            pieces.Add(new Fou(this));
            pieces.Add(new Dame(this));
            pieces.Add(new Roi(this));
            pieces.Add(new Fou(this));
            pieces.Add(new Cavalier(this));
            pieces.Add(new Tour(this));
            for (int i = 0; i < 8; i++)
            {
                pieces.Add(new Pion(this));
            }
        }

        // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case
        public void PlacerPieces(Echiquier echiquier)
        {
            int rangee = (couleur == CouleurCamp.Noire) ? -1 : 8;

            for (int i = 0; i < pieces.Count; i++)
            {
                int colonne = i % 8;

                if (couleur == CouleurCamp.Noire)
                {
                    rangee = (colonne == 0) ? ++rangee : rangee;
                }
                else
                {
                    rangee = (colonne == 0) ? --rangee : rangee;
                }
                
                echiquier.cases[colonne, rangee].Link(pieces[i]);
            }
        }

        public void CapturerPiece(Piece piece)
        {
            piecesCapturees.Add(piece.info);
            partie.vue.ActualiserCaptures(piecesCapturees);
        }
    }
}