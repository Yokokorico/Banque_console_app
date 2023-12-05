using Affichage;
using banque;

public class Program{

    public static void Main(string[] args){
        Client client = new Client();
        CompteBancaire compte = new CompteBancaire(client,false);
        client.comptes.Add(compte);
        AffichageSolde. AffichageDuSolde(client.comptes[0].numeroCompte,client);
    }
}