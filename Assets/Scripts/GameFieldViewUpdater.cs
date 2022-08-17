﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameFieldViewUpdater // TODO: Возможно таки надо разбить на отдельные генератор и апдейтер
{
    private int _gridWidght;
    private int _gridHeight;
    private Image _prefabBlock;
    private Image[,] _blocks;
    private GridLayoutGroup _gridLayoutGroup;

    [Inject]
    public void Construct(GridLayoutGroup gridLayoutGroup, GameplayConfig config, GameLogicController gameController) // TODO: подумать как реализовать через человеческий конструктор
    {
        _gridHeight = config.GridHeight;
        _gridWidght = config.GridWidght;
        _gridLayoutGroup = gridLayoutGroup;
        LoadBlockPrefab(config.BlockPrefabPath);
        GenerateGrid(_gridWidght, _gridHeight);
        gameController.OnBlockStateUpdate += OnBlockUpdateState;
    }

    private void OnBlockUpdateState(object sender, BlockUpdateArgs e)
    {
        switch (e.BlockState)
        {
            case BlockState.Invisible:
                _blocks[e.X, e.Y].color = Color.clear;
                break;
            case BlockState.Falling:
                _blocks[e.X, e.Y].color = Color.red;
                break;
            case BlockState.OnGround:
                _blocks[e.X, e.Y].color = Color.gray;
                break;
        }
    }

    private Image LoadBlockPrefab(string prefabPath) // TODO: Перевести на бандлы
    {
        _prefabBlock = Resources.Load<Image>(prefabPath);
        return _prefabBlock;
    }

    public Image[,] GenerateGrid(int gridWidght, int gridHeight)
    {
        _gridWidght = gridWidght;
        _gridHeight = gridHeight;
        _blocks = new Image[_gridWidght, _gridHeight];
        _gridLayoutGroup.constraintCount = _gridWidght;
        var rect = _gridLayoutGroup.GetComponent<RectTransform>();
        var cellSize = rect.rect.height / _gridHeight;
        rect.sizeDelta = new Vector2(cellSize * _gridWidght, rect.sizeDelta.y);
        _gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
        for (int x = 0; x < _gridWidght; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                _blocks[x, y] = GameObject.Instantiate(_prefabBlock, _gridLayoutGroup.transform);
            }
        }
        return _blocks;
    }
}