using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//TestingCommitChanges
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Transform startParent;
    public Transform currentParent;
    Vector3 startPosition;
    public static string theDragged;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startParent = GetComponent<Transform>().parent;
        currentParent = startParent;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        Debug.Log("OnBeginDrag");
        currentParent = GetComponent<Transform>().parent;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        theDragged = this.transform.GetComponent<Image>().sprite.name;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // set dragged item to null
        DragHandler.itemBeingDragged = null;

        if (this.transform.parent == currentParent)
        {
            rectTransform.position = currentParent.position;
        }
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reset()
    {
        // reset the parent object
        currentParent = startParent;
        // send the object back to startPos
        rectTransform.position = currentParent.position;


    }
}
