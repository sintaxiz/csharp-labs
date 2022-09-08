using System.Text.Json;

namespace ChoiceContender;

public class ContendersGenerator
{
    public static List<Contender> GenerateRandom(int quantity)
    {
        List<Contender> contenders = new List<Contender>(quantity);
        for (int i = 0; i < quantity; i++)
        {
            contenders.Add(new Contender("c" + (i + 1), i));
        }

        return contenders;
    }

    public static List<Contender> GenerateFromInternet(int quantity)
    {
        string apiKeyFileName = "../../../api-key.txt";
        string apiEndpoint = $"https://randommer.io/api/Name?quantity={quantity}&nameType=fullname";
        
        List<Contender> contenders = new List<Contender>();
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", File.ReadLines(apiKeyFileName).First());
        HttpResponseMessage resp = client.GetAsync(apiEndpoint).Result;
        if (resp.IsSuccessStatusCode)
        {
            string names = resp.Content.ReadAsStringAsync().Result;
            var namesArray = JsonSerializer.Deserialize<List<string>>(names);
            namesArray.ForEach(n => contenders.Add(new Contender(n, contenders.Count)));
        }
        else
        {
            Console.WriteLine("Can not get names: " + resp.StatusCode);
        }

        Random random = new Random();
        return contenders.OrderBy(i => random.Next()).ToList();
    }
}