
# Projet d'application bancaire en POO
Projet d'application bancaire en POO permettant à un utilisateur de faire les actions basiques comme le depot, le retrait et le virement


## Lancement du projet

Pour lancer le projet il suffit de récuperer l'archive du projet de le unzip d'aller dans le dossier CodeMasterQuiz et éffectuer les commandes suivantes

```bash
dotnet build
```
Cela va génére un executable dans le dossier
    
    bin\Debug\net6.0

Il suffit de lancer le .exe et c'est parti ! 

WARNING ne pas lancer le projet avec la commande

```bash
dotnet run
```


    
## Documentation

### Trello
[Projet Trello](https://trello.com/invite/b/G2wVRjFr/ATTI8fc6c21b29c57c5bd6316ed29ea9566713D82B71/projet-banque)

### Diagramme de classe & Diagramme de cas d'utilisation

[Diagramme](https://excalidraw.com/#room=f5d821acd669acb77587,lW9IQcWP_hu02XcS_L4AAA)


## Features

### Accèder à son espace personnel

En arrivant sur l'application le programme vous demande si vous voulez rentrez ou non 
dans votre espace personnel. Ceci est la méthode Menu() dans la classe Program

### Choisir le compte à manipuler

Pour choisir le compte il suffit de selectionné le compte avec le numéro de compte correspondant qui est listé

### Après avoir selectionné son compte

Après avoir selectionné son compte il possible 
* D'effectuer un retrait
* D'effectuer un depot 
* D'effectuer un virement 
* Accéder à la liste des transaction détaillé 

### Effectuer un retrait ou un depot

Si le retrait à été selectionné il suffit de mentionné le montant et l'intitulé. Si il y a une erreur l'application affichera le type d'erreur et elle annulera l'opération en cours. Elles sont respectivement les méthodes 
    
    affichageOperationRetrait() et affichageOperationDepot()

### Effectuer un virement sur un autre de ses comptes

Si le retrait à été selectionné il suffit de mentionné le montant et l'intitulé ainsi que le numéro du compte sur lequel viré l'argent. Si il y a une erreur l'application affichera le type d'erreur et elle annulera l'opération en cours. Cela corresponde à la méthode 
    
    affichageOperationVirement()

### Voir la liste de ces transaction avec leurs details

Il est possible d'afficher les transaction d'un compte avec leurs détailles la méthode utiliser est 

    AffichageLesTransactionDuCompte()

### Avoir un vision globale de tout ces comptes

L'utilisateur peut avoir à une vision globale de tous ces comptes il sera alors affiché le type de compte, le solde ainsi que le numéro de compte la méthode liée est 

    VisionGlobale();

### Avoir un fichier avec les logs des actions effectuer sur un compte

L'application à un système de log qui écrit dans un fichier txt toutes les actions(virement,depot,retrait) pour les différents comptes de l'utilisateur. Le fichier se trouve dans 

    bin/debug/net6.0/

## Running Tests

Pour lancer les tests il suffit de se rendre dans le répertoire du projet puis executer la commande suivant 

```
dotnet test
```

