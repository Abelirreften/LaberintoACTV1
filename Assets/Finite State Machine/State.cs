using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> : MonoBehaviour
{
    protected T controller;

    public virtual void onEnterState(T controller)
    {
        this.controller = controller;
    }

    public abstract void onUpdateState();

    public abstract void onExitState();
}
