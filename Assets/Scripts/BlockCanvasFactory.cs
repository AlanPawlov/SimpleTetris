using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BlockCanvasFactory : IBlockFactory
{
    private DiContainer _diContainer;
    private Image _blockPrefab;
    private string _blockPath;

    public BlockCanvasFactory(DiContainer container, GameplayConfig config)
    {
        _diContainer = container;
        _blockPath = config.BlockPrefabPath;
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
