using Affichage;

namespace banque
{
    public class CompteBancaire : ITransactionnel
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

        public void EffectuerRetrait(double montant, string intituleTrans)
        {
            try
            {
                if (montant > solde && autorisationDecouvert == false)
                {
                    throw new InvalidOperationException("Vous ne pouvez pas retirer car votre solde est trop faible et vous n'avez pas l'autorisation au découvert");
                }
                Console.WriteLine($"Votre solde avant opération -> {solde}");
                montant = 0-montant;
                listeTransaction.Add(new Transaction(intituleTrans, montant));
                Console.WriteLine($"Votre solde après opération -> {solde}");

            }
            catch (InvalidOperationException ex)
            {
                string messageInvalidOperation = $"Erreur : {ex.Message}";
                Console.WriteLine(messageInvalidOperation);
                throw  new InvalidOperationException(messageInvalidOperation, ex);
            }
        }

        public void EffectuerVirement(double montant, string intituleTrans, int numeroComptePourTransfere)
        {
            throw new NotImplementedException();
        }

        public void EffectuerDepot(double montant, string intituleTrans)
        {
            try
            {
                if (montant < DEPOTMINIMAL)
                {
                    throw new InvalidOperationException("Le montant minimal est de 0.1€");
                }

                Console.WriteLine($"Votre solde avant opération -> {solde}");
                listeTransaction.Add(new Transaction(intituleTrans, montant));
                Console.WriteLine($"Votre solde après opération -> {solde}");

            }
            catch (InvalidOperationException ex)
            {
                string messageInvalidOperation = $"Erreur : {ex.Message}";
                Console.WriteLine(messageInvalidOperation);
                throw  new InvalidOperationException(messageInvalidOperation, ex);
            }
        }
    }
}