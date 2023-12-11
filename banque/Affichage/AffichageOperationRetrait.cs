using Banque;
namespace Affichage;

public class AffichageOperationRetrait{
    /// <summary>
    /// Méthode d'affichage question réponse pour le Retrait
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    public void OperationRetraitAffichage(Client client, int numeroCompte)
    {
        AffichageCompte affichageCompte = new AffichageCompte();
        try
        {
            var inputUtilisateurValide = true;
            while (inputUtilisateurValide)
            {
                Console.WriteLine("\nVous avez selectionné retrait\nEntrer le montant de votre retrait\nMontant ->");
                if (!double.TryParse(Console.ReadLine(), out double montantEntrerParUtilisateur) || montantEntrerParUtilisateur < 0)
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
                Thread.Sleep(2000);
                // Console.Clear();
                affichageCompte.Menu(client);
            }
        }
        catch (InvalidOperationException ex)
        {
            Thread.Sleep(2000);
            // Console.Clear();
            
            
            
        }

    }
}