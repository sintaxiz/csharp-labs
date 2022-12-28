using System.Text.Json;

namespace DIContainer;

public class ContenderGenerator
{
    public List<Contender> GenerateFromInternet(int contenderCount)
    {
        var apiKeyFileName = "./api-key.txt";
        var apiEndpoint = $"https://randommer.io/api/Name?quantity={contenderCount}&nameType=fullname";
        
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