using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;

    public override void InstallBindings()
    {
        BindGridLayoutGroup();
        BindGameFieldGenerator();
    }

    private void BindGridLayoutGroup()
    {
        Container
            .Bind<GridLayoutGroup>()
            .FromInstance(_gridLayoutGroup)
            .AsSingle();
    }

    private void BindGameFieldGenerator()
    {
        Container.Bind<GameFieldGenerator>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}
