using UnityEngine;
using System;
using System.Threading.Tasks;

public class TimeTicker
{
    private bool _isWork;
    public event EventHandler OnTimeTick;

    public TimeTicker()
    {
        StartWork();
    }

    public void StartWork()
    {
        _isWork = true;
        TimerLoop();
    }

    public void StopWork()
    {
        _isWork = false;
    }

    private async void TimerLoop()
    {
        while (_isWork)
        {
            OnTimeTick?.Invoke(this, EventArgs.Empty);
            await Task.Yield();
        }
    }

}
