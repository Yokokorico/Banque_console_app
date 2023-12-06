using Banque;

namespace Affichage;

public class AffichageOperation{
    /// <summary>
    /// Méthode d'affichage question réponse pour le depot
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public static void AffichageOperationDepot(Client client,int numeroCompte){
        try{
            var inputUtilisateurValide = true;
            while(inputUtilisateurValide){
                Console.WriteLine("Vous avez selectionné depôt\nEntrer le montant de votre depôt\n*Attention le montant doit-être supérieur à 0.1€\nMontant ->");
                if(!float.TryParse(Console.ReadLine(),out float montantEntrerParUtilisateur)){
                    Console.WriteLine("Merci de rentrer un moment valide");
                }else{
                    Console.WriteLine("Entrez un intitulé (Optionnel)");
                    var inituleEntrerParUtilisateur = Console.ReadLine();
                    client.comptes.Single(s => s.numeroCompte == numeroCompte).EffectuerRetrait(montantEntrerParUtilisateur,inituleEntrerParUtilisateur);
                    inputUtilisateurValide=false;
                }
            }
        }catch (InvalidOperationException ex){
            AffichageCompte.Menu(client);
        }
            
    }
    /// <summary>
    /// Méthode d'affichage question réponse pour le virement
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public static void AffichageOperationVirement(Client client,int numeroCompte){
        try{
            var inputUtilisateurValide = true;
            while(inputUtilisateurValide){
                Console.WriteLine("Vous avez selectionné Virement\nEntrer le montant de votre Virement\n*Attention le montant doit-être supérieur à 0.1€\nMontant ->");
                if(!float.TryParse(Console.ReadLine(),out float montantEntrerParUtilisateur)){
                    Console.WriteLine("Merci de rentrer un moment valide");
                }else{

                    var inputNumeroDeCompteValide = true;
                    while (inputNumeroDeCompteValide){
                        if(!Int32.TryParse(Console.ReadLine(),out int numeroComptePourEnvoiVirement)){
                            Console.WriteLine("Merci de rentrer un numéro de compte valide");
                        } else {
                            inputNumeroDeCompteValide=false;
                        }
                    }
                    Console.WriteLine("Entrez un intitulé (Optionnel)");
                    var inituleEntrerParUtilisateur = Console.ReadLine();
                    client.comptes.Single(s => s.numeroCompte == numeroCompte).EffectuerDepot(montantEntrerParUtilisateur,inituleEntrerParUtilisateur);
                    inputUtilisateurValide=false;
                }
            }
        }catch (InvalidOperationException ex){
            AffichageCompte.Menu(client);
        }
            
    }
    /// <summary>
    /// Méthode d'affichage question réponse pour le Retrait
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public static void AffichageOperationRetrait(Client client,int numeroCompte){
        try{
            var inputUtilisateurValide = true;
            while(inputUtilisateurValide){
                Console.WriteLine("Vous avez selectionné retrait\nEntrer le montant de votre retrait\nMontant ->");
                if(!float.TryParse(Console.ReadLine(),out float montantEntrerParUtilisateur)){
                    Console.WriteLine("Merci de rentrer un moment valide");
                }else{
                    Console.WriteLine("Entrez un intitulé (Optionnel)");
                    var inituleEntrerParUtilisateur = Console.ReadLine();
                    client.comptes.Single(s => s.numeroCompte == numeroCompte).EffectuerDepot(montantEntrerParUtilisateur,inituleEntrerParUtilisateur);
                    inputUtilisateurValide=false;
                }
            }
        }catch (InvalidOperationException ex){
            AffichageCompte.Menu(client);
        }
            
    }
}