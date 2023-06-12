using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dict : MonoBehaviour
{
    public GameObject[] infoPanels;

    public void SetActivAll()
    {
        foreach (var info in infoPanels)
        {
            info.SetActive(false);
        }
    }
}
