using Banque;

namespace banque.Tests;

[TestFixture]
public class CompteEpargneTests
{
    private CompteBancaire _compteBancaire;
    private Client client;
    [SetUp]
    public void Setup()
    {
        client = new Client();
        _compteBancaire = new CompteCourant(client, false);
    }

    [Test]
    public void EffectuerRetrait_HaveNegatifAmmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(-100, ""));
    }
    [Test]
    public void EffectuerRetrait_ToBigPrecision_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(1.123456798, ""));
    }
    [Test]
    public void EffectuerRetrait_HavePositifsOverdraftAccount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(100, ""));
    }
    [Test]
    public void EffectuerRetrait_HaveZeroAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(0, ""));
    }
    [Test]
    public void EffectuerRetrait_ToBigAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(2001, ""));
    }
    [Test]
    public void EffectuerRetrait_ToLowAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(0.01, ""));
    }
    /************************************************************************************/
    /*                          EffectuerDepot Test                                     */
    /************************************************************************************/
    [Test]
    public void EffectuerDepot_HaveNegatifAmmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(-100, ""));
    }
    [Test]
    public void EffectuerDepot_ToBigPrecision_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(1.123456798, ""));
    }
    [Test]
    public void EffectuerDepot_HaveZeroAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(0, ""));
    }
    [Test]
    public void EffectuerDepot_ToBigAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(8001, ""));
    }
    [Test]
    public void EffectuerDepot_ToLowAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(0.01, ""));
    }
    /************************************************************************************/
    /*                          EffectuerVirement Test                                     */
    /************************************************************************************/
    [Test]
    public void EffectuerVirement_ToLowAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(0.01, ""));
    }
    [Test]
    public void EffectuerVirement_ToBigAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(2001, ""));
    }
    [Test]
    public void EffectuerVirement_HaveZeroAmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(0, ""));
    }
    [Test]
    public void EffectuerVirement_HaveNegatifAmmount_Throw_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => _compteBancaire.EffectuerRetrait(-100, ""));
    }
}