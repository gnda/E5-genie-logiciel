using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Echecs.Domaine
{
    interface IJeu
    {
        //public IEvenements Ievent;
        void CommencerPartie();
        void DeplacerPiece();

    }
}
