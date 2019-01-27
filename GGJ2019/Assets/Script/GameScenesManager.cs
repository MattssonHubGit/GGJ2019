using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : MonoBehaviour
{

    public static int gameSceneIndex = 0;

    public void Reload()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            Reload();

        }
    }
}
