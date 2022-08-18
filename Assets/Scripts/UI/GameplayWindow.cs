using System.Threading.Tasks;
using UnityEngine;

public class GameplayWindow : BaseWindow
{
    [SerializeField]
    private RectTransform _pauseButtonPivot;
    [SerializeField]
    private RectTransform _scoreCounterPivot;
    private ButtonWidget _pauseButtonWidget;
    private LabelWidget _scoreCounterWidget;
    private ScoreCounter _scoreCounter;

    public void SetData(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
        _scoreCounter.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(object sender, int score)
    {
        _scoreCounterWidget.Text.text = $"score: {score}";
    }

    public async override void Init()
    {
        base.Init();
        await CreateChilds();
    }

    public override void Uninit()
    {
        _scoreCounter.OnScoreChanged -= OnScoreChanged;
        base.Uninit();
    }

    private async Task CreateChilds()
    {
        _pauseButtonWidget = await CreateChild<ButtonWidget>(Constants.ResourcesMap.PauseButton, _pauseButtonPivot);
        _pauseButtonWidget.SetData(color: Constants.ColorCodes.ColorWhite, onClick: OnPauseClick);
        _scoreCounterWidget = await CreateChild<LabelWidget>(Constants.ResourcesMap.DefaultLabelWithBackGround, _scoreCounterPivot);
        _scoreCounterWidget.SetData($"score: {0}");
    }

    private void OnPauseClick()
    {
        CreateWindow<PauseWindow>(Constants.ResourcesMap.PauseWindow);
    }
}
