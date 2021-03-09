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

            // 64 cases
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    cases[x, y] = new Case(this, x, y);
                }
            }
        }
    }
}
