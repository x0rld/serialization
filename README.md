Un fichier JSON contient trois objets.  
Le premier objet  contiendra des users  
( id, name, password )  
le premier sera 1, "Admin","4dmin"  
le deuxieme sera 2, "User", "useR"  
le deuxième Objet contiendra une liste de 4 questions  
le troisieme objet pourra contenir une liste de 4 réponses  
-------------------------------------------------------------------
lorsque je compile mon projet j'arrive sur un Menu qui me demande de me connecter ( identifiant, mot de passe)  
selon mes données entrés je serai soit redirigé vers un menu qui me permettra de gerer mes questions  
soit un menu qui me permettra de participer au Quiz  
soit un message d'erreur m'indiquant que je me suis trompé  
l'ecran doit se vider entre chaque questions  
les reponses doivent etre enregistré dans le fichier JSON  
une comparaison doit être faite entre question et réponse  
un quatrième objet contiendra des infos pour l'administrateur  
a savoir le nombre de participation au questionnaire.. et le taux de réussite  
nombre de questionnaire rendu avec au moins 3 bonnes réponses  
exemple  
les utilisateurs ont participés à X questionnaire. Y sur X questionnaire on obtenus une note supérieure à la moyenne
------------------------------------------------------------------------
trouvez un moyen de hasher le mot de passe  
permettre a l'administrateur d'obtenir une liste des questionnaire numéroté
du style :
- questionnaire 1
- questionnaire 2
- questionnaire 3

voulez vous ouvrir un questionnaire (o/n) ?  
réponse de l'admin o  
quel questionnaire voulez vous voir ?  
réponse de l'admin 3  
voici les réponses du questionnaire 3  

question 1 : vjfkdjhglskjdfhgls  
réponse : fjfdlskjfslkdjf  
réponse user : kdjflskjdfslkjdf

rebasculer sur le menu (r)  
quitter (q)
------------------------------------------------------------------------------
je sépare chaque chaque classe dans son propre fichier
je peux si je veux utiliser les structures pour mes questions
je ne peux pas avoir des methodes de plus de 30 lignes
