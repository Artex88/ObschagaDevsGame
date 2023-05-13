using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject itemPrefab;
    public Transform cellGroup;

    public int slotsCount;
    public float[,] slotAndItemsPosisitions = new float[,]
    {
        { 5f, -280f, 0f },
        { 115.8f, -206.8f, 0f },
        { 229.5f, -133.6f, 0f },
        { 343.2f, -61.4f, 0f },
        { 461.9f, 17.7f, 0f },
        { 344.2f, 93.9f, 0f },
        { 226.5f, 16.8f, 0f },
        { 113.8f, -57.4f, 0f },
        { 1.1f, -131.6f, 0f },
        { -118.6f, -209.7f, 0f },
        { -233.3f, -135.4f, 0f },
        { -114.6f, -57.3f, 0f },
        { -2.8f, 14.9f, 0f },
        { 108.9f, 89f, 0f },
        { 228.6f, 167.1f, 0f },
        { 110.9f, 238.3f, 0f },
        { -2.8f, 163.1f, 0f },
        { -115.6f, 88.9f, 0f },
        { -231.3f, 13.7f, 0f },
        { -343.1f, -58.5f, 0f },
        { -460.8f, 15.7f, 0f },
        { -350.0f, 91.0f, 0f },
        { -233.3f, 164.1f, 0f },
        { -121.5f, 236.3f, 0f },
        { -7.8f, 314.4f, 0f }
    };

    public void Start()
    {
        CreateSlots();
        //CreateItems();
        //CreateItems();
        //CreatePath();
    }

    public void CreateSlots()
    {
        for (int i = 0; i < slotsCount; i++)
        {
            GameObject tmpCell = Instantiate(slotPrefab);
            tmpCell.transform.SetParent(cellGroup, false);
            tmpCell.GetComponent<CellSlot>().id = i + 1;
            tmpCell.GetComponent<CellSlot>().SetState(0);
            tmpCell.GetComponent<CellSlot>().transform.localPosition = new Vector3(slotAndItemsPosisitions[i, 0], slotAndItemsPosisitions[i, 1], 0);
        }
    }

    public void CreateItems()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject tmpCell = Instantiate(itemPrefab);
            tmpCell.transform.SetParent(cellGroup, false);
            tmpCell.GetComponent<CellSlot>().id = i + 1;
            tmpCell.GetComponent<CellSlot>().SetState(0);
            tmpCell.GetComponent<CellSlot>().transform.localPosition = new Vector3(slotAndItemsPosisitions[i, 0], slotAndItemsPosisitions[i, 1], 0);
        }

    }

    public void CreatePath()
    {

    }
}
