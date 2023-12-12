using Banque;

namespace Affichage;

public class AffichageTransaction
{
    /// <summary>
    /// Afficher toutes les transactions détailliées d'un compte donné
    /// </summary>
    /// <param name="client"></param>
    /// <param name="numeroCompte"></param>
    /// <exception cref="InvalidDataException">Liste vide</exception>
    public void AffichageLesTransactionDuCompte(Client client, int numeroCompte)
    {

        var DateMoinsUnMois = DateTime.Now;
        DateMoinsUnMois = DateMoinsUnMois.AddMonths(-1);
        var listeTransactionDuMois = client.comptes.Single(s => s.numeroCompte == numeroCompte).listeTransaction.Where(items => items.date > DateMoinsUnMois);
        if (listeTransactionDuMois.Count() == 0)
        {
            throw new InvalidDataException("Vous n'avez aucune transaction sur ce compte");
        }
        foreach (var transaction in listeTransactionDuMois)
        {
            Console.WriteLine($"Date: {transaction.date}, Intitulé: {transaction.intitule}, Montant: {transaction.montant}");
        }
    }
}