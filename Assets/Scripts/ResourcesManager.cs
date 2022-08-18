using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ResourcesManager
{
    private List<GameObject> _cachedObjects;

    public ResourcesManager()
    {
        _cachedObjects = new List<GameObject>();
    }

    public Task LoadLevel(string levelName)
    {
        var asyncOperationHandle = Addressables.LoadSceneAsync(levelName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        return asyncOperationHandle.Task;
    }

    public async Task<T> LoadAsset<T>(string resourceName)
    {
        var handle = Addressables.InstantiateAsync(resourceName);
        var cachedObject = await handle.Task;
        if (handle.Status == AsyncOperationStatus.Failed)
        {
            Debug.Log($"failed load {resourceName} {typeof(T)}");
            return default;
        }
        if (!cachedObject.TryGetComponent(out T resource))
        {
            Debug.Log($"{typeof(T)} is null on {resourceName}");
            return default;
        }
        _cachedObjects.Add(cachedObject);
        return resource;
    }

    public void UnloadAsset(GameObject cachedObject)
    {
        if (cachedObject == null)
        {
            return;
        }

        if (!_cachedObjects.Contains(cachedObject))
        {
            return;
        }

        cachedObject.SetActive(false);
        _cachedObjects.Remove(cachedObject);
        Addressables.Release(cachedObject);
    }

    public void Uninit()
    {
        for (int i = _cachedObjects.Count - 1; i >= 0; i--)
        {
            UnloadAsset(_cachedObjects[i]);
        }
    }
}