using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class UIManager
{
    private Transform _mainCanvas;
    private ResourcesManager _resourcesManager;
    private List<BaseWindow> _openedWindow;

    private Transform MainCanvas
    {
        get
        {
            if (_mainCanvas == null)
            {
                _mainCanvas = Object.FindObjectOfType<Canvas>().transform;
            }
            return _mainCanvas;
        }
    }

    public UIManager(ResourcesManager resourcesManager)
    {
        _resourcesManager = resourcesManager;
        _openedWindow = new List<BaseWindow>();
    }

    public async Task<T> CreateWindow<T>(string assetPath) where T : BaseWindow
    {
        var window = await _resourcesManager.LoadAsset<T>(assetPath);
        window.transform.SetParent(MainCanvas.transform, false);
        _openedWindow.Add(window);
        return window;
    }

    public async Task<T> CreateWidget<T>(string assetPath, Transform parent) where T : CustomUI
    {
        var widget = await _resourcesManager.LoadAsset<T>(assetPath);
        widget.transform.SetParent(parent, false);
        return widget;
    }

    public void UnloadUI(GameObject cachedObject)
    {
        _resourcesManager.UnloadAsset(cachedObject);
    }

}
