using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    abstract public class Piece
    {
        // attributs
        public InfoPiece info;
        public bool peutGlisser;
        // nombre de cases dans chaque direction
        public int[] decDeplacements;
        // table des déplacements autorisés
        public bool[,] tabDeplacements;

        // associations
        public Joueur joueur;
        public Case position;

        // methodes
        public Piece(Joueur joueur, TypePiece type)
        {
			this.joueur = joueur;
            info = InfoPiece.GetInfo(joueur.couleur, type);
            tabDeplacements = new bool[64, 64];
        }

        // initialisation de la table de déplacements
        protected void InitTabDeplacements()
        {
            for (int i = 0; i < 64; ++i)
            {
                for (int d = 0; d < decDeplacements.Length; d++)
                {
                    for (int n = i; ;)
                    {
                        n = Base.mailbox[Base.mailbox64[n] + decDeplacements[d]];
                        if (n == -1)
                            break;
                        tabDeplacements[i, n] = true;
                        if (!peutGlisser)
                            break;
                    }
                }
            }
        }

        // affichage de la table de déplacements
        protected void printTabDeplacements()
        {
            int cpt = 0;

            for (int i = 0; i < 64; ++i)
            {
                Console.WriteLine("Table de déplacements");

                for (int n = 0; n < 64; ++n)
                {
                    Console.Write(tabDeplacements[i, n] ? 1 : 0);

                    cpt = ++cpt % 8;
                    if (cpt == 0)
                    {
                        Console.Write('\n');
                    }
                }
                Console.Write('\n');
            }
        }

        private int CoordVersIndice(int x, int y)
        {
            return (x * 8) + y;
        }

        public virtual bool Deplacer(Case destination)
        {
            int indexCase = CoordVersIndice(position.x, position.y);
            int indexDesti = CoordVersIndice(destination.x, destination.y);

            if (tabDeplacements[indexCase, indexDesti])
            {
                destination.Link(this);
                return true;
            }

            return false;
        }
    }
}
