using Sirenix.OdinInspector;

[HideReferenceObjectPicker]
public class FigureEditor : BaseModelEditor<FigureModel>
{
    public FigureEditor(FigureModel figure)
    {
        if (figure == null)
        {
            figure = new FigureModel();
        }
        _model = figure;
    }

    [ShowInInspector]
    [HorizontalGroup("1")]
    [LabelText("Id")]
    [LabelWidth(50)]
    public string Id
    {
        get => _model.Id;
        set => _model.Id = value;
    }

    [ShowInInspector]
    [HorizontalGroup("1")]
    [LabelText("Size")]
    [LabelWidth(50)]
    public int FigureSize
    {
        get
        {
            if (_model.FigureSize == 0)
            {
                _model.FigureSize = 1;
                _model.FigureGrid = new int[FigureSize, FigureSize];
            }
            return _model.FigureSize;
        }
        set
        {
            _model.FigureSize = value;
            _model.FigureGrid = new int[FigureSize, FigureSize];
        }

    }

    [ShowInInspector]
    [PropertySpace(SpaceAfter = 30, SpaceBefore = 20)]
    [InfoBox("Figure Grid \n0 - empty, 1 - block")]
    [LabelWidth(50)]
    public int[,] FigureGrid
    {
        get
        {
            if (_model.FigureGrid == null || _model.FigureGrid.Length == 0)
            {
                _model.FigureGrid = new int[FigureSize, FigureSize];
            }
            return _model.FigureGrid;
        }
        set
        {
            for (int x = 0; x < value.GetLength(0); x++)
            {
                for (int y = 0; y < value.GetLength(1); y++)
                {
                    value[x, y] = value[x, y] >= 1 ? 1 : 0;
                }
            }
            _model.FigureGrid = value;
        }
    }


}
