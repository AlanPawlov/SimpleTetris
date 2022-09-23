using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class PauseWindow : BaseWindow
{
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _toMenuButton;

    [Inject]
    public void Construct(WindowsController windowsController, SceneLoader sceneLoader)
    {
        _sceneloader = sceneLoader;
        _windowsController = windowsController;
        _windowsController.Regis�rWindow(this);
        _sceneloader.OnSceneChanged += OnSceneChanged;
        _restartButton.onClick.AddListener(OnRestartClick);
        _toMenuButton.onClick.AddListener(ToMenuClick);
        _resumeButton.onClick.AddListener(Resume);
    }

    public override void Show()
    {
        base.Show();
        Time.timeScale = 0; //TODO: ��������� �������, ����� ���������� (������ �������� �����, � �������� � ��������� ����������� �� ����� ��������� ����������� �� � ���������)
    }

    private void Resume()
    {
        Time.timeScale = 1; //TODO: ��������� �������, ����� ����������
        _windowsController.HideWindow(this);
    }

    private void OnRestartClick()// TODO: ����� ������� ����� ���� �������� ���� � �������� �����
    {
        Time.timeScale = 1; //TODO: ��������� �������, ����� ����������
        var targetScene = Constants.Scenes.GameplayScene;
        _sceneloader.LoadScene(targetScene);
    }

    private void ToMenuClick()
    {
        Time.timeScale = 1; //TODO: ��������� �������, ����� ����������
        var targetScene = Constants.Scenes.MainMenuScene;
        _sceneloader.LoadScene(targetScene);
    }

    private void OnSceneChanged(object sender, EventArgs e)
    {
        Unregister();
    }
    protected override void Unregister()
    {
        base.Unregister();
        _sceneloader.OnSceneChanged -= OnSceneChanged;
        _resumeButton.onClick.RemoveAllListeners();
        _restartButton.onClick.RemoveAllListeners();
        _toMenuButton.onClick.RemoveAllListeners();
    }
}
