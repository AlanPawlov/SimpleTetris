using System.Threading.Tasks;
using UnityEngine;

public class CustomUI : MonoBehaviour
{
    protected RectTransform _rectTransform;
    public RectTransform RectTransform => _rectTransform;

    protected ResourcesManager _resourcesManager;
    protected Transform _mainCanvas;

    private void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        Uninit();
    }

    public void SetResourcesManager(ResourcesManager resourcesManager)
    {
        _resourcesManager = resourcesManager;
    }

    public async virtual void Init()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = FindObjectOfType<Canvas>().transform;
    }

    public async Task<T> CreateChild<T>(string assetPath, Transform parent) where T : CustomUI
    {
        var resource = await _resourcesManager.LoadAsset<T>(assetPath);
        resource.transform.SetParent(parent, false);
        return resource;
    }

    public async Task<T> CreateWindow<T>(string assetPath) where T : BaseWindow
    {
        var resource = await _resourcesManager.LoadAsset<T>(assetPath);
        resource.SetResourcesManager(_resourcesManager);
        resource.transform.SetParent(_mainCanvas.transform, false);
        return resource;
    }

    public virtual void Uninit()
    {
        var childs = GetComponentsInChildren<CustomUI>();
        foreach (var child in childs)
        {
            if (this != child)
            {
                child.Uninit();
            }
            _resourcesManager?.UnloadAsset(gameObject);
        }
    }
}
