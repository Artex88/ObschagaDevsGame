using UnityEngine;
using UnityEngine.EventSystems;

public class Items : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private Canvas mainCanvas;
    private RectTransform rectTransform;
    public int itemID;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCanvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = rectTransform.parent;
        slotTransform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
    }
}
