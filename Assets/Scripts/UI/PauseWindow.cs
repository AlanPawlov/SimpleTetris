using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : BaseWindow
{
    [SerializeField]
    private RectTransform _continueButtonPivot;
    [SerializeField]
    private RectTransform _toMenuButtonPivot;
    private ButtonWidget _continueButton;
    private ButtonWidget _toMenuButton;

    public async override void Init()
    {
        base.Init();
        await CreateChilds();
        Time.timeScale = 0;             //TODO: сделать отдельный перключатель паузы, который по событиям будет сообщать о паузе нуждающимся
    }

    public override void Uninit()
    {
        base.Uninit();
        Time.timeScale = 1;
    }

    private async Task CreateChilds()
    {
        _continueButton = await CreateChild<ButtonWidget>(Constants.ResourcesMap.DefaultButton, _continueButtonPivot);
        _continueButton.SetData("continue", Constants.ColorCodes.ColorWhite, OnContinueButtonClick);
        _toMenuButton = await CreateChild<ButtonWidget>(Constants.ResourcesMap.DefaultButton, _toMenuButtonPivot);
        _toMenuButton.SetData("quit", Constants.ColorCodes.ColorWhite, OnToMenuButtonClick);
    }

    private void OnContinueButtonClick()
    {

        Uninit();
    }

    private void OnToMenuButtonClick()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single); // TODO: Не добавить контроллер сцен
    }
}
