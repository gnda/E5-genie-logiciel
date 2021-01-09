using Demineur.Jeu;
using System.Collections.Generic;

namespace IHM
{
    public interface IActions
    {
        IReactions vue { get; set; }
        List<Case> CasesParcour { get; set; }

        void CommencerPartie(int largeur, int hauteur, int mines);

        void TerminerPartie();

        void MarquerCase(int x, int y);

        void DecouvrirCase(int x, int y);
    }
}
