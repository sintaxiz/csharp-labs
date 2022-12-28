namespace ChoiceContender.WebPrincess.Network;

public class CompareDto
{
    public CompareDto(string name1, string name2)
    {
        this.name1 = name1;
        this.name2 = name2;
    }

    private string name1 { get; set; }
    private string name2 { get; set; }
}