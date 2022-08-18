using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameplaySceneUIInstaller : MonoInstaller
{
    [SerializeField]
    private Transform _mainCanvas;
    private ResourcesManager _resourcesManager;
    private ScoreCounter _scoreCounter;

    [Inject]
    public void Construct(ResourcesManager resourcesManager, ScoreCounter scoreCounter)
    {
        _resourcesManager = resourcesManager;
        _scoreCounter = scoreCounter;
    }

    public override void InstallBindings()
    {
        BindGameplayUIWindows();
    }

    private async Task BindGameplayUIWindows()
    {
        var menuWindow = await LoadMainMenuWindowAsync();
        Container.
            Bind<GameplayWindow>().
            FromInstance(menuWindow).
            AsSingle();
    }

    private async Task<GameplayWindow> LoadMainMenuWindowAsync()
    {
        var gameplayUI = await _resourcesManager.LoadAsset<GameplayWindow>(Constants.ResourcesMap.GameplayWindow);
        gameplayUI.SetResourcesManager(_resourcesManager);
        gameplayUI.SetData(_scoreCounter);
        gameplayUI.transform.SetParent(_mainCanvas.transform, false);
        return gameplayUI;
    }
}
