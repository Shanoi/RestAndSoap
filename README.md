# RestAndSoap Lab rendu
(sujet : http://www.tigli.fr/doku.php?id=cours:ws-rest_and_ws-soap:lab)


Ce service est une gateway entre le WS de JCDecaux qui expose la disponibilité des Velibs sur différentes villes. Il est accompagné de clients pour pouvoir accéder à ce service.

## Travail effectué

  - La Gateway pour exposer le service (JCDLibrary)
  - Un client console pour l'administration (ClientAdmin)
  - Un client console pour accéder au service (ClientConsole)
  - Un client console pour accéder au service en mode asynchrone (ClientConsoleAsync)
  - Un client GUI pour accéder au service (ClientGUI)
  - Un client GUI pour accéder au service en mode asynchrone (ClientGUIAsync)

## Extensions

### Cache

L'extension de cache est mise en place du côté de la gateway.
Le client administrateur permet de changer la durée des caches. En mois pour le noms des villes et en minutes pour les stations.
Elle gère séparément les différentes villes.
Elle permet 3 rangs de durée
  - Pour les clients "Bronze", si il fait une demande et que la durée déterminée par l'administrateur (m) n'est pas écoulée, le cache ne se mettra pas à jour.
  - Pour les clients "Silver", si il fait une demande et que la durée déterminée par l'administrateur divisée par 2 (m/2) n'est pas écoulée, le cache ne se mettra pas à jour.
  - Pour les client "Gold", le cache a une date de maximum une minute.
Les clients "Bronze" ont donc accès à de "vieilles données" si elles sont présentes dans le cache. Si elles ne sont pas présentes, ce seront des données neuves. Si un client d'une fidélité supérieur vient de faire la même demande juste avant, il a de la chance et aura accès à des données plus ou moins récentes.

### GUI

Dans l'extension GUI, le client à la possibilité de voir de quand date les données demandées (Ce n'est pas le cas en console)
Le client GUI présente la liste des villes et on peut spécifier une station pour faire la recherche. On accède aux détails de la station en la sélectionnant.
On peut également choisir le niveau de fidélité.

### Async

Les appels entre la gateway et le service JCDecaux se font de manière asynchrones.
De même que les appels entre les client asynchrones et la gateway.

### Déploiement

J'ai essayé de déployer le server grâce à mono et Docker.
Cependant après de longues heures de recherches et des exceptions aléatoires j'ai abandonné.
Le code du server est présent ainsi que le Dockerfile pour le déploiement et un script pour compiler le serveur si on veux le lancer en local (nécessite d'installer mono, et lancer le serveur en utilisant la commande `mono .\server.exe`).

#### Pour utiliser le Dockerfile:

  1. Lancer la commande `docker build -t velibServer . `
  2. Lancer la commande `docker run -p 8733:8733 velibServer`

Ces commandes permettent de build le server en utilisant le Dockerfile puis de lancer le server en exposant le port 8733.
