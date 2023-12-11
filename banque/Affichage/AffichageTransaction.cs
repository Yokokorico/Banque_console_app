using Banque;

namespace Affichage;

public class AffichageTransaction{

    public void AffichageLesTransactionDuCompte(Client client,int numeroCompte){
        var DateMoinsUnMois = DateTime.Now;
        DateMoinsUnMois = DateMoinsUnMois.AddMonths(-1);
        var listeTransactionDuMois = client.comptes.Single(s => s.numeroCompte == numeroCompte).listeTransaction.Where(items => items.date > DateMoinsUnMois);
        foreach (var transaction in listeTransactionDuMois)
        {
            Console.WriteLine($"Date: {transaction.date}, Intitulé: {transaction.intitule}, Montant: {transaction.montant}");
        }
    }
}