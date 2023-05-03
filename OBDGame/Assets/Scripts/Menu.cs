using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayCurLevel()
    {
        if (PlayerPrefs.HasKey("lastLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("lastLevel"));
        }
    }

    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
