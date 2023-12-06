
using Banque;
            
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

            Console.WriteLine($"Vous êtes sur votre espace personnel {client.prenom}.");
            Console.WriteLine("Que souhaitez-vous faire ? \n1. Choisir mon compte \n2. Voir mes comptes \n3. Quitter");
            var inputClient = Console.ReadLine();

            switch (inputClient) {
                case "1": 
                ChoixCompte(client);   
                inputValid = false;
                break;
                case "2":
                VisionGlobale(client);
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
            bool inputValid = true;
            while (inputValid){
           
                Console.WriteLine("Quel compte souhaitez-vous voir ?");
                    int index = 1;
                    int[] numeroComptes = new int[client.comptes.Count];
                    client.comptes.ForEach(compte => {
                        numeroComptes[index-1] = compte.numeroCompte;
                        Console.WriteLine($"{index++}. {compte.numeroCompte}");
                });
               
                Int32.TryParse(Console.ReadLine(), out int inputClient);

                    if (inputClient < 0 || inputClient >= client.comptes.Count + 1)
                    {
                        Console.WriteLine("Veuillez entrer un compte valide");
                    }
                    else
                    {
                        Console.WriteLine($"Vous avez sélectionner {numeroComptes[inputClient - 1]}");
                        Console.WriteLine("Que voulez-vous faire ? \n1. Retirer \n2. Virement \n3. Dépôt \n4. Changer de compte \n5. Quitter");

                        Int32.TryParse(Console.ReadLine(), out int inputCompte);

                        if (inputCompte == (int)compteChoix.Retirer)
                        {
                            AffichageOperation.AffichageOperationRetrait(client,numeroComptes[inputClient - 1]);
                        }
                        else if (inputCompte == (int)compteChoix.Depot)
                        {
                            AffichageOperation.AffichageOperationDepot(client,numeroComptes[inputClient - 1]);
                        }
                        else if (inputCompte == (int)compteChoix.Virement)
                        {
                            AffichageOperation.AffichageOperationVirement(client,numeroComptes[inputClient - 1]);
                        }
                        else if (inputCompte == (int)compteChoix.ChangerCompte)
                        {
                            ChoixCompte(client);
                        }
                        else if (inputCompte == (int)compteChoix.Quitter)
                        {
                            inputValid = false;
                        }

                    }
                }  
            
            }

    public static void VisionGlobale(Client client) {

        var index = 1;
        Console.WriteLine($"Voici tous vos comptes {client.prenom}");

        if (client.comptes.Count == 0)
        {

            Console.WriteLine("Vous n'avez pas de compte.");

        } else {client.comptes.ForEach(compte => {
                Console.WriteLine($"{index++}. {compte.numeroCompte}");
                // AffichageRetrait.AffichageRetrait(compte, client);
                // AffichageVirement.AffichageVirement(compte, client);
                // AffichageDepot.AffichageDepot(compte, client);
                // AffichageSolde.AffichageDuSolde(compte.numeroCompte, client);
            });
        }
    }

       
    }
}