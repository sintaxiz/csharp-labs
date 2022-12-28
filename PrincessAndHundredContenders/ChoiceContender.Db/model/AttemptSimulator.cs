using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.repos;

namespace ChoiceContender.Db.model;

public class AttemptSimulator
{
    private int _currentContender;

    public Attempt Attempt { get; set; }

    public AttemptSimulator(string attemptName)
    {

        var attemptsRepo = new AttemptsRepo(new HallContext());
        var attempts = attemptsRepo.GetSome(attempt => attempt.Name == attemptName);
        if (attempts == null || attempts.Count == 0)
        {
            throw new Exception("Attempt does not exist!");
        }

        Attempt = attempts[0];
    }
    
}