
using Banque;
            
public enum compteChoix
{
    Retirer = 1,
    Virement = 2,
    Depot = 3,
    ChangerCompte = 4, 
    ObtenirPolitique = 5,
    Quitter = 6
}


namespace Affichage {
    public class AffichageCompte {

        public void Menu(Client client) {
            
            bool inputValid = true;

            while (inputValid) {

            Console.WriteLine($"Vous êtes sur votre espace personnel {client.prenom}.");
            Console.WriteLine("Que souhaitez-vous faire ? \n1. Choisir mon compte \n2. Voir mes comptes \n3. Quitter");
            var inputClient = Console.ReadLine();

            switch (inputClient) {
                case "1": 
                // Console.Clear();
                ChoixCompte(client);   
                inputValid = false;
                break;
                case "2":
                // Console.Clear();
                AffichageVisionGlobale affichageVisionGlobale = new AffichageVisionGlobale();
                affichageVisionGlobale.VisionGlobale(client);
                inputValid = false;
                break;
                default:
                Console.WriteLine("Pas de comptes en cours !");
                inputValid = false;
                break;
            }
        }

        }
        public void ChoixCompte(Client client){
            bool inputValid = true;
            while (inputValid){
           
                Console.WriteLine("Quel compte souhaitez-vous voir ?");
                    int index = 1;
                    int[] numeroComptes = new int[client.comptes.Count];
                    client.comptes.ForEach(compte => {
                        numeroComptes[index-1] = compte.numeroCompte;
                        Console.WriteLine($"{index++}. {compte.numeroCompte}");
                });
               
                if(Int32.TryParse(Console.ReadLine(), out int inputClient)){
                    if (inputClient < 0 || inputClient >= client.comptes.Count + 1)
                    {
                        Console.WriteLine("Veuillez entrer un compte valide");
                    }
                    else
                    {
                        // Console.Clear();
                        Console.WriteLine($"Vous avez sélectionner {numeroComptes[inputClient - 1]}");
                        Console.WriteLine("Que voulez-vous faire ? \n1. Retirer \n2. Virement \n3. Dépôt \n4. Changer de compte \n5. Quitter");

                        Int32.TryParse(Console.ReadLine(), out int inputCompte);

                        if (inputCompte == (int)compteChoix.Retirer)
                        {
                            AffichageOperationRetrait affichageOperationRetrait = new AffichageOperationRetrait();
                            affichageOperationRetrait.OperationRetraitAffichage(client,numeroComptes[inputClient - 1]);
                        }
                        else if (inputCompte == (int)compteChoix.Depot)
                        {
                            AffichageOperationDepot affichageOperationDepot = new AffichageOperationDepot();
                            affichageOperationDepot.OperationDepotAffichage(client,numeroComptes[inputClient - 1]);
                        }
                        else if (inputCompte == (int)compteChoix.Virement)
                        {
                            AffichageOperationVirement affichageOperationVirement = new AffichageOperationVirement();
                            affichageOperationVirement.OperationVirementAffichage(client,numeroComptes[inputClient - 1]);
                        }
                        else if (inputCompte == (int)compteChoix.ChangerCompte)
                        {
                            ChoixCompte(client);
                        }
                        else if (inputCompte == (int)compteChoix.ObtenirPolitique) {
                            client.comptes.Single(s=> s.numeroCompte == numeroComptes[inputClient - 1]).ObtenirPolitiqueBancaire();
                        }
                        else if (inputCompte == (int)compteChoix.Quitter)
                        {
                            inputValid = false;
                        }
                    }
                }
            }  
        }
    }
}