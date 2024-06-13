using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    /* StartGame function */
    public void StartGame()
    { 
        SceneManager.LoadScene("GameScene");
    }

    /* QuitGame function */
    public void ExitGame()
    {
        Application.Quit(); // Close game application

#if UNITY_EDITOR // if playing in unity editor stop the playing mode
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
