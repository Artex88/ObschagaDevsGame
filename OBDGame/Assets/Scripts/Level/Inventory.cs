using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject bottomLeft;
    public GameObject bottomRight;
    public List<GameObject> itemsArr;
    private int curPos=0;

    private void Start()
    {
        while (itemsArr.Count % 3 != 0)
        {
            itemsArr.Add(new GameObject());
        }
    }

    private void Update()
    {
        if (curPos-3 < 0)
        {
            bottomLeft.SetActive(false);
        }
        else
        {
            bottomLeft.SetActive(true);
        }

        if (curPos+3 > itemsArr.Count-1)
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
        if (curPos < 0)
        {
            curPos = 0;
        }
        var startPos = curPos;
        for(int i = startPos; i < startPos+3; i++)
        {
            itemsArr[i].SetActive(false);
            curPos++;
        }
        startPos = curPos;
        for (int i = startPos; i < startPos + 3; i++)
        {
            itemsArr[i].SetActive(true);
            curPos++;
        }

    }

    public void ScrollLeft()
    {
        if (curPos == itemsArr.Count)
        {
            curPos--;
        }
        var startPos = curPos;
        for (int i = startPos; i > startPos - 3; i--)
        {
            itemsArr[i].SetActive(false);
            curPos--;
        }
        startPos = curPos;
        for (int i = startPos; i > startPos - 3; i--)
        {
            itemsArr[i].SetActive(true);
            curPos--;
        }
    }
}
