using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;
    private GameplayConfig _gameplayConfig;

    public override void InstallBindings()
    {
        BindTimeTicker();
        BindBlockFactory();
        BindFallFigureController();
        BindGameController();
        BindGridLayoutGroup();
        BindGameFieldUpdater();
        BindScoreCounter();
    }

    private void BindScoreCounter()
    {
        Container.
            Bind<ScoreCounter>().
            FromNew().
            AsSingle();
    }

    private void BindBlockFactory()
    {
        Container.
            Bind<IBlockFactory>().
            To<BlockCanvasFactory>().
            AsSingle();
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

    private void BindGameFieldUpdater()
    {
        Container.Bind<GameFieldViewUpdater>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}
