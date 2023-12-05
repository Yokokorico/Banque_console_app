
using banque;
            
public enum compteChoix
{
    Retirer = 1,
    Virement = 2,
    Depot = 3,
    ChangerCompte = 4, 
    Quitter = 5
}


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
                int index = 1;
                int[] numeroComptes = new int[client.comptes.Count];
                client.comptes.ForEach(compte => {
                    numeroComptes[index-1] = compte.numeroCompte;
                    Console.WriteLine($"{index++}. {compte.numeroCompte}");
                });

            Console.WriteLine("Quel compte souhaitez-vous voir ?");
            bool inputValid = true;

           while (inputValid){
           
            Int32.TryParse(Console.ReadLine(), out int inputClient);

            if (inputClient > 0 && inputClient < client.comptes.Count+1){
                Console.WriteLine($"Vous avez sélectionner {numeroComptes[inputClient-1]}");
                Console.WriteLine("Que voulez-vous faire ? \n1. Retirer \n2. Virement \n3. Dépôt \n4. Changer de compte \n5. Quitter");
                
                Int32.TryParse(Console.ReadLine(), out int inputCompte);
                
                if (inputCompte == (int)compteChoix.Retirer){
                    AffichageSolde.AffichageDuSolde(numeroComptes[inputClient-1], client);
                    // AffichageRetrait.AffichageRetrait(numeroComptes[inputClient-1], client);
                } else if (inputCompte == (int)compteChoix.Depot){
                    AffichageSolde.AffichageDuSolde(numeroComptes[inputClient-1], client);
                    // AffichageDepot.AffichageDepot(numeroComptes[inputClient-1], client);
                } else if (inputCompte == (int)compteChoix.Virement){
                    AffichageSolde.AffichageDuSolde(numeroComptes[inputClient-1], client);
                    // AffichageVirement.AffichageVirement(numeroComptes[inputClient-1], client);
                } else if (inputCompte == (int)compteChoix.ChangerCompte){
                    ChoixCompte(client);
                } else if (inputCompte == (int)compteChoix.Quitter){
                    inputValid = false;
                }
                
            } else {
                Console.WriteLine("Veuillez entrer un compte valide");
            }
           }  
            
        }

       
    }
}