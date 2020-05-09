using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using static DragDrop;

public class ItemSlot : MonoBehaviour, IDropHandler, IEndDragHandler
{

    private Picture picture;
    public string dragName;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = this.transform.parent.GetComponent<GameManager>();
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (theDragged.Substring(theDragged.Length - 3) == this.transform.name && theDragged != null)
            {
                eventData.pointerDrag.GetComponent<Transform>().SetParent(GetComponent<Transform>().transform);
                eventData.pointerDrag.GetComponent<DragDrop>().currentParent = GetComponent<Transform>().transform;
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                // Call game manager to call reset() in drag drop
                StartCoroutine(gameManager.reset(true, this.gameObject));
            } else
            {
                // call game manager to reset the picture at back of array
            }
            Debug.Log(theDragged);
            Debug.Log(eventData.pointerDrag.GetComponent<Transform>().name + " was dropped.");
            Debug.Log("My Daaddy is " + eventData.pointerDrag.GetComponent<Transform>().parent.name);
            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPicture(Picture pic)
    {
        this.picture = pic;
    }

    private IEnumerator waitABit(int secs)
    {
            yield return new WaitForSeconds(secs);
    }

    public void loadImage(Sprite img) { 
        if (this.gameObject.name == "startSlot")
        {
            GameObject slot = this.transform.GetChild(0).gameObject;
            slot.GetComponent<Image>().sprite = img;
        }
    }
}
