using System.Collections.Generic;
using System;
using Zenject;


public class GameLogicController
{
    private int _gridWidht;
    private int _gridHeight;
    private int[,] _grid; // 0 - пустая ячейка, 1 - ячейка падает, 2 - ячейка на земле

    private int _xFigurePosition;
    private int _yFigurePosition;
    private int _figureSize;

    private List<FigureModel> _figures;
    public event EventHandler<BlockUpdateArgs> OnBlockStateUpdate;
    public event EventHandler<int> OnLineCleaned;

    [Inject]
    public void Construct(InputHandler inputHandler, FallFigureController fallFigureController, GameplayConfig config, List<FigureModel> figures) // TODO: подумать как реализовать через человеческий конструктор
    {
        _figures = figures;
        _gridWidht = config.GridWidght;
        _gridHeight = config.GridHeight;
        _grid = new int[_gridWidht, _gridHeight];
        inputHandler.OnInputEnter += OnInputEntered;
        fallFigureController.OnTimeUpdate += OnTimeUpdate;
        AddFigure();
    }

    private void OnTimeUpdate(object sender, EventArgs e)
    {
        MoveDown();
    }

    private void OnInputEntered(object sender, InputActionType actionType)
    {
        switch (actionType)
        {
            case InputActionType.MoveLeft:
                MoveHorizontal(-1);
                break;
            case InputActionType.MoveRight:
                MoveHorizontal(1);
                break;
            case InputActionType.MoveDown:
                MoveDown();
                break;
            case InputActionType.Rotate:
                Rotate();
                break;
        }
    }

    private void UpdateGrid()
    {
        for (int x = 0; x < _gridWidht; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                if (_grid[x, y] > 0)
                {
                    if (_grid[x, y] == 2)
                    {
                        OnBlockStateUpdate?.Invoke(this, new BlockUpdateArgs(x, y, BlockState.OnGround));
                    }
                    if (_grid[x, y] == 1)
                    {
                        OnBlockStateUpdate?.Invoke(this, new BlockUpdateArgs(x, y, BlockState.Falling));
                    }
                }
                else
                {
                    OnBlockStateUpdate?.Invoke(this, new BlockUpdateArgs(x, y, BlockState.Invisible));
                }
            }
        }
    }

    private void Replace()
    {
        for (int x = 0; x < _gridWidht; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                if (_grid[x, y] == 1)
                {
                    _grid[x, y] = 2;
                }
                else
                {
                    _grid[x, y] = _grid[x, y];
                }
            }
        }
        Clean();
        UpdateGrid();
    }

    private void MoveHorizontal(int direction)
    {
        int[,] tmpGrid = new int[_gridWidht, _gridHeight];
        for (int x = 0; x < _gridWidht; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                if (!CanHorizontalMove(direction, x, y))
                {
                    return;
                }

                if (_grid[x, y] == 1)
                {
                    tmpGrid[x + direction, y] = 1;
                }

                if (_grid[x, y] == 2)
                {
                    tmpGrid[x, y] = _grid[x, y];
                }
            }
        }

        _xFigurePosition += direction;
        _grid = tmpGrid;
        UpdateGrid();
    }

    private bool CanHorizontalMove(int direction, int x, int y)
    {
        if (direction > 0)
        {
            if (x == _gridWidht - 2 && _grid[x + 1, y] == 1)
            {
                return false;
            }

            if (_grid[x, y] == 1 && _grid[x + 1, y] == 2)
            {
                return false;
            }
            return true;
        }
        else
        {
            if (x == 1 && _grid[x - 1, y] == 1)
            {
                return false;
            }

            if (_grid[x, y] == 1 && (x - 1 < 0 || _grid[x - 1, y] == 2))
            {
                return false;
            }
            return true;
        }
    }

    private void MoveDown()
    {
        int[,] tmpGrid = new int[_gridWidht, _gridHeight];
        for (int y = 15; y >= 0; y--)
        {
            for (int x = 0; x < _gridWidht; x++)
            {
                if (y > 0)
                {
                    if (_grid[x, y] == 1 && _grid[x, y - 1] == 2)
                    {
                        Replace();
                        return;
                    }
                }

                if (y == 0 && _grid[x, y] == 1)
                {
                    Replace();
                    return;
                }

                if (y > 0)
                {
                    if (_grid[x, y] == 1)
                    {
                        tmpGrid[x, y - 1] = 1;
                    }
                }

                if (_grid[x, y] == 2)
                {
                    tmpGrid[x, y] = 2;
                }
            }
        }
        _yFigurePosition--;
        _grid = tmpGrid;
        UpdateGrid();
    }

    private void Rotate()
    {
        int[,] tmpFigure = new int[_figureSize, _figureSize];
        for (int x = _xFigurePosition; x < _xFigurePosition + _figureSize; x++)
        {
            for (int y = _yFigurePosition; y > _yFigurePosition - _figureSize; y--)
            {
                if (x == _gridWidht || x < 0)
                {
                    return;
                }
                tmpFigure[x - _xFigurePosition, _yFigurePosition - y] = _grid[x, y];
                if (_grid[x, y] == 2)
                {
                    return;
                }
            }
        }

        for (int x = 0; x < _figureSize; x++)
        {
            for (int y = 0; y < _figureSize; y++)
            {
                _grid[_xFigurePosition + x, _yFigurePosition - y] = tmpFigure[y, (_figureSize - 1) - x];
            }
        }
        UpdateGrid();
    }

    private void CleanLine(int line)
    {
        for (int x = 0; x < _gridWidht; x++)
        {
            _grid[x, line] = 0;
        }
    }

    private void Clean()
    {
        int cleanedLines = 0;
        for (int y = 15; y >= 0; y--)
        {
            int sumCellValues = 0;
            for (int x = 0; x < _gridWidht; x++)
            {
                sumCellValues = sumCellValues + _grid[x, y];
                if (sumCellValues == _gridWidht * 2)
                {
                    CleanLine(y);
                    cleanedLines++;
                }
            }
        }

        if (cleanedLines > 0)
        {
            OnLineCleaned?.Invoke(this, cleanedLines);
        }

        MoveCleanedBlocks(cleanedLines);
        AddFigure();
        UpdateGrid();
    }

    private void MoveCleanedBlocks(int cleanedLines)
    {
        for (int i = 0; i < cleanedLines; i++)
        {
            for (int x = 0; x < _gridWidht; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    if (_grid[x, y] == 0 && _grid[x, y + 1] == 2)
                    {
                        _grid[x, y] = 2;
                        _grid[x, y + 1] = 0;
                    }
                }
            }
        }
    }

    private void AddFigure()
    {
        _xFigurePosition = _gridWidht / 2 - 1;
        _yFigurePosition = _gridHeight - 1;
        var currentFigureIndex = UnityEngine.Random.Range(0, _figures.Count);
        _figureSize = _figures[currentFigureIndex].FigureSize;

        for (int x = 0; x < _figureSize; x++)
        {
            for (int y = 0; y < _figureSize; y++)
            {
                _grid[x + _xFigurePosition, _yFigurePosition - y] = _figures[currentFigureIndex].FigureGrid[x, y];
            }
        }
    }
}
