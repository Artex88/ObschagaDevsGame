using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private Canvas mainCanvas;
    private Image image;
    public Cursor cursor;

    private void Awake()
    {
        mainCanvas = GetComponentInParent<Canvas>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Cursor.visible = false;
        gameObject.transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        Cursor.visible = true;
        gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        transform.SetParent(parentAfterDrag);
    }
}
