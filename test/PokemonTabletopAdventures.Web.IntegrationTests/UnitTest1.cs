using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace PokemonTabletopAdventures.Web.IntegrationTests;

[AllureNUnit]
[AllureEpic("Pokemon Tabletop Adventures Web")]
[AllureParentSuite("Pokemon Tabletop Adventures Web")]
[AllureFeature("Sample")]
[AllureSuite("Sample")]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}