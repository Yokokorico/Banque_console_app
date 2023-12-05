
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
                int index = 1;
                int[] numeroComptes = new int[client.comptes.Count];
                client.comptes.ForEach(compte => {
                    Console.WriteLine($"{index++}. {compte.numeroCompte}");
                    numeroComptes[index-1] = compte.numeroCompte;
                });
                ChoixCompte(client);   
                inputValid = false;
                break;
                default:
                Console.WriteLine("Pas de comptes en cours !");
                inputValid = false;
                break;
            }
        }

        }
        public static void ChoixCompte(Client client){

            Console.WriteLine("Quel compte souhaitez-vous voir ?");
            Int32.TryParse(Console.ReadLine(), out int inputClient);

        if (inputClient > 0 && inputClient < client.comptes.Count+1){
        // Arrêt histoire du -1 pour avoir le bon index dans le tableau
        }
            
            
        }
}

    }
