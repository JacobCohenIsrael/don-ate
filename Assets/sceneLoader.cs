using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    public Scene scene;
    AsyncOperation asyncLoadLevel;

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync("Menu");
        asyncLoadLevel.allowSceneActivation = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        // preload scene

        asyncLoadLevel = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        asyncLoadLevel.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}