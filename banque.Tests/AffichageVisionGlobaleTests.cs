using Banque;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace banque.Tests;

[TestFixture]
public class VisionGlobaleTests
{
    private AffichageVisionGlobale _affichageVisionGlobale;
    private Client _client;
    private StringWriter consoleOutput;
    [SetUp]
    public void Setup()
    {
        _affichageVisionGlobale = new AffichageVisionGlobale();
        _client = new Client();
        consoleOutput = new StringWriter(); 
        Console.SetOut(consoleOutput);
    }

    [Test]
    public void VisionGlobale_NoAccountToShow()
    {
        _affichageVisionGlobale.VisionGlobale(_client);
        string[] lines = consoleOutput.ToString().Split(Environment.NewLine);

        Assert.That(lines.Length, Is.EqualTo(3)); // Vérifie le nombre total de lignes

        // Ignorer la première ligne
        Assert.That(lines[1].Trim(), Is.EqualTo("Vous n'avez pas de compte."));

    }
    
   
}