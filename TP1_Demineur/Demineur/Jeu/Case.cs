using System;
using System.Collections.Generic;

namespace Demineur.Jeu
{
    public class Case
    {
        Plateau plateau;
        bool minee, marquee, decouverte = false;
        int x, y;
        int num = 0;
        List<Case> voisines = new List<Case>();

        public Case(Plateau plateau, int x, int y, bool minee)
        {
            this.plateau = plateau;
            this.x = x;
            this.y = y;
            this.minee = minee;
        }

        public void Connecter(Case c)
        {
            voisines.Add(c);
        }

        public void Marquer(int x, int y)
        {
            if (!decouverte)
            {
                marquee = !marquee; // changerEtat
                plateau.ModifierMarquees(marquee);
                plateau.Partie.vue.MarquerCase(x, y, marquee);
            }
        }

        public bool Decouvrir()
        {
            if (decouverte || marquee)
            {
                return false;
            }

            decouverte = true; // changerEtat

            plateau.IncrementerDecouvertes();

            if (minee)
            {
                plateau.Partie.vue.AfficherCaseMinee(x, y, minee);
                plateau.Partie.vue.PartiePerdue();
            } else
            {
                num = CompterVoisinMinee();
                plateau.Partie.vue.AfficherCaseNumerotee(x, y, num);
                if (num == 0)
                {
                    foreach (Case v in voisines)
                    {
                        v.Decouvrir();
                    }
                }
            }

            return minee;
        }

        int CompterVoisinMinee()
        {
            int n = this.minee ? 1 : 0;

            foreach (Case v in voisines)
            {
                n += v.minee ? 1 : 0;
            }

            return n;
        }

        public void Afficher()
        {
            Console.WriteLine("minee: " + minee);
            Console.WriteLine("marquee: " + marquee);
            Console.WriteLine("decouverte: " + decouverte);
        }
    }
}
