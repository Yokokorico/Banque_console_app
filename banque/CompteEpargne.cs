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

            }
            catch (InvalidOperationException ex)
            {
                string messageInvalidOperation = $"Erreur : {ex.Message}";
                Console.WriteLine(messageInvalidOperation);
                throw  new InvalidOperationException(messageInvalidOperation, ex);
            }
    }
}