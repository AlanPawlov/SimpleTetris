using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoseWindow : BaseWindow
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _toMenuButton;

    [Inject]
    public void Construct(WindowsController windowsController, SceneLoader sceneLoader)
    {
        _sceneloader = sceneLoader;
        _windowsController = windowsController;
        _sceneloader.OnSceneChanged += OnSceneChanged;
        _windowsController.RegisеrWindow(this);
        _restartButton.onClick.AddListener(OnRestartClick);
        _toMenuButton.onClick.AddListener(ToMenuClick);
    }

    private void OnRestartClick()
    {
        var targetScene = Constants.Scenes.GameplayScene;
        _sceneloader.LoadScene(targetScene);
    }

    private void ToMenuClick()
    {
        var targetScene = Constants.Scenes.MainMenuScene;
        _sceneloader.LoadScene(targetScene);
    }
    private void OnSceneChanged(object sender, EventArgs e)
    {
        Unregister();
    }

    protected override void Unregister()
    {
        base.Unregister();
        _sceneloader.OnSceneChanged -= OnSceneChanged;
        _restartButton.onClick.RemoveAllListeners();
        _toMenuButton.onClick.RemoveAllListeners();
    }
}
