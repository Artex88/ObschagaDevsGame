using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform startParent;
    private Canvas mainCanvas;
    private Image image;

    //private Renderer renderer;
    public Material redMaterial;
    public Material yelMaterial;
    public Material startMaterial;
    public Cursor cursor;

    public ContextMenu contextMenu;
    public GameObject infoPanel;
    public GameObject settingsPanel;
    public string name;



    private void Awake()
    {
        mainCanvas = GetComponentInParent<Canvas>();
        image = GetComponent<Image>();
        startParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        image.material = redMaterial;
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
        if (startParent != transform.parent)
        {
            image.material = yelMaterial;
        }
        else
        {
            image.material = startMaterial;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            contextMenu.item = this;
            contextMenu.infoPanel = infoPanel;
            contextMenu.settingsPanel = settingsPanel;
            contextMenu.title.text = name;
            contextMenu.Show();
        }
    }

    /*private void Update()
    {
        if (contextMenu.isDelete)
        {
            //transform.SetParent(startParent);
            gameObject.SetActive(false);
            contextMenu.isDelete = false;
        }
    }*/

    public void Delete()
    {
        transform.SetParent(startParent);
        image.material = startMaterial;
    }
}
