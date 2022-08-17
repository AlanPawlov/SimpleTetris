using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;

    public override void InstallBindings()
    {
        BindTimeTicker();
        BindFallFigureController();
        BindGameController();
        BindGridLayoutGroup();
        BindGameFieldGenerator();
    }
    private void BindTimeTicker()
    {
        var timeTicker = new TimeTicker();
        Container.
            Bind<TimeTicker>()
            .FromInstance(timeTicker)
            .AsSingle()
            .NonLazy();
        timeTicker.StartWork();
    }

    private void BindFallFigureController()
    {
        Container.
            Bind<FallFigureController>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindGameController()
    {
        Container.
            Bind<GameLogicController>()
            .FromNew()
            .AsSingle()
            .NonLazy();
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
        Container.Bind<GameFieldViewUpdater>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}
