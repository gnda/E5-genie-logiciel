using Echecs.IHM;

namespace Echecs.Domaine
{
    public class Echiquier
    {
        public Case[,] cases;

        public Partie partie { get; }

        public Echiquier(Partie partie)
        {
            this.partie = partie;
            cases = new Case[8, 8];

            int i = 0;

            // 64 cases (alternance case blanche et noire)
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (i++ % 2 == 0)
                    {
                        cases[x, y] = new Case(this, x, y, CouleurCamp.Blanche);
                    }
                    else
                    {
                        cases[x, y] = new Case(this, x, y, CouleurCamp.Noire);
                    }

                    // Actualisation des cases pour vider l'échiquier en début de partie
                    partie.vue.ActualiserCase(x, y, null);
                }
            }
        }
    }
}
