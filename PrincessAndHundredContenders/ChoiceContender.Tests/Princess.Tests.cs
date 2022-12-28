using System.Diagnostics;
using ChoiceContender.exceptions;
using Moq;

namespace ChoiceContender.Tests;

public class Princess_Tests
{
    private const int contendersCount = 100;

    private IHall _hall;
    private IFreind _friend;
    
    [SetUp]
    public void Setup()
    {
        var friendMock = new Mock<IFreind>();
        var hallMock = new Mock<IHall>();
        friendMock.Setup(p => p.AskWhoBetter(2)).Returns(true);
        var contenders = ContendersGenerator.GenerateRandom(contendersCount);
        var hall = new Hall(contenders);
        var friend = new Friend(contenders, hall);
    }
    
    [Test]
    public void ChooseHusbandTwice_error()
    {
        var princess = new Princess(_hall, _friend);
        princess.ChoseHusband();
        Assert.Throws<NoContendersInHallException>(delegate { princess.ChoseHusband(); });
    }
}