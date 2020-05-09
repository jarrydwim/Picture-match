using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    private void Awake()
    {
        Sprite[] images = Resources.LoadAll<Sprite>("Graphics/Pictures");
        Sprite[] ShuffledImages = shuffle((Sprite[])images.Clone());
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

    private void Start()
    {
        Sprite[] images = Resources.LoadAll<Sprite>("Graphics/Pictures");
    }

    public class Equip
    {
        public string Name { get; set; }
        public bool Underpants = false;
        public Equip(string name)
        {
            Name = name;
        }
    }

}