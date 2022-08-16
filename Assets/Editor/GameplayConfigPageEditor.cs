using Sirenix.OdinInspector;

public class GameplayConfigPageEditor
{
    private bool DataExist { get; set; }

    [Button("Load Data")]
    [HorizontalGroup("1", width: 120)]
    [PropertyOrder(0)]
    public void Init()
    {
        var model = ConfigLoader.Load<GameplayConfig>();
        Constant = new GameplayConfigEditor(model);
        DataExist = true;
    }

    [Button("Save Data"), ShowIf(nameof(DataExist))]
    [HorizontalGroup("1", width: 120)]
    [PropertyOrder(1)]
    public void Save()
    {
        ConfigLoader.Save(Constant.GetModel());
    }

    [ShowInInspector]
    [ShowIf(nameof(DataExist))]
    [LabelText("Constant")]
    [PropertyOrder(2)]
    public GameplayConfigEditor Constant;
}
