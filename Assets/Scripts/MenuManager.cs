using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button instructionsButton;
    [SerializeField] private Button quitGameButton;
    private int isFirstPlay;

    private void Awake()
    {
        startGameButton.onClick.AddListener(OnStartGame);
        quitGameButton.onClick.AddListener(OnExitGame);
        instructionsButton.onClick.AddListener(OnInstructions);
        isFirstPlay = PlayerPrefs.GetInt("FirstPlay", 1);
    }

    private void OnDestroy()
    {
        startGameButton.onClick.RemoveListener(OnStartGame);
        quitGameButton.onClick.RemoveListener(OnExitGame);
        instructionsButton.onClick.RemoveListener(OnInstructions);

    }

    private void OnStartGame()
    {
        if (isFirstPlay == 1)
        {
            SceneManager.LoadScene("Instructions");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void OnInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    private void OnExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
# endif
        Application.Quit();
    }
}
