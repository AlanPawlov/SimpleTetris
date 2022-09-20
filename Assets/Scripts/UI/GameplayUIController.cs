using System;
using System.Threading.Tasks;
using UnityEngine;

public class GameplayUIController
{
    private ResourcesManager _resourcesManager;
    private GameLogicController _gameLogicController;
    private ScoreCounter _scoreCounter;
    private Canvas _mainCanvas;

    public GameplayUIController(ResourcesManager resourcesManager, GameLogicController gameLogicController, ScoreCounter scoreCounter, Canvas mainCanvas)
    {
        _gameLogicController = gameLogicController;
        _resourcesManager = resourcesManager;
        _mainCanvas = mainCanvas;
        _scoreCounter = scoreCounter;
        CreateGameplayWindowAsync();
        _gameLogicController.OnFieldFilled += OnLoseGame;
    }

    private async Task CreateGameplayWindowAsync()
    {
        var gameplayUI = await LoadWindow<GameplayWindow>(Constants.ResourcesMap.GameplayWindow);
        gameplayUI.SetData(_scoreCounter);
    }

    private void OnLoseGame(object sender, EventArgs e)
    {
        CreateLoseWindowAsync();
    }

    private async Task CreateLoseWindowAsync()
    {
        var gameplayUI = await LoadWindow<LoseGameWindow>(Constants.ResourcesMap.LoseWindow);
        gameplayUI.SetData(_scoreCounter.CurrentScore);
    }

    private async Task<T> LoadWindow<T>(string path) where T : BaseWindow
    {
        var window = await _resourcesManager.LoadAsset<T>(path);
        //window.SetResourcesManager(_resourcesManager);
        window.transform.SetParent(_mainCanvas.transform, false);
        return window;
    }
}
