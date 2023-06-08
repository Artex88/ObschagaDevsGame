using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInv : MonoBehaviour
{
    public GameObject bottomLeft;
    public GameObject bottomRight;
    public List<GameObject> itemsArr;
    private int curPos = 0;
    private void Update()
    {
        if (curPos <= 0)
        {
            bottomLeft.SetActive(false);
        }
        else
        {
            bottomLeft.SetActive(true);
        }

        if (curPos >= itemsArr.Count - 1)
        {
            bottomRight.SetActive(false);
        }
        else
        {
            bottomRight.SetActive(true);
        }
    }

    public void ScrollRight()
    {
        curPos++;
        itemsArr[curPos].SetActive(true);
        itemsArr[curPos-1].SetActive(false);
    }

    public void ScrollLeft()
    {
        curPos--;
        itemsArr[curPos].SetActive(true);
        itemsArr[curPos + 1].SetActive(false);
    }
}
