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
        public Case[,] cases;
        public Partie Partie { get; }

        public Echiquier(Partie partie)
        {
            Partie = partie;
        }
    }
}
