using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;

public class FiguresPageEditor
{
    private bool DataExist { get; set; }

    [Button("Load Data")]
    [HorizontalGroup("1", width: 120)]
    [PropertyOrder(0)]
    public void Init()
    {
        var models = ConfigLoader.LoadList<FigureModel>();
        if (models == null || models.Count == 0)
        {
            models = new List<FigureModel>() {new FigureModel() };
        }
        Figures = models.Select(f => new FigureEditor(f)).ToList();
        DataExist = true;
    }

    [Button("Save Data"), ShowIf(nameof(DataExist))]
    [HorizontalGroup("1", width: 120)]
    [PropertyOrder(1)]
    public void Save()
    {
        var figureModels = Figures.Select(f => new FigureModel { Id = f.Id, FigureSize = f.FigureSize, FigureGrid = f.FigureGrid }).ToList();
        ConfigLoader.Save(figureModels);
    }

    [ShowInInspector]
    [ListDrawerSettings(HideRemoveButton = false, DraggableItems = false, Expanded = true, AddCopiesLastElement = true)]
    [ShowIf(nameof(DataExist))]
    [HorizontalGroup("2")]
    [LabelText("Figures")]
    [PropertyOrder(2)]
    [Searchable(FilterOptions = SearchFilterOptions.ValueToString)]
    public List<FigureEditor> Figures;
}
