using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Menu");
    }
}