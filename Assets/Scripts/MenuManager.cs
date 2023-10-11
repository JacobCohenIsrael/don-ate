using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button quitGameButton;

    private void Awake()
    {
        startGameButton.onClick.AddListener(onStartGame);
        quitGameButton.onClick.AddListener(onExitGame);
    }

    private void OnDestroy()
    {
        startGameButton.onClick.RemoveListener(onStartGame);
        quitGameButton.onClick.RemoveListener(onExitGame);
    }

    public void onStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void onExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
# endif
        Application.Quit();
    }
}
