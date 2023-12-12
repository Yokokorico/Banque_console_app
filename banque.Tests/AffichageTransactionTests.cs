using Banque;
using Affichage;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace banque.Tests;

[TestFixture]
public class AffichageTransactionTests
{
    private AffichageTransaction _affichageTransaction;
    private Client _client;
    private CompteCourant _compteCourant;
    [SetUp]
    public void Setup()
    {
        _affichageTransaction = new AffichageTransaction();
        _client = new Client();
        _compteCourant = new CompteCourant(_client,false);
        _client.comptes.Add(_compteCourant);
    }

    [Test]
    public void AffichageTransaction_NoTransactionToShow()
    {
        Assert.Throws<InvalidDataException>(() => _affichageTransaction.AffichageLesTransactionDuCompte(_client,_client.comptes[0].numeroCompte));
    }
    
   
}