using Affichage;

namespace banque 
{
    public class CompteBancaire
    {
        public Client client { get; set; }
        public double solde { 
            get{ return AffichageSolde.CalculSolde(numeroCompte,client);}
            set {solde=value;} 
        }
        public int numeroCompte { get; set;}
        public List<Transaction> listeTransaction { get; set; } = new List<Transaction>();
        public bool autorisationDecouvert { get; set; }

        public CompteBancaire(Client client, bool autoDecouvert){
            Random random = new Random();
            client= this.client;
            numeroCompte = random.Next(100000,999999);
            autorisationDecouvert=autoDecouvert;
        }

    }
}