using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/difficulty", fileName = "difficulty")]
public class DifficultySettings : ScriptableObject
{
    public int numberOfLanes;
    public int wishlistSize;
    public float vehicleSpeed;
    public float vehicleAccelerationDelay;
}
