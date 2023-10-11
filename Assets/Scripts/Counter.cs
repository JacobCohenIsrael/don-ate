using System;
using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/counter", fileName = "Counter")]
public class Counter : ScriptableObject
{
    [SerializeField] private long value;
    [SerializeField] private long min;
    [SerializeField] private long max;

    public event EventHandler OnChange;
    
    public long Value => value;
    
    public void Increment()
    {
        value = (long)Mathf.Min(max, value + 1);
        OnChange?.Invoke(this, EventArgs.Empty);
    }

    public void Decrement()
    {
        value = (long)Mathf.Max(min, value - 1);
        OnChange?.Invoke(this, EventArgs.Empty);
    }

    public void Reset()
    {
        value = 0;
        OnChange?.Invoke(this, EventArgs.Empty);
    }
}
