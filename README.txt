
1) Contexte : 

Ce projet a pour but de tester vos connaissances en C#, ASP.Net Core, JS, architecture et votre capacité de résolution de problèmes. 
Ne pas être capable de le terminer à 100% n'est pas rédhibitoire dans le processus de recrutement.
Ne tenez pas compte de potentielles incohérences des données des médias.
En cas de questions sur ce test, vous pouvez contacter recrutement-dev@yoopala.com.

-----

2) Requis (necessaire pour le passage du test) :

Un ordinateur avec visual studio (minimum community) : https://visualstudio.microsoft.com/fr/vs/community/
SDK .Net Core 2.2 : disponible dans l'installateur de visual studio
Pas de connexion internet requis
Pas de sql server requis
Il est normal que le projet ne compile pas à sa récupération.

-----

3) A Faire (modifier la solution directement) :

a) Corriger les "erreurs" de compilation liées aux methodes "View()" du MediaController
b) Corriger l'erreur au runtime en ajoutant l'injection de dépendance du MediaService qui est utilisé, entre autre, dans le MediaController ; sinon trouver une solution alternative si vous n'y arrivez pas.
c) Corriger/Implémenter les 8 commentaires "TODO" (qui sont dans des *.cs ou *.cshtml) de la solution et les erreurs de compilation/exécution

-----

4) Questions (répondre à la fin de ce fichier) :

a) Concernant la ligne : " services.AddSingleton(typeof(IRepository<Media>), typeof(MediaRepository)) " du Startup.cs
Imaginons que la solution permette d'ajouter et modifier des médias, 
Quel serait l'impact du choix entre AddScoped, AddSingleton, AddTransient au niveau des données (médias) stockées dans la liste du repository "_medias" ?

-----

5) Extra (réaliser au minimum 2 points parmis les 5 suivants à votre guise, modifier la solution directement) :

a) Ajouter le logger de votre choix, et logger les actions du MediaService
b) Réaliser la page d'édition d'un média : Afficher les informations dans des champs d'édition et permettre de sauvegarder, en proposant une mise en page
c) Réaliser une page de login : Pouvoir s'enregistrer puis se connecter en affichant son email dans la navbar
d) Transformer la page Media Index pour qu'elle récupère les données à afficher après le chargement de la page : 
- Utilisation de JS natif qui appel un APIController
- Utilisation d'un framework JS apprécié (type vueJS)
e) La solution n'est pas architecturée/organisée correctement et ne contient qu'un seul projet. 
Factoriser autant que voulu et proposer une modification de l'architecture de la solution.
DDD et architecture hexagonal sont conseillés (création d'autres projets)

Très apprécié : Expliquer les points forts et points faibles, avantages et inconvénients de chacune des réalisations ci-dessus "Extra"
a) Ajouter le logger : permet d'identifier clairement l'emplacement et les scénarios d'erreur pour ne pas perdre de temps en débogage, permet également d'analyser l'application et ses performances
e) permet l'évolutivité, l'évolution et la correction des erreurs en raison de la bonne identification de l'emplacement (commun/webAPP/Infrastructure) également ou peut réutiliser le même projet sur d'autres projets pour gagner plus de temps et ne pas réinventer la roue
-----------
Reponse Question 4-a:

AddTransient : crée des instances à chaque fois qu'elles sont demandées, donc après insertion ou modification, les modifications seront écrasées si le service mm est à nouveau demandé
AddScoped : crée des instances par requête http, puis après insertion ou modification les modifications seront écrasées dans les nouvelles requêtes http
AddSingleton : crée une seule instance par service, donc même si on redemande le même service ou on fait une nouvelle demande les modifications seront conservées