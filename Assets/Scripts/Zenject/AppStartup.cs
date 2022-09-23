using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Zenject;

public class AppStartup : MonoInstaller
{
    private GameplayConfig _gameplayConfig;
    private List<FigureModel> _figures;

    public override void InstallBindings()
    {
        LoadConfigs();
        LoadProgress();

        BindInputHandler();
        BindGamePlayConfig();
        BindFiguresList();
        BindWindowsManager();

        BindSceneLoader();
    }

    private void LoadConfigs()
    {
        _gameplayConfig = ConfigLoader.Load<GameplayConfig>();
        _figures = ConfigLoader.LoadList<FigureModel>();
    }

    private void LoadProgress()
    {
        // TODO: подкрутить загрузку сейвов
    }

    private void BindInputHandler()
    {
        Container.
            Bind<InputHandler>().
            FromNew().
            AsSingle();
    }

    private void BindGamePlayConfig()
    {
        Container.
            Bind<GameplayConfig>().
            FromInstance(_gameplayConfig).
            AsSingle();
    }

    private void BindFiguresList()
    {
        Container.
            Bind<List<FigureModel>>().
            FromInstance(_figures).
            AsSingle();
    }

    private void BindWindowsManager()
    {
        Container.
            Bind<WindowsController>().
            FromNew().
            AsSingle().
            NonLazy();
    }

    private void BindSceneLoader()
    {
        var sceneLoader = new SceneLoader();

        Container.
            Bind<SceneLoader>().
            FromInstance(sceneLoader).
            AsSingle().
            NonLazy();

        var targetScene = Constants.Scenes.MainMenuScene;
        sceneLoader.LoadScene(targetScene);
    }
}
