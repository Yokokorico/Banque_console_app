using Banque;
using Affichage;
public class Program{

    public static void Main(string[] args){

        bool inputValid = true;
        while (inputValid)
        {

        var client = new Client(); 
        var compte =  new CompteCourant(client,false);
        client.comptes.Add(compte);
        
        Console.WriteLine($"Bienvenue {client.nom} {client.prenom} !");
        Console.WriteLine("Voulez-vous accéder à votre espace personnel ?\n1. Oui \n2. Non");
        var inputClient = Console.ReadLine();

        switch (inputClient)
            {
                case "1":
                    // Console.Clear();
                    AffichageCompte affichageCompte = new AffichageCompte();    
                    affichageCompte.Menu(client);
                    inputValid = false;
                    break;
                case "2": 
                    Console.WriteLine("Au revoir !");
                    inputValid = false;
                    break;
                default:
                    Console.WriteLine("Veuillez entrer 1 ou 2.");
                    break;

            }
        }
    }
}