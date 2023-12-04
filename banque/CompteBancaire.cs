namespace banque 
{
    public class CompteBancaire
    {
        public string client { get; set; }
        public int solde { get; set; }
        public int numeroCompte { get; set;}
        public List<Transaction> listeTransaction { get; set; }
        public bool autorisationDecouvert { get; set; }
    }

}