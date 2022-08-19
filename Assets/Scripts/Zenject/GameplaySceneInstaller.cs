using System.Collections.Generic;
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
        BindTimeTicker();
        BindBlockFactory();
        BindFallFigureController();
        BindGameLogicController();
        BindGameFieldUpdater();
        BindScoreCounter();
    }

    private void BindBlockFactory()
    {
        Container.
            Bind<IBlockFactory>().
            To<BlockCanvasFactory>().
            AsSingle().
            NonLazy();
    }

    private void BindTimeTicker()
    {
        Container.
            Bind<TimeTicker>().
            FromNew().
            AsSingle();
    }

    private void BindFallFigureController()
    {
        Container.
            Bind<FallFigureController>().
            FromNew().
            AsSingle();
    }

    private void BindGameLogicController()
    {
        Container.
            Bind<GameLogicController>().
            FromNew().
            AsSingle();
    }

    private void BindGridLayoutGroup()
    {
        Container.Bind<GridLayoutGroup>().
            FromInstance(_gridLayoutGroup).
            AsSingle().
            NonLazy();
    }

    private void BindGameFieldUpdater()
    {
        Container.
            Bind<GameFieldViewUpdater>().
            FromNew().
            AsSingle().
            NonLazy();
    }

    private void BindScoreCounter()
    {
        Container.
        Bind<ScoreCounter>().
        FromNew().
        AsSingle();
    }
}
