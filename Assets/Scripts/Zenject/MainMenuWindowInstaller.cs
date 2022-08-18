using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class MainMenuWindowInstaller : MonoInstaller
{
    [SerializeField]
    private Transform _mainCanvas;
    private ResourcesManager _resourcesManager;

    [Inject]
    public void Construct(ResourcesManager resourcesManager)
    {
        _resourcesManager = resourcesManager;
    }

    public override void InstallBindings()
    {
        BindMainMenuWindow();
    }

    private async void BindMainMenuWindow()
    {
        var menuWindow = await LoadMainMenuWindowAsync();
        Container.
            Bind<MainMenuWindow>().
            FromInstance(menuWindow).
            AsSingle();
    }

    private async Task<MainMenuWindow> LoadMainMenuWindowAsync()
    {
        var menuWindow = await _resourcesManager.LoadAsset<MainMenuWindow>(Constants.ResourcesMap.MainMenuWindow);
        menuWindow.SetResourcesManager(_resourcesManager);
        menuWindow.transform.SetParent(_mainCanvas.transform, false);
        return menuWindow;
    }
}
