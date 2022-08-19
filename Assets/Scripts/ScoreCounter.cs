using System;

public class ScoreCounter
{
    public event EventHandler<int> OnScoreChanged;
    private int _lineCleanReward;
    private int _currentScore;
    private GameLogicController _gameLogicController;
    public int CurrentScore => _currentScore;

    ~ScoreCounter()
    {
        _gameLogicController.OnLineCleaned -= OnChangeScore;
    }

    public ScoreCounter(GameLogicController gameLogicController, GameplayConfig config)
    {
        _gameLogicController = gameLogicController;
        _gameLogicController.OnLineCleaned += OnChangeScore;
        _lineCleanReward = config.LineCleanReward;
    }

    private void OnChangeScore(object sender, int cleanedLines)
    {
        _currentScore += _lineCleanReward * cleanedLines;
        OnScoreChanged?.Invoke(this, _currentScore);
    }
}
