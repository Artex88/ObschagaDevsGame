using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public bool isBusy = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !isBusy)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            GetComponent<RectTransform>().anchoredPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBusy = true;
    }
}
