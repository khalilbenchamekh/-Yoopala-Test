
1) Contexte : 

Ce projet a pour but de tester vos connaissances en C#, ASP.Net Core, JS, architecture et votre capacit� de r�solution de probl�mes. 
Ne pas �tre capable de le terminer � 100% n'est pas r�dhibitoire dans le processus de recrutement.
Ne tenez pas compte de potentielles incoh�rences des donn�es des m�dias.
En cas de questions sur ce test, vous pouvez contacter recrutement-dev@yoopala.com.

-----

2) Requis (necessaire pour le passage du test) :

Un ordinateur avec visual studio (minimum community) : https://visualstudio.microsoft.com/fr/vs/community/
SDK .Net Core 2.2 : disponible dans l'installateur de visual studio
Pas de connexion internet requis
Pas de sql server requis
Il est normal que le projet ne compile pas � sa r�cup�ration.

-----

3) A Faire (modifier la solution directement) :

a) Corriger les "erreurs" de compilation li�es aux methodes "View()" du MediaController
b) Corriger l'erreur au runtime en ajoutant l'injection de d�pendance du MediaService qui est utilis�, entre autre, dans le MediaController ; sinon trouver une solution alternative si vous n'y arrivez pas.
c) Corriger/Impl�menter les 8 commentaires "TODO" (qui sont dans des *.cs ou *.cshtml) de la solution et les erreurs de compilation/ex�cution

-----

4) Questions (r�pondre � la fin de ce fichier) :

a) Concernant la ligne : " services.AddSingleton(typeof(IRepository<Media>), typeof(MediaRepository)) " du Startup.cs
Imaginons que la solution permette d'ajouter et modifier des m�dias, 
Quel serait l'impact du choix entre AddScoped, AddSingleton, AddTransient au niveau des donn�es (m�dias) stock�es dans la liste du repository "_medias" ?

-----

5) Extra (r�aliser au minimum 2 points parmis les 5 suivants � votre guise, modifier la solution directement) :

a) Ajouter le logger de votre choix, et logger les actions du MediaService
b) R�aliser la page d'�dition d'un m�dia : Afficher les informations dans des champs d'�dition et permettre de sauvegarder, en proposant une mise en page
c) R�aliser une page de login : Pouvoir s'enregistrer puis se connecter en affichant son email dans la navbar
d) Transformer la page Media Index pour qu'elle r�cup�re les donn�es � afficher apr�s le chargement de la page : 
- Utilisation de JS natif qui appel un APIController
- Utilisation d'un framework JS appr�ci� (type vueJS)
e) La solution n'est pas architectur�e/organis�e correctement et ne contient qu'un seul projet. 
Factoriser autant que voulu et proposer une modification de l'architecture de la solution.
DDD et architecture hexagonal sont conseill�s (cr�ation d'autres projets)

Tr�s appr�ci� : Expliquer les points forts et points faibles, avantages et inconv�nients de chacune des r�alisations ci-dessus "Extra"
a) Ajouter le logger : permet d'identifier clairement l'emplacement et les sc�narios d'erreur pour ne pas perdre de temps en d�bogage, permet �galement d'analyser l'application et ses performances
e) permet l'�volutivit�, l'�volution et la correction des erreurs en raison de la bonne identification de l'emplacement (commun/webAPP/Infrastructure) �galement ou peut r�utiliser le m�me projet sur d'autres projets pour gagner plus de temps et ne pas r�inventer la roue
-----------
Reponse Question 4-a:

AddTransient�: cr�e des instances � chaque fois qu'elles sont demand�es, donc apr�s insertion ou modification, les modifications seront �cras�es si le service mm est � nouveau demand�
AddScoped : cr�e des instances par requ�te http, puis apr�s insertion ou modification les modifications seront �cras�es dans les nouvelles requ�tes http
AddSingleton : cr�e une seule instance par service, donc m�me si on redemande le m�me service ou on fait une nouvelle demande les modifications seront conserv�es