using Banque;

namespace Affichage;

public class AffichageOperation
{
    /// <summary>
    /// Méthode d'affichage question réponse pour le depot
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public static void AffichageOperationDepot(Client client, int numeroCompte)
    {
        try
        {
            var inputUtilisateurValide = true;
            while (inputUtilisateurValide)
            {
                Console.WriteLine("Vous avez selectionné depôt\nEntrer le montant de votre depôt\n*Attention le montant doit-être supérieur à 0.1€\nMontant ->");
                if (!double.TryParse(Console.ReadLine(), out double montantEntrerParUtilisateur))
                {
                    Console.WriteLine("Merci de rentrer un moment valide");
                    continue;
                }
               
                Console.WriteLine("Entrez un intitulé (Optionnel)");
                var inituleEntrerParUtilisateur = Console.ReadLine();
                client.comptes.Single(s => s.numeroCompte == numeroCompte)
                .EffectuerDepot(montantEntrerParUtilisateur,
                                inituleEntrerParUtilisateur);
                inputUtilisateurValide = false;
            
            }
        }
        catch (InvalidOperationException ex)
        {
            AffichageCompte.Menu(client);
        }

    }
    /// <summary>
    /// Méthode d'affichage question réponse pour le virement
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public static void AffichageOperationVirement(Client client, int numeroCompte)
    {
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
                    
                }


            }
        }
        catch (InvalidOperationException ex)
        {
            AffichageCompte.Menu(client);
        }

    }
    /// <summary>
    /// Méthode d'affichage question réponse pour le Retrait
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public static void AffichageOperationRetrait(Client client, int numeroCompte)
    {
        try
        {
            var inputUtilisateurValide = true;
            while (inputUtilisateurValide)
            {
                Console.WriteLine("Vous avez selectionné retrait\nEntrer le montant de votre retrait\nMontant ->");
                if (!double.TryParse(Console.ReadLine(), out double montantEntrerParUtilisateur))
                {
                    Console.WriteLine("Merci de rentrer un moment valide");
                    continue;
                }

                Console.WriteLine("Entrez un intitulé (Optionnel)");
                var inituleEntrerParUtilisateur = Console.ReadLine();
                client.comptes.Single(s => s.numeroCompte == numeroCompte)
                .EffectuerRetrait(montantEntrerParUtilisateur, 
                                    inituleEntrerParUtilisateur);
                inputUtilisateurValide = false;

            }
        }
        catch (InvalidOperationException ex)
        {
            AffichageCompte.Menu(client);
        }

    }
}