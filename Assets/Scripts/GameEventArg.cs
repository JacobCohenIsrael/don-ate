using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/GameEventArg", fileName = "GameEventArg")]
public class GameEventArg : ScriptableObject
{
    private List<Action<object>> actions;

    private void OnEnable()
    {
        actions = new List<Action<object>>();
    }

    public void Raise(object param)
    {
        for (int i = actions.Count - 1; i >= 0; i--)
        {
            actions[i].Invoke(param);
        }
    }

    public void RegisterListener(Action<object> action)
    {
        if (actions.Contains(action))
        {
            Debug.LogWarning($"listener {action} is already registered");
            return;
        }
        actions.Add(action);
    }
    
    public void UnregisterListener(Action<object> action)
    {
        if (actions.Contains(action))
        {
            actions.Remove(action);
        }
        else
        {
            Debug.LogWarning($"listener {action} is not registered and can't be removed");
        }
    }
}
