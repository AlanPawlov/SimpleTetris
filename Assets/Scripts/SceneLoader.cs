using System;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public event EventHandler OnSceneChanged;
    public void LoadScene(string targetSceneName)
    {
        OnSceneChanged?.Invoke(this, EventArgs.Empty);
        SceneManager.LoadScene(targetSceneName);
    }
}
