using System.Collections.Generic;
using Echecs.IHM;
using System;

namespace Echecs.Domaine
{
    public class Partie : IJeu
    {
        public IEvenements vue
        {
            get { return _vue; }
            set {_vue = value; }
        }

        StatusPartie status
        {
            get { return _status; }
            set
            {
                _status = value;
                vue.ActualiserPartie(_status);
            }
        }


        /* attributs */

        StatusPartie _status = StatusPartie.Reset;


        /* associations */

        IEvenements _vue;
        Joueur blancs;
        Joueur noirs;
        
        Echiquier echiquier;  // TODO : décommentez lorsque vous auriez implementé la classe Echiquier
        public List<Coup> coups;

        /* methodes */

        public void CommencerPartie()
        {
            // initialisation des coups
            coups = new List<Coup>();

            // creation des joueurs
            blancs = new Joueur(this, CouleurCamp.Blanche);
            noirs = new Joueur(this, CouleurCamp.Noire);

            // creation de l'echiquier
            echiquier = new Echiquier(this);

            // placement des pieces
            blancs.PlacerPieces(echiquier);  // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case
            noirs.PlacerPieces(echiquier);  // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case

            // initialisation de l'état
            status = StatusPartie.TraitBlancs;         
        }

        public void DeplacerPiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee)
        {
            // case de départ
            Case depart = echiquier.cases[x_depart, y_depart];

            // case d'arrivée
            Case destination = echiquier.cases[x_arrivee, y_arrivee];

            // enregistrement du coup
            coups.Add(new Coup(depart, destination));

            // deplacer
            bool ok = coups[coups.Count - 1].Effectuer();

            // changer d'état
            if (ok)
                ChangerEtat();
        }

        void ChangerEtat(bool echec = false, bool mat = false)
        {
            if (status == StatusPartie.TraitBlancs)
            {
                status = StatusPartie.TraitNoirs;
            }
            else
            {
                status = StatusPartie.TraitBlancs;
            }

        }
    }
}
