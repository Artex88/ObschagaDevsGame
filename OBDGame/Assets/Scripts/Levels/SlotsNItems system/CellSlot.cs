using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSlot : MonoBehaviour
{
    public int state;
    public int id;
    public Color slotColor, itemColor; 
    
    public void SetState(int i)
    {
        state = i;

        if (i == 0)
        {
            GetComponent<Image>().color = slotColor;
        }
        
        if (i == 1)
        {
            GetComponent<Image>().color = itemColor;
        }
    }
}
