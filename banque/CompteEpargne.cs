using banque;

class CompteEpargne : CompteBancaire, ITransactionnel
{
    public void EffectuerRetrait(){}
    public void EffectuerVirement(){}
    public float tauxInteret { get; set; }
}