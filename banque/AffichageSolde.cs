using banque;
namespace Affichage{
    public class AffichageSolde{
        public static void AffichageDuSolde(int compteChoisi, Client client){
            
            Console.WriteLine($"Le solde de votre compte est de {client.comptes.Single(s => s.numeroCompte == compteChoisi).solde}");
        }
    }
}
