using System.Net;
using System.Text.Json;

namespace ChoiceContender.WebPrincess.Network;

public class RestApi
{
    private HttpClient _client;
    private string baseUrl = "https://nsupeakybrideapi20221215134314.azurewebsites.net/";
    private object sessionId = "?sessionId=i1m-doe-omh-fbj";

    public RestApi()
    {
    }

    public async Task<string> СompareContenders(Comparation comparation, int id)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "api/freind/"+ id +"/compare" + sessionId);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            var json = JsonSerializer.Serialize(comparation);
            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            return result;
        }
    }

    public async Task ResetHall()
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "api/hall/reset" + sessionId);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    }

    public async Task NextContender(int id)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "api/hall/"+ id +"/next" + sessionId);
        httpWebRequest.Method = "POST";

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    }

    public async Task SelectContender(int id)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "api/hall/"+ id +"/select" + sessionId);
        httpWebRequest.Method = "POST";

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Console.WriteLine("Score:" + result);
        }
        

    }
    
}