using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup;

    private GameplayConfig _gameplayConfig;
    private List<FigureModel> _figures;
    private InputHandler _inputHandler;
    private FallFigureController _fallFigureController;
    private GameLogicController _gameLogicController;
    private GameFieldViewUpdater _gameFieldViewUpdater;
    private TimeTicker _timeTicker;

    [Inject]
    public void Construct(GameplayConfig config, List<FigureModel> figures, InputHandler inputHandler)
    {
        _gameplayConfig = config;
        _figures = figures;
        _inputHandler = inputHandler;
    }

    public override void InstallBindings()
    {
        BindTimeTicker();
        BindBlockFactory();
        BindFallFigureController();
        BindGameLogicController();
        BindGameFieldUpdater();
        BindScoreCounter();
    }

    private void BindScoreCounter()
    {
        var scoreCounter = new ScoreCounter(_gameLogicController, _gameplayConfig.LineCleanReward);
        Container.
            Bind<ScoreCounter>().
            FromInstance(scoreCounter).
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
        _timeTicker = new TimeTicker();
        Container.
            Bind<TimeTicker>()
            .FromInstance(_timeTicker)
            .AsSingle()
            .NonLazy();
        _timeTicker.StartWork();
    }

    private void BindFallFigureController()
    {
        _fallFigureController = new FallFigureController(_timeTicker, _gameplayConfig);
        Container.
            Bind<FallFigureController>()
            .FromInstance(_fallFigureController)
            .AsSingle()
            .NonLazy();
    }

    private void BindGameLogicController()
    {
        _gameLogicController = new GameLogicController(_inputHandler, _fallFigureController, _gameplayConfig, _figures);
        Container.
            Bind<GameLogicController>()
            .FromInstance(_gameLogicController)
            .AsSingle()
            .NonLazy();
    }

    private void BindGameFieldUpdater()
    {
        _gameFieldViewUpdater = new GameFieldViewUpdater(_gridLayoutGroup, _gameLogicController, _gameplayConfig);
        Container.Bind<GameFieldViewUpdater>()
            .FromInstance(_gameFieldViewUpdater)
            .AsSingle()
            .NonLazy();
    }
}
