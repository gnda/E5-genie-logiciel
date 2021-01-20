using System;
using Demineur.Jeu;
using IHM;

namespace Jeu
{
    public class Partie : IActions
    {
        Plateau plateau;

        public IReactions vue
        {
            get; set;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {
            plateau = new Plateau(this, largeur, hauteur, mines);
            vue.ActualiserComptage(mines);
        }

        public void DecouvrirCase(int x, int y)
        {
            Case c = plateau.Trouver(x, y);
            bool minee = c.Decouvrir();

            if (minee)
            {
                vue.PartiePerdue();
            }
            else
            {
                bool gagnee = plateau.TesterSiGagne();
                if (gagnee)
                {
                    vue.PartieGagnee();
                }
            }
        }

        public void MarquerCase(int x, int y)
        {
            Case c = plateau.Trouver(x, y);
            c.Marquer(x, y);
        }

        public void TerminerPartie()
        {
            Console.WriteLine("Fin partie !");
        }
    }
}
