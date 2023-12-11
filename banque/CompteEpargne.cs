using Banque;

class CompteEpargne : CompteBancaire
{
    const double DEPOTMINIMAL=0.1;
    public CompteEpargne(Client client, bool autoDecouvert) : base(client, autoDecouvert)
    {
    }
    public float tauxInteret { get; set; }

    public override void EffectuerRetrait(double montant, string intituleTrans)
    {
        try
        {
            if (montant > solde && autorisationDecouvert == false)
            {
                throw new InvalidOperationException("Vous ne pouvez pas retirer car votre solde est trop faible et vous n'avez pas l'autorisation au découvert");
            }
            Console.WriteLine($"Votre solde avant opération -> {solde}");
            montant = 0 - montant;
            listeTransaction.Add(new Transaction(intituleTrans, montant));
            Console.WriteLine($"Votre solde après opération -> {solde}");
            base.EffectuerRetrait(montant,intituleTrans);
        }
        catch (InvalidOperationException ex)
        {
            string messageInvalidOperation = $"Erreur : {ex.Message}";
            Console.WriteLine(messageInvalidOperation);
            throw new InvalidOperationException(messageInvalidOperation, ex);
        }
    }

    public override void EffectuerVirement(double montant, string intituleTrans, int numeroComptePourTransfere)
    {
        try
        {
            if (montant > solde && autorisationDecouvert == false)
            {
                throw new InvalidOperationException("Vous ne pouvez pas virer vers un autre compte car votre solde est trop faible et vous n'avez pas l'autorisation au découvert");
            }
            Console.WriteLine($"Votre solde avant opération -> {solde}");
            double montantARetirer = 0-montant;
            listeTransaction.Add(new Transaction(intituleTrans, montantARetirer));
            client.comptes.Single(s => s.numeroCompte == numeroComptePourTransfere).listeTransaction.Add(new Transaction(intituleTrans, montant));
            Console.WriteLine($"Votre solde après opération -> {solde}");
            base.EffectuerVirement(montant,intituleTrans,numeroComptePourTransfere); 
        }
        catch (InvalidOperationException ex)
        {
            string messageInvalidOperation = $"Erreur : {ex.Message}";
            Console.WriteLine(messageInvalidOperation);
            throw  new InvalidOperationException(messageInvalidOperation, ex);
        }
        
    }

    public override void EffectuerDepot(double montant, string intituleTrans)
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
                base.EffectuerDepot(montant,intituleTrans);

            }
            catch (InvalidOperationException ex)
            {
                string messageInvalidOperation = $"Erreur : {ex.Message}";
                Console.WriteLine(messageInvalidOperation);
                throw  new InvalidOperationException(messageInvalidOperation, ex);
            }
    }

    /// politique compte Epargne
     public override void ObtenirPolitiqueBancaire()
    {
            /// Afficher la politique
            Console.WriteLine("Sur votre compte courant vous pouvez deposer, retirer et virer de l'argent.");
            Console.WriteLine("\n1. Le montant maximale pouvant être déposé sur votre compte est de 1000€");
            Console.WriteLine("\n2. Le montant minimal pouvant être déposé sur votre compte est de 50€");
            Console.WriteLine("\n3. Le montant maximal pouvant être retiré de votre compte est de 500€");
            Console.WriteLine("\n4. Le montant minimal pouvant être retiré de votre compte est de 50€");
            Console.WriteLine("\n5. Le montant minimal pouvant être transféré sur un autre compte est de 50€");
    }
}