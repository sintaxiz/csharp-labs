using ChoiceContender.exceptions;

namespace ChoiceContender.Tests;

public class Friend_Tests
{
    private const int contendersCount = 100;

    [Test]
    public void askAboutUnfamiliarContender_error()
    {
        var contenders = ContendersGenerator.GenerateRandom(contendersCount);
        var hall = new Hall(contenders);
        var friend = new Friend(contenders, hall);
        Assert.Throws<UnfamiliarContenderException>(() => { friend.AskWhoBetter(10); });
    }
}