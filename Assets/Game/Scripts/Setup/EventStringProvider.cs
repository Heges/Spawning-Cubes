using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="EventStringProvider")]
public class EventStringProvider : ScriptableObject
{
    public Action<string> OnAction;

    public void RaiseEvent(string text)
    {
        OnAction?.Invoke(text);
    }
}
