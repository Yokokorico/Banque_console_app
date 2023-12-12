namespace Banque;
public interface ITransactionnel{
    public void EffectuerRetrait(double montant, string intituleTrans);

    public void EffectuerVirement(double montant, string intituleTrans, int numeroComptePourTransfere);

    public void EffectuerDepot(double montant, string intituleTrans);
}