using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Canvas gameCanvas;
    [SerializeField] private ItemSlot startSlot;
    [SerializeField] private GameObject theDragged;
    private Sprite[] imgArray;
    private Sprite[] shuffledImgArray;

    void Start()
    {
        
    }

    private void Awake()
    {
        gameCanvas = this.gameObject.GetComponent<Canvas>();
        imgArray = (Resources.LoadAll<Sprite>("Graphics/Pictures"));
        shuffledImgArray = shuffle((Sprite[])imgArray.Clone());
        startSlot.loadImage(shuffledImgArray[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Array functions

    // getNextImg

    // removeImg

    // sendToBack

    // checkResult



     
    
    public IEnumerator reset(bool correct, GameObject dropSlot)
        
    {
        if (correct)
        {
            // Animation for correct
            // Code to run if got it right
            // animation
            // wait 
            yield return new WaitForSeconds(3);
            //then get next image, assign to 
            theDragged.GetComponent<DragDrop>().reset();
            
        } else
        {
            // code to run of they are a stupid idiot and got it wrong
        }

            
    }

    private Sprite[] shuffle(Sprite[] imgArray)
    {
        Sprite[] shuffledArray = new Sprite[imgArray.Length];
        int rndNo;

        System.Random rnd = new System.Random();
        for (int i = imgArray.Length; i >= 1; i--)
        {
            rndNo = rnd.Next(1, i + 1) - 1;
            shuffledArray[i - 1] = imgArray[rndNo];
            imgArray[rndNo] = imgArray[i - 1];
        }
        return shuffledArray;
    }

}
