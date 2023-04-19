using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackAMole : MonoBehaviour
{

    string toppingNeeded;
    int correctHits;
    int goldenButtonlocation;
    public Sprite[] buttonPicsOptions;
    public SpriteRenderer[] buttonPics;
    float switchTimer;
    // Start is called before the first frame update
    void Start()
    {
        switchTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switchTimer += Time.deltaTime;
        if (switchTimer >= 2)
        {
            foreach (SpriteRenderer s in buttonPics)
            {
                int rng = Random.Range(0,buttonPicsOptions.Length-1);
                s.sprite = buttonPicsOptions[rng];
                //assign the button value to this
            }
        }
    }

    void wackedButton()
    {
        if (this.tag==goldenButtonlocation.ToString())
        {
            correctHits++;
        }
        else
        {
            correctHits = 0;
        }
        if (correctHits == 3)
        {
            
            //add topping to the plate
            //spawn topping on top of plate
        }
    }

    
}
