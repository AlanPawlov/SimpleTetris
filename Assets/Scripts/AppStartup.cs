using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    private void LoadConfigs()
    {
        _gameplayConfig = ConfigLoader.Load<GameplayConfig>();
        _figures = ConfigLoader.LoadList<FigureModel>();
    }

    private void LoadProgress()
    {
        // Грузим сейвы
    }

    private void BindInputHandler()
    {
        var inputHandler = new InputHandler();
        Container.
            Bind<InputHandler>().
            FromInstance(inputHandler).
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
}
