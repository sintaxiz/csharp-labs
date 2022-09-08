// See https://aka.ms/new-console-template for more information

using ChoiceContender;

const string divider = "-----";

List<Contender> contenders = ContendersGenerator.GenerateFromInternet(100);
Hall hall = new Hall(contenders);
Princess princess = new Princess(hall);

string file = "../../../contenders.txt";

int husbandIdx = princess.ChoseHusband();
Console.WriteLine($"Chosen husband: {contenders[husbandIdx].Name}" +
                  $"/{contenders[husbandIdx].Rating}");

using StreamWriter sw = File.CreateText(file);
contenders.ForEach(contender=> sw.WriteLine(contender.Name + "/" + contender.Rating));
sw.WriteLine(divider);
sw.WriteLine(husbandIdx.ToString());