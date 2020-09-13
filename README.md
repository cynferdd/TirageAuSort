# Tirage au sort
Outil permettant de prendre 2 listes (candidats et lots par exemple), de les mélanger, et de faire un tirage au sort aléatoire, restitué en sortie.

## Fonctionnement
Un exe `TirageAuSort.exe` est généré avec quelques dlls.
Il s'agit d'un executable à lancer en ligne de commande.
Il attend 2 paramètres correspondant aux fichiers contenant les données utilisées pour le tirage au sort

### Fichiers de base
Les fichiers attendus sont des fichiers texte contenant une donnée par ligne.
Par convention, on appelle le premier fichier "candidats", et le second "lots".
Cependant il n'y a pas d'obligation de nommage spécifique pour ces fichiers.

### Processus
Une fois l'executable lancé avec 2 chemin correspondant à des fichiers existants et non vides, on prend une donnée aléatoire dans chaque fichier et on les associe (un "candidat" et un "lot").
Chaque donnée est alors supprimée de la liste parcourue pour s'assurer qu'il n'y ait pas de possibilité de double attribution.

En fin de traitement, 3 fichiers sont créés dans un dossier "Resultats" :
* un fichier avec le résultat du tirage au sort
  * fichier au format json avec en clé la donnée issue du fichier 1, et en valeur la donnée issue du fichier 2
  * (par exemple : `{"candidat23":"lot42"}` )
  * Format du nom : `TirageAuSort_{DateEtHeureDuTirage}.json`
* un fichier avec les candidats restants si jamais il y avait plus de candidats que de lots
  * Format du nom : `CandidatsRestants_{DateEtHeureDuTirage}.txt`
* un fichier avec les lots restants si jamais il y avait plus de lots que de candidats 
  * Format du nom : `LotsRestants_{DateEtHeureDuTirage}.txt`

## Tests internes
Des tests unitaires s'assurent du bon fonctionnement de l'ensemble, notamment du fait que le tirage au sort est bien aléatoire.

## Fichiers de tirage au sort
Les fichiers du tirage au sort du 13/09/2020 sont déposés dans le répertoire `.\Tirage_2020-09-13`

Deux répertoires sont présents dedans : 
* fichiers de base (avec les données utilisées pour le tirage au sort)
* resultats (avec le résultat du tirage au sort)