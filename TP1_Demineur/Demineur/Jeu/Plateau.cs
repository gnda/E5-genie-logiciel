using IHM;
using System;

namespace Demineur.Jeu
{
    public class Plateau
    {
        int largeur;
        int hauteur;
        Case[,] cases;
        int mines, decouvertes, restantes;
        IActions partie;

        public IActions Partie
        {
            get => partie;
            set => partie = value;
        }

        public Plateau(IActions partie, int largeur, int hauteur, int mines)
        {
            this.partie = partie;
            int minesCount = mines;
            this.largeur = largeur;
            this.hauteur = hauteur;
            restantes = mines;
            cases = new Case[largeur, hauteur];

            var random = new Random();
            bool[,] estMinee = new bool[largeur, hauteur];
            bool minee = false;

            do
            {
                int x = random.Next(0, largeur);
                int y = random.Next(0, hauteur);
                minee = estMinee[x, y];

                estMinee[x, y] = true;
                minesCount--;
            } while (minesCount > 0);

            for (int x = 0; x < largeur; x++)
            {
                for (int y = 0; y < hauteur; y++)
                {
                    cases[x, y] = new Case(this, x, y, estMinee[x, y]);

                    int N = hauteur - 1;
                    if (x > 0 && y > 0) Connecter(cases[x, y], cases[x - 1, y - 1]);
                    if (x > 0) Connecter(cases[x, y], cases[x - 1, y]);
                    if (y > 0) Connecter(cases[x, y], cases[x, y - 1]);
                    if (x > 0 && y < N) Connecter(cases[x, y], cases[x - 1, y + 1]);
                }
            }
        }

        void Connecter(Case a, Case b)
        {
            a.Connecter(b);
            b.Connecter(a);
        }
        public Case Trouver(int x, int y)
        {
            return cases[x, y];
        }
        public void IncrementerDecouvertes()
        {
            decouvertes++;
        }
        public void ModifierMarquees(bool marquee)
        {
            if (marquee) restantes --; else restantes++;

            partie.vue.ActualiserComptage(restantes);
        }
        public bool TesterSiGagne()
        {
            return decouvertes + mines == (largeur * hauteur) - 1;
        }
    }
}
