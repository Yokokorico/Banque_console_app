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
        public NotificationManager.NotificationDelegate notificationManager;
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
        public virtual void EffectuerRetrait(double montant, string intituleTrans){
            notificationManager.Invoke($"Vous avez effectué un retrait de {montant} sur le compte numéro {numeroCompte} le {DateTime.Now.ToString()}\n");
        }      
        /// <summary>
        /// Méthode permettant d'effectuer un virement vers un autre compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="intituleTrans"></param>
        /// <param name="numeroComptePourTransfere"></param>
        public virtual void EffectuerVirement(double montant, string intituleTrans, int numeroComptePourTransfere){
            notificationManager.Invoke($"Vous avez effectué un virement de {montant} sur le compte numéro {numeroCompte} vers le compte numéro {numeroComptePourTransfere} le {DateTime.Now.ToString()}\n");
        }  
        /// <summary>
        /// Méthode permettant d'effectuer un depôt sur son compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="intituleTrans"></param>
        public virtual void EffectuerDepot(double montant, string intituleTrans){
            notificationManager.Invoke($"Vous avez effectué un depot de {montant} sur le compte numéro {numeroCompte} le {DateTime.Now.ToString()}\n");
        }  

        public abstract void ObtenirPolitiqueBancaire();
        
        public bool TesterNombreDeDecimal(double montant){
            string partieDecimaleStr = (montant - Math.Floor(montant)).ToString().TrimStart('0');
            if(partieDecimaleStr.Length > 2){
                return false;
            }
            return true;
        }
    }
}