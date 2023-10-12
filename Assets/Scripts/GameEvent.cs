using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/GameEvent", fileName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    private readonly List<Action> actions = new List<Action>();
    
    public void Raise()
    {
        for (int i = actions.Count - 1; i >= 0; i--)
        {
            actions[i].Invoke();
        }
    }

    public void RegisterListener(Action action)
    {
        if (actions.Contains(action))
        {
            Debug.LogWarning($"listener {action} is already registered");
            return;
        }
        actions.Add(action);
    }
    /// <summary>
    /// remove a listener, this will happen when the listener object becomes disabled
    /// </summary>
    /// <param name="action">the monobehaviour we are listening 'from'</param>
    public void UnregisterListener(Action action)
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
