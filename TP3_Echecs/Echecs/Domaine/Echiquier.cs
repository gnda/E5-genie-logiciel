using Echecs.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Echecs.Domaine
{
    class Echiquier
    {
        public int[,] cases;

        public Echiquier(Partie partie)
        {
            Partie = partie;
        }

        public Partie Partie { get; }
    }
}
