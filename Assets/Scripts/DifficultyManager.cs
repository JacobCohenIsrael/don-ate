using UnityEngine;

[CreateAssetMenu(menuName = "don-ate/DifficultyManager", fileName = "DifficultyManager")]
public class DifficultyManager : ScriptableObject
{
    [SerializeField] private DifficultySettings difficultySettings;

    public string Title => difficultySettings.title;
    public int NumberOfLanes => difficultySettings.numberOfLanes;

    public int WishlistSize => difficultySettings.wishlistSize;

    public float VehicleSpeed => difficultySettings.vehicleSpeed;

    public float AccelerationDelay => difficultySettings.vehicleAccelerationDelay;

    public void SetDifficulty(DifficultySettings settings)
    {
        difficultySettings = settings;
    }
}
