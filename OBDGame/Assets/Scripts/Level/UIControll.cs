using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControll : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
}
