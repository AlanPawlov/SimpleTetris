using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CustomUI : MonoBehaviour
{
    protected RectTransform _rectTransform;
    private List<CustomUI> _childElements;
    private UIManager _uiManager;

    public RectTransform RectTransform
    {
        get
        {
            if (_rectTransform == null)
            {
                _rectTransform = GetComponent<RectTransform>();
            }

            return _rectTransform;
        }
    }

    public bool IsActive { get; set; }

    [Inject]
    public void Construct(UIManager uiManager)
    {
        _uiManager = uiManager;
    }

    private void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        Uninit();
    }

    public virtual void Init()
    {
        IsActive = true;
        _childElements = new List<CustomUI>();
    }

    public virtual void Uninit()
    {
        IsActive = false;
        foreach (var child in _childElements)
        {
            if (this != child)
            {
                child.Uninit();
            }
            _uiManager?.UnloadUI(gameObject);
        }
        _childElements = null;

    }

    public async Task<T> CreateChild<T>(string assetPath, Transform parent) where T : CustomUI
    {
        var widget = await _uiManager.CreateWidget<T>(assetPath, parent);
        _childElements.Add(widget);
        return widget;
    }

    protected void RemoveChild<T>(T child) where T : CustomUI
    {
        if (child == null)
        {
            return;
        }
        child.Uninit();
        _childElements.Remove(child);
    }
}
