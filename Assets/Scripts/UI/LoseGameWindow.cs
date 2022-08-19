using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGameWindow : BaseWindow
{
    [SerializeField]
    private RectTransform _quitButtonPivot;
    [SerializeField]
    private RectTransform _scoreCounterPivot;
    private LabelWidget _scoreCounterWidget;
    private ButtonWidget _quitButton;
    private int _score;

    public async override void Init()
    {
        base.Init();
        await CreateChilds();
    }

    public void SetData(int score)
    {
        _score = score;
    }

    private async Task CreateChilds()
    {
        _quitButton = await CreateChild<ButtonWidget>(Constants.ResourcesMap.DefaultButton, _quitButtonPivot);
        _quitButton.SetData("quit", Constants.ColorCodes.ColorWhite, OnQuitButtonClick);
        _scoreCounterWidget = await CreateChild<LabelWidget>(Constants.ResourcesMap.DefaultLabelWithBackGround, _scoreCounterPivot);
        _scoreCounterWidget.Text.text = $"you score: {_score}";
    }

    private void OnQuitButtonClick()
    {
        Uninit();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
