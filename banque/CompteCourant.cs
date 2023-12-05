using banque; 

class CompteCourant : CompteBancaire
{
    public CompteCourant(Client client, bool autoDecouvert) : base(client, autoDecouvert)
    {
    }

    public void EffectuerVirement(){}
    public void EffectuerRetrait(){}

}