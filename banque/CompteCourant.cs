using banque; 

class CompteCourant : CompteBancaire, ITransactionnel
{
    public CompteCourant(Client client, bool autoDecouvert) : base(client, autoDecouvert)
    {
    }

    public void EffectuerVirement(){}
    public void EffectuerRetrait(){}

}