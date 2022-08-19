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

        BindResourcesManager();
        BindInputHandler();
        BindGamePlayConfig();
        BindFiguresList();
        SceneManager.LoadScene(1, LoadSceneMode.Single); // TODO: Не добавить контроллер сцен
    }

    private void BindResourcesManager()
    {
        Container.
            Bind<ResourcesManager>().
            FromNew().
            AsSingle().
            NonLazy();
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
}
