using System;
using System.Collections.Generic;

namespace Demineur.Jeu
{
    public class Case
    {
        bool minee, marquee, decouverte = false;
        List<Case> voisines = new List<Case>();

        public bool Minee
        {
            get => minee;
            set => minee = value;
        }
        public bool Marquee
        {
            get => marquee;
            set => marquee = value;
        }
        public bool Decouverte
        {
            get => decouverte;
            set => decouverte = value;
        }
        public List<Case> Voisines
        {
            get => voisines;
            set => voisines = value;
        }

        public void Connecter(Case c)
        {
            voisines.Add(c);
        }

        public void Marquer()
        {
            if (!decouverte)
            {
                marquee = !marquee;
            }
        }

        public bool Decouvrir()
        {
            if (!decouverte && !minee)
            {
                return false;
            }

            decouverte = true;

            return minee;
        }

        public void Afficher()
        {
            Console.WriteLine("minee: " + minee);
            Console.WriteLine("marquee: " + marquee);
            Console.WriteLine("decouverte: " + decouverte);
        }
    }
}
