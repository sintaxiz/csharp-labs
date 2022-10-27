namespace ChoiceContenderDatabase;

public class Contender 
{
    public string Name { get; }
    public int Rating { get; }

    public Contender(string name, int rating)
    {
        Name = name;
        Rating = rating;
    }
}