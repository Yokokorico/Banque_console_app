using banque;
namespace Affichage{
    public class AffichageSolde{
        public static void AffichageDuSolde(int compteChoisi, Client client){
            Console.WriteLine($"Le solde de votre compte est de {CalculSolde(compteChoisi,client)}");
        }

        public static double CalculSolde(int compteChoisi, Client client){
            if(client.comptes.Single(s => s.numeroCompte == compteChoisi).listeTransaction.Count == 0){
                return 0;
            }else{
                return client.comptes.Single(s => s.numeroCompte == compteChoisi).listeTransaction.Sum(objet => objet.montant);
            }
        }
    }
}
