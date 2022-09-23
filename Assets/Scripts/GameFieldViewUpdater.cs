using UnityEngine;
using UnityEngine.UI;

public class GameFieldViewUpdater
{
    private Image[,] _blocks;
    private GridLayoutGroup _gridLayoutGroup;
    private GameLogicController _gameLogicController;
    private IBlockFactory _blockFactory;

    public GameFieldViewUpdater(GridLayoutGroup gridLayoutGroup, GameLogicController gameController,
        GameplayConfig config, IBlockFactory blockFactory)
    {
        _gridLayoutGroup = gridLayoutGroup;
        _blockFactory = blockFactory;
        GenerateGrid(config.GridWidght, config.GridHeight);
        _gameLogicController = gameController;
        _gameLogicController.OnBlockStateUpdate += OnBlockUpdateState;

    }

    ~GameFieldViewUpdater()
    {
        _gameLogicController.OnBlockStateUpdate -= OnBlockUpdateState;
    }

    private void OnBlockUpdateState(object sender, BlockUpdateArgs e)
    {
        var block = _blocks[e.X, e.Y];
        if (block == null)
        {
            return;
        }
        switch (e.BlockState)
        {
            case BlockState.Invisible:
                block.color = Constants.ColorCodes.FullAlpha;
                break;
            case BlockState.Falling:
                block.color = Constants.ColorCodes.ColorRed;
                break;
            case BlockState.OnGround:
                block.color = Constants.ColorCodes.ColorWhite;
                break;
        }
    }

    public Image[,] GenerateGrid(int gridWidght, int gridHeight)
    {
        _blocks = new Image[gridWidght, gridHeight];
        _gridLayoutGroup.constraintCount = gridWidght;
        var rect = _gridLayoutGroup.GetComponent<RectTransform>();
        var cellSize = rect.rect.height / gridHeight;
        rect.sizeDelta = new Vector2(cellSize * gridWidght, rect.sizeDelta.y);
        _gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
        _blockFactory.Load();
        for (int x = 0; x < gridWidght; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                _blocks[x, y] = _blockFactory.Create<Image>(parent: _gridLayoutGroup.transform);
            }
        }
        return _blocks;
    }
}
