using Affichage;
using Banque;

public class AffichageVisionGlobale
{
    /// <summary>
    /// Affiche la totalité des compte d'un client avec quelques informations
    /// </summary>
    /// <param name="client"></param>
    public void VisionGlobale(Client client)
    {

        var index = 1;
        Console.WriteLine($"Voici tous vos comptes {client.prenom}");

        if (client.comptes.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de compte.");

        }
        else
        {
            client.comptes.ForEach(compte =>
            {
                Console.WriteLine($"{index++}. {compte.numeroCompte}");
                Console.WriteLine($"Type de compte : {compte.GetType().Name}");
                Console.WriteLine($"Solde : {compte.getSolde()}");
            });
            Console.WriteLine("Appuyer sur entrée pour continuer...");
            Console.ReadLine();
            AffichageCompte affichageCompte = new AffichageCompte();
            affichageCompte.Menu(client);
        }
    }
}