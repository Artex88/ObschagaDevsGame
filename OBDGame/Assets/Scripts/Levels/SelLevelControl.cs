using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelLevelControl : MonoBehaviour
{
    public string indexLevel;
    public Animator animator;
    public GameObject description;
    public void SelectLevel()
    {
        Debug.Log("Selected:" + indexLevel);
        CurLevel.curLevelIndx = indexLevel;
    }
    private void Update()
    {
        if (indexLevel == CurLevel.curLevelIndx)
        {
            animator.SetBool("isSelected", true);
            description.SetActive(true);
        }
        else
        {
            animator.SetBool("isSelected", false);
            description.SetActive(false);
        }
    }
    public void StartLevel()
    {
        PlayerPrefs.SetString("lastLevel", CurLevel.curLevelIndx);
        Debug.Log("Start:" + CurLevel.curLevelIndx);
        SceneManager.LoadScene(CurLevel.curLevelIndx);
    }
}
