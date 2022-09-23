using UnityEngine;
using Zenject;

public class GameplaySceneUIInstaller : MonoInstaller
{
    [SerializeField]
    private Canvas _mainCanvas;

    public override void InstallBindings()
    {
        BindMainCanvas();
    }

    private void BindMainCanvas()
    {
        Container.
            Bind<Canvas>().
            FromInstance(_mainCanvas).
            AsSingle();
    }
}
