using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/difficulty", fileName = "difficulty")]
public class DifficultySettings : ScriptableObject
{
    public string title;
    public int numberOfLanes;
    public int wishlistSize;
    public float vehicleSpeed;
    public float vehicleAccelerationDelay;
    public float vehicleSpawnRate;
}
