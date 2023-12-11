using Banque;
namespace Affichage;    
public class AffichageOperationVirement{
    /// <summary>
    /// Méthode d'affichage question réponse pour le virement
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public void OperationVirementAffichage(Client client, int numeroCompte)
    {
        AffichageCompte affichageCompte = new AffichageCompte();
        try
        {
            var inputUtilisateurValide = true;
            while (inputUtilisateurValide)
            {
                Console.WriteLine("Vous avez selectionné Virement\nEntrer le montant de votre Virement\n*Attention le montant doit-être supérieur à 0.1€\nMontant ->");
                if (!double.TryParse(Console.ReadLine(), out double montantEntrerParUtilisateur))
                {
                    Console.WriteLine("Merci de rentrer un moment valide");
                    continue;

                }

                var inputNumeroDeCompteValide = true;
                while (inputNumeroDeCompteValide)
                {
                    Console.WriteLine("Entrez le numéro de compte de receveur");

                    if (!Int32.TryParse(Console.ReadLine(), out int numeroComptePourEnvoiVirement))
                    {
                        Console.WriteLine("Merci de rentrer un numéro de compte valide");
                        continue;
                    }
                    
                    inputNumeroDeCompteValide = false;
                    Console.WriteLine("Entrez un intitulé (Optionnel)");
                    var inituleEntrerParUtilisateur = Console.ReadLine();
                    client.comptes.Single(s => s.numeroCompte == numeroCompte)
                        .EffectuerVirement(montantEntrerParUtilisateur,
                                            inituleEntrerParUtilisateur,
                                            numeroComptePourEnvoiVirement);
                    inputUtilisateurValide = false;
                    Thread.Sleep(2000);
                    Console.Clear();    
                    affichageCompte.Menu(client);
                }


            }
        }
        catch (InvalidOperationException ex)
        {
            Thread.Sleep(2000);
            Console.Clear();
            
            affichageCompte.Menu(client);
            
        }

    }
}
