using ChoiceContender.exceptions;

namespace ChoiceContender.Tests;

public class Princess_Tests
{
    private const int contendersCount = 100;
    [Test]
    public void ChooseHusbandTwice_error()
    {
        var contenders = ContendersGenerator.GenerateRandom(contendersCount);
        var hall = new Hall(contenders);
        var friend = new Friend(contenders, hall);
        var princess = new Princess(hall, friend);
        princess.ChoseHusband();
        Assert.Throws<NoContendersInHallException>(delegate { princess.ChoseHusband(); });
    }
}