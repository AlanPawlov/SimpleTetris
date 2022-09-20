using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : BaseWindow
{
    [SerializeField]
    private RectTransform _playButtonPivot;
    private ButtonWidget _playButton;

    public override void Init()
    {
        base.Init();
        Setup();
    }

    public async Task Setup()
    {
        _playButton = await CreateChild<ButtonWidget>(Constants.ResourcesMap.DefaultButton, _playButtonPivot);
        _playButton.SetData("play", Constants.ColorCodes.ColorWhite, OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        Uninit();
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
