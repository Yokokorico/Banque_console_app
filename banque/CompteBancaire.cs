using Affichage;

namespace banque
{
    public abstract class CompteBancaire : ITransactionnel
    {
        const double DEPOTMINIMAL = 0.1;
        public Client client { get; set; }
        public double solde
        {
            get { return AffichageSolde.CalculSolde(numeroCompte, this.client); }
            set { solde = value; }
        }
        public int numeroCompte { get; set; }
        public List<Transaction> listeTransaction { get; set; } = new List<Transaction>();
        public bool autorisationDecouvert { get; set; }

        public CompteBancaire(Client clientDuCompte, bool autoDecouvert)
        {
            Random random = new Random();
            client = clientDuCompte;
            numeroCompte = random.Next(100000, 999999);
            autorisationDecouvert = autoDecouvert;
        }

        public abstract void EffectuerRetrait(double montant, string intituleTrans);        

        public abstract void EffectuerVirement(double montant, string intituleTrans, int numeroComptePourTransfere);
       

        public abstract void EffectuerDepot(double montant, string intituleTrans);
        
    }
}