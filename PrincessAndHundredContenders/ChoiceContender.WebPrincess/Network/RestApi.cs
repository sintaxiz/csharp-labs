using System.Net;
using System.Text.Json;

namespace ChoiceContender.WebPrincess.Network;

public class RestApi
{
    private HttpClient _client;
    private string _baseUrl;
    private string _sessionQuery;

    public RestApi(string sessionId, string baseUrl)
    {
        _sessionQuery = "?sessionId=" + sessionId;
        _baseUrl = baseUrl;
    }

    public async Task<string> СompareContenders(CompareDto comparation, int id)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + "api/freind/"+ id +"/compare" + _sessionQuery);
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
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + "api/hall/reset" + _sessionQuery);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    }

    public async Task NextContender(int id)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + "api/hall/"+ id +"/next" + _sessionQuery);
        httpWebRequest.Method = "POST";

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    }

    public async Task SelectContender(int id)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + "api/hall/"+ id +"/select" + _sessionQuery);
        httpWebRequest.Method = "POST";

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Console.WriteLine("Score:" + result);
        }
        

    }
    
}