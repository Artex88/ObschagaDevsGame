using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    public RectTransform rectTransform;
    public Text title;
    [HideInInspector] public bool isDelete=false;
    [HideInInspector] public GameObject infoPanel;
    [HideInInspector] public GameObject settingsPanel;
    [HideInInspector] public Item item;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show()
    {
        var position = Input.mousePosition;

        var pivotX = position.x / Screen.width;
        var pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Settings()
    {
        gameObject.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Info()
    {
        gameObject.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void Delete()
    {
        gameObject.SetActive(false);
        item.Delete();
    }
}
