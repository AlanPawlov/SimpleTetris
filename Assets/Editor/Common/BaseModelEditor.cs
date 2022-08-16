using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModelEditor<T>
{
    protected T _model;
    public T GetModel()
    {
        return _model;
    }
}
