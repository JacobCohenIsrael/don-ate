using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] Screens;
    [SerializeField] DifficultyManager difficultyManager;
    [SerializeField] DifficultySettings normal;

    private int screenIndex = 0;
    private int isFirstPlay;

    private void Awake()
    {
        isFirstPlay = PlayerPrefs.GetInt("FirstPlay", 1);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(screenIndex == Screens.Length - 1)
            {
                if(isFirstPlay == 1)
                {
                    PlayerPrefs.SetInt("FirstPlay", 0);
                    difficultyManager.SetDifficulty(normal);
                    StartGame();
                    return;
                }
                MainMenu();
                return;
            }

            Screens[screenIndex + 1].SetActive(true);
            Screens[screenIndex].SetActive(false);
            screenIndex++;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
