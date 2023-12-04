namespace banque 
{
    public class CompteBancaire
    {
        public Client client { get; set; }
        public int solde { get; set; } = 0;
        public int numeroCompte { get; set;}
        public List<Transaction> listeTransaction { get; set; }
        public bool autorisationDecouvert { get; set; }

        public CompteBancaire(Client client, bool autoDecouvert){
            Random random = new Random();
            client= this.client;
            numeroCompte = random.Next(100000,999999);
            autorisationDecouvert=autoDecouvert;
        }
    }

    
}