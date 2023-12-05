
using banque;

namespace Affichage {
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
                    numeroComptes[index-1] = compte.numeroCompte;
                    Console.WriteLine($"{index++}. {compte.numeroCompte}");
                });
                ChoixCompte(client, numeroComptes);   
                inputValid = false;
                break;
                default:
                Console.WriteLine("Pas de comptes en cours !");
                inputValid = false;
                break;
            }
        }

        }
        public static void ChoixCompte(Client client, int[] numeroComptes){

            Console.WriteLine("Quel compte souhaitez-vous voir ?");
            var inputValid = true;

           while (inputValid){
           
            Int32.TryParse(Console.ReadLine(), out int inputClient);

            if (inputClient > 0 && inputClient < client.comptes.Count+1){
                Console.WriteLine($"Vous avez sélectionner {numeroComptes[inputClient]}");
                Console.WriteLine("Que voulez-vous faire ? \n1. Retirer \n2. Virement \n3. Quitter");
            }
            else {
                Console.WriteLine("Veuillez entrer un compte valide");
            }
           }  
            
        }
}

}
