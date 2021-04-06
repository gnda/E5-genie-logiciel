#TP - Echecs

## Authors 
Kévin Nandacoumar - E5FIC
Ansary Marecar - E5FIC

Features

Interface graphique:

bouton "Nouvelle partie" fonctionnel
boutons "Pause"/"Continuer" fonctionnels
(partie stoppée sans possibilité de déplacer les pièces)

Jeu:

Gestion des déplacements de toutes les pièces

Ajouts :

Pour le roi:
Gestion du Roque

Exemple: Test grand Roque blanc

b1a3
b7b6
b2b3
c7c6
c1b2
d7d6
c2c3
e7e6
d1c2
f7f6
e1c1 <-- grand roque

Exemple: Test grand Roque noir

a2a3
b7b6
b2b3
b8a6
c2c3
c8b7
d2d3
c7c6
e2e3
d8c7
f2f3
e8c8 <-- grand roque

Exemple: Test petit Roque noir

a2a3
g8h6
b2b3
g7g6
c2c3
f8g7
d2d3
e8g8 <-- petit roque

Exemple: Test petit Roque blanc

g1h3
a7a6
g2g3
b7b6
f1g2
c7c6
e1g1 <-- petit roque

Pour les pions:
Gestion de la prise En passant

Exemple: Test en passant blanc

a2a4
b7b5
a4a5
c7c6
a5b6 <-- en passant

Exemple: Test en passant noir

a2a4
b7b5
a2a3
b5b4
c2c3
c4c3 <-- en passant

Gestion de la promotion implémentée (promotion en Dame uniquement)
