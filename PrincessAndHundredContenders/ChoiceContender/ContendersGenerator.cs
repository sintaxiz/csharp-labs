using System.Text.Json;

namespace ChoiceContender;

public class ContendersGenerator
{
    public static List<Contender> GenerateRandom(int quantity)
    {
        var contenders = new List<Contender>(quantity);
        for (var i = 0; i < quantity; i++)
        {
            contenders.Add(new Contender("c" + (i + 1), i));
        }

        return contenders;
    }

    public static List<Contender> GenerateFromInternet(int quantity)
    {
        var apiKeyFileName = "../../../api-key.txt";
        var apiEndpoint = $"https://randommer.io/api/Name?quantity={quantity}&nameType=fullname";
        
        var contenders = new List<Contender>();
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", File.ReadLines(apiKeyFileName).First());
        var resp = client.GetAsync(apiEndpoint).Result;
        if (resp.IsSuccessStatusCode)
        {
            var names = resp.Content.ReadAsStringAsync().Result;
            var namesArray = JsonSerializer.Deserialize<List<string>>(names);
            namesArray.ForEach(n => contenders.Add(new Contender(n, contenders.Count)));
        }
        else
        {
            Console.WriteLine("Can not get names: " + resp.StatusCode);
        }

        var random = new Random();
        return contenders.OrderBy(i => random.Next()).ToList();
    }
}