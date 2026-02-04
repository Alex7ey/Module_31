using System;

public class GameRules
{
    public GameRules(Func<bool> winRules, Func<bool> defeatRules)
    {
        WinCondition = winRules;
        LoseCondition = defeatRules;
    }

    public Func<bool> WinCondition { get; private set; }
    public Func<bool> LoseCondition { get; private set; }
}
