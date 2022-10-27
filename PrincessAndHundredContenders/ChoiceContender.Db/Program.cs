// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.model;
using ChoiceContender.Db.repos;
using NDesk.Options;

namespace ChoiceContender.Db;

public class Program
{
    private enum ProgramMode
    {
        SimulationAll,
        SimulationSome,
        GeneratingAttempts,
        ShowHelp
    }


    public static void Main(string[] args)
    {
        var programMode = ProgramMode.ShowHelp;
        var attemptNames = new List<string>();
        var optionSet = new OptionSet()
        {
            {
                "s|simulate=",
                "Run program in simulation mode. Possible values: {SIMULATION_MODE}=all, {SIMULATION_MODE}=some",
                v =>
                {
                    if (v != null) programMode = DefineSimulationMode(v);
                }
            },
            {
                "g|generate=", "Generate attempt with {NAME}.",
                v =>
                {
                    if (v != null)
                    {
                        programMode = ProgramMode.GeneratingAttempts;
                        attemptNames.Add(v);
                    }
                }
            },
            {
                "h|help", "Show this message and exit",
                v =>
                {
                    if (v != null) programMode = ProgramMode.ShowHelp;
                }
            }
        };

        attemptNames.AddRange(optionSet.Parse(args));
        RunProgram(programMode, attemptNames, optionSet);
    }

    private static void RunProgram(ProgramMode programMode, List<string> attemptsNames, OptionSet optionSet)
    {
        switch (programMode)
        {
            case ProgramMode.SimulationAll:
                PrincessSimulator.SimulateAll();
                break;

            case ProgramMode.SimulationSome:
                foreach (var attempt in attemptsNames)
                {
                    PrincessSimulator.SimulateBehavior(attempt);
                }

                break;

            case ProgramMode.GeneratingAttempts:
                foreach (var attempt in attemptsNames)
                {
                    AttemptGenerator.GenerateAttempt(attempt);
                }

                break;

            case ProgramMode.ShowHelp:
                ShowHelp(optionSet);
                return;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void ShowHelp(OptionSet p)
    {
        Console.WriteLine("Usage: prog [OPTIONS]+ attemptNames");
        Console.WriteLine("Create and simulate princess behavior.");
        Console.WriteLine("Choose mode: simulate or create");
        Console.WriteLine();
        Console.WriteLine("Options:");
        p.WriteOptionDescriptions(Console.Out);
    }

    private static ProgramMode DefineSimulationMode(string sm)
    {
        return sm switch
        {
            "all" => ProgramMode.SimulationAll,
            "some" => ProgramMode.SimulationSome,
            _ => throw new OptionException("Wrong simulation parameter.", "-s, --simulate")
        };
    }
}