using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void OnNextlevel()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void OnPreviousLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
