using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button quitGameButton;

    private void Awake()
    {
        startGameButton.onClick.AddListener(OnStartGame);
        quitGameButton.onClick.AddListener(OnExitGame);
    }

    private void OnDestroy()
    {
        startGameButton.onClick.RemoveListener(OnStartGame);
        quitGameButton.onClick.RemoveListener(OnExitGame);
    }

    private void OnStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
# endif
        Application.Quit();
    }
}
