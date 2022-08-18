using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BlockCanvasFactory : IBlockFactory
{
    private DiContainer _diContainer;
    private Image _blockPrefab;
    private string _blockPath;

    public BlockCanvasFactory(DiContainer container, string blockPath)
    {
        _diContainer = container;
        _blockPath = blockPath;
    }

    public void Load()
    {
        _blockPrefab = Resources.Load<Image>(_blockPath);
    }

    public T Create<T>(Vector3 spawnPosition = default, Transform parent = null)
    {
        var block = _diContainer.InstantiatePrefabForComponent<T>(_blockPrefab, spawnPosition, Quaternion.identity, parent);
        return block;
    }
}
