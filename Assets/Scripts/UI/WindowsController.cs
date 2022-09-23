using System.Collections.Generic;
using UnityEngine;

public class WindowsController
{
    private List<BaseWindow> _registeredWindow;

    public WindowsController()
    {
        _registeredWindow = new List<BaseWindow>();
    }

    public void ShowWindow(TypeWindow targetType)
    {
        foreach (var window in _registeredWindow)
        {
            var isTargetWindow = window.TypeWindow == targetType;

            if (isTargetWindow)
            {
                window.Show();
                continue;
            }

            window.Hide();
        }
    }

    public void HideWindow(BaseWindow window)
    {
        var isContains = _registeredWindow.Contains(window);
        if (isContains)
        {
            _registeredWindow.Find(w => w == window).Hide();
        }
    }

    public void RegisårWindow(BaseWindow window)
    {
        _registeredWindow.Add(window);
    }

    public void UnregisterWindow(BaseWindow window)
    {
        var isContains = _registeredWindow.Contains(window);
        Debug.Log($"UnregisterWindow{isContains} {window}");
        if (isContains)
        {
            _registeredWindow.Remove(window);
        }
    }
}
