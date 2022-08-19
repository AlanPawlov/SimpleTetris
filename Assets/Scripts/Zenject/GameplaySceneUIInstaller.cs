using UnityEngine;
using Zenject;

public class GameplaySceneUIInstaller : MonoInstaller
{
    [SerializeField]
    private Canvas _mainCanvas;

    public override void InstallBindings()
    {
        BindMainCanvas();
        BindGameplayUIController();
    }

    private void BindMainCanvas()
    {
        Container.
            Bind<Canvas>().
            FromInstance(_mainCanvas).
            AsSingle();
    }

    private void BindGameplayUIController()
    {
        Container.
            Bind<GameplayUIController>().
            AsSingle().
            NonLazy();
    }
}
