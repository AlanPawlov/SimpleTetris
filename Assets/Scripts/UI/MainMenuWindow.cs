using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;
    private WindowsController _windowsManager;
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(WindowsController windowsManager, SceneLoader sceneLoader)
    {
        _windowsManager = windowsManager;
        _sceneLoader = sceneLoader;
        _playButton.onClick.AddListener(PlayButtonClick);
    }

    private void PlayButtonClick()
    {
        var targetScene = Constants.Scenes.GameplayScene;
        _sceneLoader.LoadScene(targetScene);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveAllListeners();
    }
}
