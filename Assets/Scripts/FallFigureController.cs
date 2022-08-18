using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class FallFigureController
{
    private float _fallSpeedMultipler;
    private float _time;
    public event EventHandler OnTimeUpdate;

    public FallFigureController(TimeTicker ticker, GameplayConfig config)
    {
        _fallSpeedMultipler = config.StartFallSpeedMultiplier;
        ticker.OnTimeTick += UpdateTimer;
    }

    private void UpdateTimer(object sender, EventArgs e)
    {
        _time += Time.deltaTime * _fallSpeedMultipler;
        if (_time >= 1)
        {
            _time = 0;
            OnTimeUpdate?.Invoke(this, EventArgs.Empty);
        }
    }

    public void SetTimeMultiplier(int multiplier)
    {
        _fallSpeedMultipler = multiplier;
    }
}
