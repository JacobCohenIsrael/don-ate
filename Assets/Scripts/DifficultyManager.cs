using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/DifficultyManager", fileName = "DifficultyManager")]
public class DifficultyManager : ScriptableObject
{
    [SerializeField] private DifficultySettings difficultySettings;

    public int NumberOfLanes => difficultySettings.numberOfLanes;

    public int WishlistSize => difficultySettings.wishlistSize;

    public float VehicleSpeed => difficultySettings.vehicleSpeed;

    public float AccelerationDelay => difficultySettings.vehicleAccelerationDelay;
}
