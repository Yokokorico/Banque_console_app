using Banque;

public class CompteCourant : CompteBancaire
{
    const double DEPOTMINIMAL = 0.1;
    const double DEPOTMAXIMAL = 4000;
    const double VIREMENTMAX = 1000;
    const double RETRAITMAX = 1000;
    public CompteCourant(Client client, bool autoDecouvert) : base(client, autoDecouvert)
    {
    }

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
            throw new InvalidOperationException("Le montant maximal est de 1000€");
        }
        else
        {
            Console.WriteLine($"Votre solde avant opération Retrait-> {solde}");
            montant = 0 - montant;
            listeTransaction.Add(new Transaction(intituleTrans, montant));
            Console.WriteLine($"Votre solde après opération Retrait-> {solde}");

            // Cas où le retrait est autorisé
            if (montant >= solde && autorisationDecouvert == true)
            {
                double frais = CalculerFrais(montant, 0.04);
                double services = montant * 0.04;
                listeTransaction.Add(new Transaction("services", services));
                Console.WriteLine($"Frais bancaires appliqués-> {services}");
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
                throw new InvalidOperationException("Le montant maximal est de 1000€");
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
                throw new InvalidOperationException("Le montant maximal est de 4000€");
            }
            else {
                Console.WriteLine($"Votre solde avant opération Depot-> {solde}");
                listeTransaction.Add(new Transaction(intituleTrans, montant));
                Console.WriteLine($"Votre solde après opération Depot-> {solde}");
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

    /// Politique compte courant 
    public override void ObtenirPolitiqueBancaire()
    {
        /// Afficher la politique
        Console.WriteLine("Sur votre compte courant vous pouvez deposer, retirer et virer de l'argent.");
        Console.WriteLine("\n1. Le montant maximal pouvant être déposé sur votre compte est de 4000€");
        Console.WriteLine("\n2. Le montant minimal pouvant être déposé sur votre compte est de 0,1€");
        Console.WriteLine("\n3. Le montant maximal pouvant être retiré de votre compte est de 1000€");
        Console.WriteLine("\n4. Le montant minimal pouvant être retiré de votre compte est de 0,1€");
        Console.WriteLine("\n5. Le montant maximal pouvant être transféré sur un autre compte est de 1000€");
        Console.WriteLine("\n6. Le montant minimal pouvant être transféré sur un autre compte est de 0,1€");

    }

    public override double CalculerFrais(double montant, double taux)
    {
        double services = montant * taux;
        return services;
       
    }
}