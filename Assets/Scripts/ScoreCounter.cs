using System;
using Zenject;

public class ScoreCounter
{
    public event EventHandler<int> OnScoreChanged;
    private int _lineCleanReward;
    private int _currentScore;

    [Inject]
    public void Construct(GameLogicController gameLogicController, GameplayConfig config) // TODO: подумать как реализовать через человеческий конструктор
    {
        gameLogicController.OnLineCleaned += OnChangeScore;
        _lineCleanReward = config.LineCleanReward;
    }

    private void OnChangeScore(object sender, int cleanedLines)
    {
        _currentScore += _lineCleanReward * cleanedLines;
        OnScoreChanged?.Invoke(this, _currentScore);
    }
}
