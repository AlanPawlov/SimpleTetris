using System;
using Zenject;

public class ScoreCounter
{
    public event EventHandler<int> OnScoreChanged;
    private int _lineCleanReward;
    private int _currentScore;

    public ScoreCounter(GameLogicController gameLogicController, int lineCleanReward)
    {
        gameLogicController.OnLineCleaned += OnChangeScore;
        _lineCleanReward = lineCleanReward;
    }

    private void OnChangeScore(object sender, int cleanedLines)
    {
        _currentScore += _lineCleanReward * cleanedLines;
        OnScoreChanged?.Invoke(this, _currentScore);
    }
}
