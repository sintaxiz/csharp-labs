// See https://aka.ms/new-console-template for more information

using ChoiceContender;

const string divider = "-----";

var contenders = ContendersGenerator.GenerateRandom(100);
var hall = new Hall(contenders);
var friend = new Friend(contenders, hall);
var princess = new Princess(hall, friend);

var file = "../../../contenders.txt";

var husbandIdx = await princess.ChoseHusband();
var happyLevel = 0;
if (husbandIdx == -1)
{
    happyLevel = 10;
} else if (contenders[husbandIdx].Rating <= 50)
{
    happyLevel = 0;
}
else
{
    happyLevel = contenders[husbandIdx].Rating;
}

Console.WriteLine($"Chosen husband: {contenders[husbandIdx].Name}" +
                  $"/{contenders[husbandIdx].Rating}");

using var sw = File.CreateText(file);
contenders.ForEach(contender => sw.WriteLine(contender.Name + "/" + contender.Rating));
sw.WriteLine(divider);
sw.WriteLine(happyLevel.ToString());