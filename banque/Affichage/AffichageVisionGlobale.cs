using Affichage;
using Banque;

public class AffichageVisionGlobale{
    public void VisionGlobale(Client client) {

        var index = 1;
        Console.WriteLine($"Voici tous vos comptes {client.prenom}");

        if (client.comptes.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de compte.");

        } else {client.comptes.ForEach(compte => {
                Console.WriteLine($"{index++}. {compte.numeroCompte}");
                Console.WriteLine($"Type de compte : {compte.GetType().Name}");
                Console.WriteLine($"Solde : {compte.solde}");

                Console.WriteLine("Voulez-vous connaître la politique de vos comptes ? \n1. Oui \n2. Non");
                if (!Int32.TryParse(Console.ReadLine(), out int reponse))
                {
                    Console.WriteLine("Entrée invalide !");
                    return;
                }

                switch (reponse)
                {
                    case 1:
                        
                        break;
                    case 2:
                        Console.WriteLine("Retour au menu principal !");
                        break;
                    default:
                        Console.WriteLine("Veuillez entrer 1, 2 ou 3.");
                        break;
                }
            });
        }
    }
}