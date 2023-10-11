using System;
using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/timeScale", fileName = "TimeScale")]
public class TimeScale : ScriptableObject
{
    [SerializeField] private float value;

    private float maxDuration;    
    private float startTime;
    private bool isActive = false;

    public float Value => isActive ? Mathf.Min((Time.time - startTime) * 1 / maxDuration, 1) : 0;

    public void Stop()
    {
        isActive = false;
    }

    public void SetMaxDuration(float max)
    {
        maxDuration = MathF.Max(0.0001f, max);
    }

    public void Start()
    {
        startTime = Time.time;
        isActive = true;
    }
}
