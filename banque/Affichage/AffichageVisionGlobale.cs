using Affichage;
using Banque;

public class AffichageVisionGlobale{
    public void VisionGlobale(Client client) {

        var index = 1;
        Console.WriteLine($"Voici tous vos comptes {client.prenom}\n");

        if (client.comptes.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de compte.");
        } 
        else 
        {
            client.comptes.ForEach(compte => {
                Console.WriteLine($"{index++}. {compte.numeroCompte} solde -> {compte.solde}");
            });
            Thread.Sleep(2000);
            Console.Clear();
            AffichageCompte affichageCompte = new AffichageCompte();
            affichageCompte.Menu(client);
        }
    }
}