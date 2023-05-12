using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelLevelControl : MonoBehaviour
{
    public string indexLevel;
    public void SelectLevel(int levelId)
    {
        Debug.Log("Selected level: " + levelId);
        SceneManager.LoadScene(levelId);
    }
}
