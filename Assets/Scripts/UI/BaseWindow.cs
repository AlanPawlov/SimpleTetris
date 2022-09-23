using UnityEngine;
public class BaseWindow : MonoBehaviour
{
    [SerializeField]
    private TypeWindow _typeWindow;
    public TypeWindow TypeWindow => _typeWindow;
    protected WindowsController _windowsController;
    protected SceneLoader _sceneloader;

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Unregister()
    {
        _windowsController.UnregisterWindow(this);
    }
}
