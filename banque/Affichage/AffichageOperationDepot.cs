using Banque;

namespace Affichage;

public class AffichageOperationDepot
{
    /// <summary>
    /// Méthode d'affichage question réponse pour le depot
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public void OperationDepotAffichage(Client client, int numeroCompte)
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
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        catch (InvalidOperationException ex)
        {
            Thread.Sleep(2000);
            Console.Clear();
            AffichageCompte affichageCompte = new AffichageCompte();
            affichageCompte.Menu(client);
            
        }
    }
}