using Affichage;

namespace Banque
{
    public abstract class CompteBancaire : ITransactionnel
    {
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
        /// <summary>
        /// Méthode permettant d'effectuer un retrait de son compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="intituleTrans"></param>
        public abstract void EffectuerRetrait(double montant, string intituleTrans);        
        /// <summary>
        /// Méthode permettant d'effectuer un virement vers un autre compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="intituleTrans"></param>
        /// <param name="numeroComptePourTransfere"></param>
        public abstract void EffectuerVirement(double montant, string intituleTrans, int numeroComptePourTransfere);
        /// <summary>
        /// Méthode permettant d'effectuer un depôt sur son compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="intituleTrans"></param>
        public abstract void EffectuerDepot(double montant, string intituleTrans);

        public abstract void ObtenirPolitiqueBancaire(Client client);
        
    }
}