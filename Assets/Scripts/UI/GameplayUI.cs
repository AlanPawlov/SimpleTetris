using UnityEngine;
using TMPro;
using Zenject;
using UnityEngine.UI;
using System;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private TMP_Text _scoreCounterText;
    private ScoreCounter _scoreCounter;
    private WindowsController _windowsController;
    private GameLogicController _gameLogicController;

    [Inject]
    public void Construct(GameLogicController gameLogicController, WindowsController windowsController,
        ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
        _windowsController = windowsController;
        _gameLogicController = gameLogicController;
        _scoreCounter.OnScoreChanged += OnScoreChanged;
        _gameLogicController.OnFieldFilled += OnFileldFilled;
        _pauseButton.onClick.AddListener(OnPauseClick);
    }

    private void OnFileldFilled(object sender, EventArgs e)
    {
        _windowsController.ShowWindow(TypeWindow.LoseWindow);
    }

    private void OnScoreChanged(object sender, int score)
    {
        _scoreCounterText.text = $"Score: {score}";
    }

    private void OnPauseClick()
    {
        _windowsController.ShowWindow(TypeWindow.PauseWindow);
    }

    private void OnDestroy()
    {
        _gameLogicController.OnFieldFilled -= OnFileldFilled;
        _scoreCounter.OnScoreChanged -= OnScoreChanged;
    }
}
