using ChoiceContender.Db.entities;

namespace ChoiceContender.Db.model;

public static class AttemptGenerator
{
    public static entities.Attempt GenerateAttempt(int count, string name)
    {
        List<Contender> contenders= ContendersGenerator.GenerateRandom(count);
        return new entities.Attempt{Name = name, Count = count, Contenders = contenders};
    }
}