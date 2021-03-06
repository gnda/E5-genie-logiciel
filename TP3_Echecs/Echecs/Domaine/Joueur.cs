using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Echecs.IHM;
using TP2_Echecs.Domaine;

namespace Echecs.Domaine
{
    public class Joueur
    {
        // attributs
        public CouleurCamp couleur;

        // associations
        public Partie partie;
        public List<Piece> pieces = new List<Piece>();


        // methodes
        public Joueur(Partie partie, CouleurCamp couleur)
        {
            this.couleur = couleur;
            this.partie = partie;

            //définission

            // TODO : creation des pieces du joueur
            pieces.Add( new Dame(this) );
            pieces.Add(new ToursBase(this));
            pieces.Add(new ToursBase(this));
            pieces.Add(new FouBase(this));
            pieces.Add(new FouBase(this));
            pieces.Add(new RoiBase(this));
            pieces.Add(new CavalierBase(this));
            pieces.Add(new CavalierBase(this));
            for (int i = 0; i<8; i++)
            {
                pieces.Add(new PionsBase(this));
            }
        }

        internal void PlacerPieces(Echiquier echiquier)
        {
            throw new NotImplementedException();
        }

        // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case
        //public void PlacerPieces(Echiquier echiquier)
        //{
        //    if( couleur == CouleurCamp.Noire )
        //    {
        //        echiquier.cases[3, 0].Link( pieces[0] );
        //    }
        //    else
        //    {
        //        echiquier.cases[3, 7].Link( pieces[0] );
        //    }
        //}
    }
}
