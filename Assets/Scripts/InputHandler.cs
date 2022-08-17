using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InputHandler
{
    public event EventHandler<InputActionType> OnInputEnter;
    private bool _isWork;

    public InputHandler()
    {
        _isWork = true;
        AwaitInput();
    }

    public void Stop()
    {
        _isWork = false;
    }

    private async void AwaitInput()
    {
        while (_isWork)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                OnInputEnter?.Invoke(this, InputActionType.MoveDown);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                OnInputEnter?.Invoke(this, InputActionType.MoveRight);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                OnInputEnter?.Invoke(this, InputActionType.MoveLeft);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnInputEnter?.Invoke(this, InputActionType.Rotate);
            }
            await Task.Yield();
        }
    }
}
