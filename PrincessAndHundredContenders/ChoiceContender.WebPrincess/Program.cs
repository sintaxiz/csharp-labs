// See https://aka.ms/new-console-template for more information

using ChoiceContender.WebPrincess;

Console.WriteLine("Starting program...");


Console.WriteLine("Creating Http client...");
var client = new HttpClient();

try
{
    using HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    // Above three lines can be replaced with new helper method below
    // string responseBody = await client.GetStringAsync(uri);

    Console.WriteLine(responseBody);
}
catch (HttpRequestException e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}



var hall = new WebHall();
var friend = new WebFreind(hall);
var princess = new WebPrincess(hall, friend);


var attemptsCount = 100;
for (var i = 0; i < attemptsCount; i++)
{
    var husbandRank = princess.ChoseHusband();
    var happyLevel = 0;
    if (husbandRank == -1)
    {
        happyLevel = 10;
    } else if (husbandRank <= 50)
    {
        happyLevel = 0;
    }
    else
    {
        happyLevel = husbandRank;
    }

    Console.WriteLine($"{i}: Choose husband with rating {husbandRank}" +
                      $" Happy level:{happyLevel}\n");
}

