using Moq;

namespace ChoiceContender.Tests;

public class Mocs
{
    private const int contendersCount = 100;
    [SetUp]
    public void Setup()
    {
        var princessMock = new Mock<IPrincess>();
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


    }
}