using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Image image;
    public Cursor cursor;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //image.color = new Color(0f, 255f, 200f, 0.7f);
        image.raycastTarget = false;
        var slotTransform = rectTransform.parent;
        slotTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        Cursor.visible = false;
        gameObject.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //image.color = new Color(255f, 255f, 255f, 1f);
        image.raycastTarget = true;
        Cursor.visible = true;
        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
    }
}
