using System;

namespace Demineur.Jeu
{
    class Plateau
    {
        public int largeur;
        public int hauteur;
        Case[,] cases;
        int mines, decouvertes, restantes;

        public int Restantes
        {
            get => restantes;
            set => restantes = value;
        }

        public Plateau(int largeur, int hauteur, int mines)
        {
            int minesCount = mines;
            this.largeur = largeur;
            this.hauteur = hauteur;
            restantes = mines;
            cases = new Case[largeur, hauteur];

            var random = new Random();

            for (int x = 0; x < largeur; x++)
            {
                for (int y = 0; y < hauteur; y++)
                {
                    cases[x, y] = new Case();

                    int N = hauteur - 1;
                    if (x > 0 && y > 0) Connecter(cases[x, y], cases[x - 1, y - 1]);
                    if (x > 0) Connecter(cases[x, y], cases[x - 1, y]);
                    if (y > 0) Connecter(cases[x, y], cases[x, y - 1]);
                    if (x > 0 && y < N) Connecter(cases[x, y], cases[x - 1, y + 1]);
                }
            }

            Case c;

            do {
                int x = random.Next(0, largeur);
                int y = random.Next(0, hauteur);
                c = cases[x, y];

                c.Minee = true;
                minesCount--;
            } while (c.Minee && minesCount > 0);
        }
        void Connecter(Case a, Case b)
        {
            a.Connecter(b);
            b.Connecter(a);
        }
        public int CompterVoisinMinee(Case c)
        {
            int minee = c.Minee ? 1 : 0;

            foreach (Case v in c.Voisines) {
                minee += v.Minee ? 1 : 0;
            }

            return minee;
        }
        public bool Marquer(int x, int y)
        {
            cases[x, y].Marquer();
            ModifierMarquees(cases[x, y].Marquee);

            return cases[x, y].Marquee;
        }
        public Case Trouver(int x, int y)
        {
            return cases[x, y];
        }
        public int[] GetCoord(Case c)
        {
            for (int x = 0; x < largeur; x++)
            {
                for (int y = 0; y < hauteur; y++)
                {
                    if (cases[x,y].Equals(c))
                    {
                        return new[]{x,y};
                    }
                }
            }

            return null;
        }
        public void IncrementerDecouvertes()
        {
            decouvertes++;
        }
        public void ModifierMarquees(bool marquee)
        {
            if (marquee) restantes --; else restantes++;
        }
        public bool TesterSiGagne()
        {
            return decouvertes + mines == largeur * hauteur;
        }
    }
}
