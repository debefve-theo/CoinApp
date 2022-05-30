# Application de gestion d'investissement dans les Crypto Monnaie. #

Projet final dans le cadre du cours ***Développement orienté objets et multitâche : Programmation orientée objet Windows- C#***
HEPL Seraing Informatique de gestion Bloc2 Juin 2022

<!-- -->
![Page Home](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/Cover.jpg)
<!-- -->

## Présentation générale
Avec cette application vous allez avoir une vue ensemble sur tout vos investissements dans les Crypto Monnaies. Ils vous suffira d'encoder toutes vos transaction et l'application ferra le reste. 
<!-- -->
:page_facing_up: [Enoncé](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/enonce.pdf)
<!-- -->
:page_facing_up: [Mockup](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/mockups.pdf)
<!-- -->
:page_facing_up: [Diagramme des classes](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/DiagrammeDesClasses.png)
<!-- -->
### Home
Sur la première page vous pouvez retrouver :
+ Votre solde actuel ainssi que l'augmentaion/diminution en 24h
+ La valeur total d'achat ainssi que les Gains/Pertes actuel
+ Dans la zone du bas vous pouvez trouver le détails précis de chaque crypto que vous possédez.
<!-- -->
![Page Home](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_home.png)
<!-- -->
### Transaction
Sur la page de vous pouvez retrouver :
+ Une liste de toutes les trasaction que vous avez éfectuée avec tout les détails.
<!-- -->
![Page Transaction](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_transaction.png)
<!-- -->
Pour ajouter une transaction a la liste il faut les données suivante :
+ Savoir si c'est un achat ou une vente
+ La Crypto Monnaie
+ La date et l'heure de la transaction
+ La quantité achetée
+ Le prix du token a ce moment la
+ Les frais
+ La plateforme ou s'effectue la transaction
<!-- -->
![Page Transaction Add](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_new_transaction.png)
<!-- -->
### Watchlist
Sur la page de vous pouvez retrouver :
+ Une liste de toutes les Crypto Monnaie.
<!-- -->
![Page Watchlist](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_watchlist.png)
<!-- -->
### Connexion
Pour pouvoir accéder a l'application vous devrez entrer votre mot de passe.
<!-- -->
![Page Watchlist](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_login.png)
<!-- -->
Vous pouvez créer plusieures portfolio avec des mot de passe différents.
<!-- -->
![Page Watchlist Add](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_new_user.png)
<!-- -->

### Paramètres
Paramètres des fichiers de sauvegardes
<!-- -->
![Page Watchlist](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_settings_file.png)
<!-- -->
Modification du mot de passe
<!-- -->
![Page Watchlist Add](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/screenshot/App_settings_pass.png)
<!-- -->

## Architecture des classe
<!-- -->
![Page Watchlist Add](https://github.com/hepl-csb-student22/labo-final-TheoDeb/blob/main/Documentation/DiagrammeDesClasses.png)
<!-- -->
### Classe Crypto
+ Identifiant
+ Nom
+ Symbol
+ Une instance de la classe CryptoDetails
+ Une instance de la classe CryptoOwn

### Classe CryptoDetails
+ Prix actuel
+ Volume de transfert en 24h
+ % de variation en 1h
+ % de variation en une jounée
+ % de variation en une semmaine
+ Capitalisation totale

### Classe CryptoOwn
+ Valeur booléenne qui indique si l'utilisateur possède cette Crypto
+ Quantité de token possédé
+ Valeur totale actuel en €
+ Total des valeurs d'achat
+ Gains ou perte
+ % d'allocation dans le portfolio

### Classe User
+ Identifiant
+ Nom d'utilisateur
+ Mot de passe
+ Solde total actuel
+ Prix total d'achat
+ Gains ou perte total

### Classe Transaction
+ Identifiant
+ Boolléen a false en cas d'achat et a true en cas de vente
+ Nombre de token
+ Prix par token
+ Frais de la transaction
+ Date et heure de la transaction
+ Nom de la plateforme
+ Une instance de la classe Crypto
+ Prix (Prix par token * quantité)
+ Total (Prix + Frais)