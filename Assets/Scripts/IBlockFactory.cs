using UnityEngine;

public interface IBlockFactory
{
    void Load();
    T Create<T>(Vector3 position = default, Transform parent = null);
}