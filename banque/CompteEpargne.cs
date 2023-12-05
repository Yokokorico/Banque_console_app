using banque;

class CompteEpargne : CompteBancaire, ITransactionnel
{
    public CompteEpargne(Client client, bool autoDecouvert) : base(client, autoDecouvert)
    {
    }

    public void EffectuerRetrait(){}
    public void EffectuerVirement(){}
    public float tauxInteret { get; set; }
}