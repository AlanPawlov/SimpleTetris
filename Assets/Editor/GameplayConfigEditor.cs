using Sirenix.OdinInspector;


[HideReferenceObjectPicker]
public class GameplayConfigEditor : BaseModelEditor<GameplayConfig>
{
    public GameplayConfigEditor(GameplayConfig config)
    {
        _model = config;
        if (_model == null)
        {
            _model = new GameplayConfig();
        }
    }

    [ShowInInspector]
    [LabelText("Game field widght")]
    [LabelWidth(120)]
    public int GridWidght
    {
        get => _model.GridWidght;
        set => _model.GridWidght = value;
    }

    [ShowInInspector]
    [LabelText("Game field height")]
    [LabelWidth(120)]
    public int GridHeight
    {
        get => _model.GridHeight;
        set => _model.GridHeight = value;
    }

    [ShowInInspector]
    [LabelText("Line clean reward")]
    [LabelWidth(120)]
    public int LineCleanReward
    {
        get => _model.LineCleanReward;
        set => _model.LineCleanReward = value;
    }

    [ShowInInspector]
    [LabelText("Start speed")]
    [LabelWidth(120)]
    public float StartFiguresSpeedMultiplier
    {
        get => _model.StartFallSpeedMultiplier;
        set => _model.StartFallSpeedMultiplier = value;
    }

    [ShowInInspector]
    [LabelText("Speed multiplier on clean line")]
    [LabelWidth(120)]
    public float SpeedMultiplierOnCleanLine
    {
        get => _model.SpeedMultiplierOnCleanLine;
        set => _model.SpeedMultiplierOnCleanLine = value;
    }

    [ShowInInspector]
    [LabelText("Block Prefab Path")]
    [LabelWidth(120)]
    public string BlockPrefabPath       // TODO: переделать на перетаскивание префаба в окно
    {
        get => _model.BlockPrefabPath;
        set => _model.BlockPrefabPath = value;
    }
}
