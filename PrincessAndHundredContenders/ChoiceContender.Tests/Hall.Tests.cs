using ChoiceContender.exceptions;

namespace ChoiceContender.Tests;

public class Hall_Tests
{
    private const int contendersCount = 100;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CallNextContender_error()
    {
        var contenders = ContendersGenerator.GenerateRandom(contendersCount);
        var hall = new Hall(contenders);

        for (int i = 0; i < contendersCount; i++)
        {
            hall.CallNextContender(); // just skip
        }

        Assert.Throws<NoContendersInHallException>((delegate { hall.CallNextContender(); }));

    }
}