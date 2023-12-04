
using banque;

namespace affichage {
    public class AffichageCompte {

        public static void Menu(Client client) {
            
            bool inputValid = true;

            while (inputValid) {

            Console.WriteLine("Vous êtes sur votre espace personnel.");
            Console.WriteLine("Que souhaitez-vous faire ? \n1. Voir mes comptes \n2. Quitter");
            var inputClient = Console.ReadLine();

            switch (inputClient) {
                case "1": 
                client.comptes.ForEach(compte => Console.WriteLine(compte.numeroCompte));
                inputValid = false;
                break;
                default:
                Console.WriteLine("Pas de comptes en cours !");
                inputValid = false;
                break;
            }
        }

        }

    }
}