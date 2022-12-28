// See https://aka.ms/new-console-template for more information

public class Program
{

    public class Parameters
    {
        private int Strength { get; set; }
    }
    
    public static void swim(Func<Parameters, int> move)
    {
        int m = move(new Parameters());
        Console.WriteLine($"Move on {m}");
    }
    
    public static void Main()
    {
        swim(parameters =>
        {
            Console.WriteLine("ho-ho");
            return 0;
        });
    }

    public static int MoveInMain(Parameters parameters)
    {
        return 0;
    }
}