using System;
using System.Collections.Generic;
using Demineur.Jeu;
using IHM;

namespace Jeu
{
    public class Partie : IActions
    {
        Plateau plateau;
        List<Case> casesParcour = new List<Case>();

        public IReactions vue
        {
            get; set;
        }
        public List<Case> CasesParcour
        {
            get => casesParcour;
            set => casesParcour = value;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {
            plateau = new Plateau(largeur, hauteur, mines);
            vue.ActualiserComptage(mines);
        }

        public void DecouvrirCase(int x, int y)
        {
            Case c = plateau.Trouver(x, y);
            if (!c.Decouverte && !casesParcour.Contains(c))
            {
                casesParcour.Add(c);
                bool minee = c.Decouvrir();
                plateau.IncrementerDecouvertes();

                if (minee)
                {
                    vue.AfficherCaseMinee(x, y, minee);
                    vue.PartiePerdue();
                }
                else
                {
                    int num = plateau.CompterVoisinMinee(c);

                    if (num == 0)
                    {
                        foreach (Case v in c.Voisines)
                        {
                            int[] coord = plateau.GetCoord(v);
                            if (coord != null)
                            {
                                DecouvrirCase(coord[0], coord[1]);
                            }
                        }
                    }
                    vue.AfficherCaseNumerotee(x, y, num);

                    bool gagnee = plateau.TesterSiGagne();

                    if (gagnee)
                    {
                        vue.PartieGagnee();
                    }
                }
            }
        }

        public void MarquerCase(int x, int y)
        {
            bool m = plateau.Marquer(x, y);
            vue.MarquerCase(x, y, m);
            vue.ActualiserComptage(plateau.Restantes);
        }

        public void TerminerPartie()
        {
            Console.WriteLine("Fin partie !");
        }
    }
}
