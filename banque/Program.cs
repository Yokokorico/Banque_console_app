using banque;
using affichage;
public class Program{

    public static void Main(string[] args){

        bool inputValid = true;
        while (inputValid)
        {

        var client = new Client(); 
        var compte =  new CompteBancaire();
        client.comptes.Add(compte);
        
        Console.WriteLine($"Bienvenue {client.nom} {client.prenom} !");
        Console.WriteLine("Voulez-vous accéder à votre espace personnel ?\n1. Oui \n2. Non");
        var inputClient = Console.ReadLine();

        switch (inputClient)
            {
                case "1":
                    AffichageCompte.Menu();
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