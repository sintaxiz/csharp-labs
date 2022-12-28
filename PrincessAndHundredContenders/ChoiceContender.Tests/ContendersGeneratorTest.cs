namespace ChoiceContender.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    bool IsAllUnique<T>(IEnumerable<T> values)
    {
        HashSet<T> hashSet = new HashSet<T>();

        return values.All(x => hashSet.Add(x));
    }
    
    [Test]
    public void GenerateFromInternet_100_uniquereturned()
    {
        var contendersCount = 100;

        var contenders =  ContendersGenerator.GenerateFromInternet(contendersCount);

        Assert.IsTrue(IsAllUnique(contenders));
    }
}