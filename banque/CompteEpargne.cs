using Banque;

class CompteEpargne : CompteBancaire
{
    const double DEPOTMINIMAL = 0.1;
    const double DEPOTMAXIMAL = 8000;
    const double VIREMENTMAX = 2000;
    const double RETRAITMAX = 2000;
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
            else if (!TesterNombreDeDecimal(montant))
            {
                throw new InvalidOperationException("Merci de mettre au maximum 2 chiffre après la virgule");
            }
            else if (montant > RETRAITMAX)
            {
            throw new InvalidOperationException("Le montant maximal est de 2000€");
            }
           else {
            Console.WriteLine($"Votre solde avant opération -> {solde}");
            montant = 0 - montant;
            listeTransaction.Add(new Transaction(intituleTrans, montant));
            Console.WriteLine($"Votre solde après opération -> {solde}");
            
            if (montant >= solde && autorisationDecouvert == true)
            {
                double frais = CalculerFrais(montant, 0.08);
                double agios = montant * 0.08;
                listeTransaction.Add(new Transaction("agios", agios));
                Console.WriteLine($"Frais bancaires appliqués-> {agios}");
                Console.WriteLine($"Votre solde après opération frais bancaire-> {solde}");
            }

            base.EffectuerRetrait(montant, intituleTrans);
        }

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
            if (!TesterNombreDeDecimal(montant))
            {
                throw new InvalidOperationException("Merci de mettre au maximum 2 chiffre après la virgule");
            }
            else if (montant > VIREMENTMAX)
            {
            throw new InvalidOperationException("Le montant maximal est de 2000€");
            }
            client.comptes.Single(s => s.numeroCompte == numeroComptePourTransfere).EffectuerDepot(montant, intituleTrans);
            EffectuerRetrait(montant, intituleTrans);
            base.EffectuerVirement(montant, intituleTrans, numeroComptePourTransfere);
        }
        catch (InvalidOperationException ex)
        {
            string messageInvalidOperation = $"Erreur : {ex.Message}";
            Console.WriteLine(messageInvalidOperation);
            throw new InvalidOperationException(messageInvalidOperation, ex);
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
            else if (!TesterNombreDeDecimal(montant))
            {
                throw new InvalidOperationException("Merci de mettre au maximum 2 chiffre après la virgule");
            }
            else if (montant > DEPOTMAXIMAL)
            {
            throw new InvalidOperationException("Le montant maximal est de 8000€");
            }

            else {
                Console.WriteLine($"Votre solde avant opération -> {solde}");
                listeTransaction.Add(new Transaction(intituleTrans, montant));
                Console.WriteLine($"Votre solde après opération -> {solde}");

                base.EffectuerDepot(montant, intituleTrans);
            }

        }
        catch (InvalidOperationException ex)
        {
            string messageInvalidOperation = $"Erreur : {ex.Message}";
            Console.WriteLine(messageInvalidOperation);
            throw new InvalidOperationException(messageInvalidOperation, ex);
        }
    }

    /// politique compte Epargne
    public override void ObtenirPolitiqueBancaire()
    {
        /// Afficher la politique
        Console.WriteLine("Sur votre compte courant vous pouvez deposer, retirer et virer de l'argent.");
        Console.WriteLine("\n1. Le montant maximale pouvant être déposé sur votre compte est de 8000€");
        Console.WriteLine("\n2. Le montant minimal pouvant être déposé sur votre compte est de 0,1€");
        Console.WriteLine("\n3. Le montant maximal pouvant être retiré de votre compte est de 2000€");
        Console.WriteLine("\n4. Le montant minimal pouvant être retiré de votre compte est de 0,1€");
        Console.WriteLine("\n5. Le montant maximal pouvant être transféré sur un autre compte est de 2000€");
        Console.WriteLine("\n6. Le montant minimal pouvant être transféré sur un autre compte est de 0,1€");
    }

    public override double CalculerFrais(double montant, double taux) 
    {
        double agios = montant * taux;
        return agios;
    }
}