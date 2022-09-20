using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class MainMenuWindowInstaller : MonoInstaller
{
    private UIManager _uIManager;

    [Inject]
    public void Construct(UIManager uIManager)
    {
        _uIManager = uIManager;
    }

    public override void InstallBindings()
    {
        BindMainMenuWindow();
    }

    private async void BindMainMenuWindow()
    {
        var menuWindow = await _uIManager.CreateWindow<MainMenuWindow>(Constants.ResourcesMap.MainMenuWindow);
        Container.
            Bind<MainMenuWindow>().
            FromInstance(menuWindow).
            AsSingle();
    }
}
