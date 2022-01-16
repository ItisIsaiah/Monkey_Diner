using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    burgerMaking foodWanted;
    chair getit;
    CustomerTrail monkey;
    bool Compared;
    GameLoop gameLoop;
    // Start is called before the first frame update
    void Start()
    {
        getit=GetComponentInParent<chair>();
        monkey = getit.monkeyScript;
        Compared = false;
        Debug.Log(monkey.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("SOMETHINGS IN THE TRIGGER!" + other.gameObject.name);
        if (other.gameObject.name=="bottbun(Clone)")
        {
            Debug.Log("THE TRIGGER REGISTERED THE BUN");
            foodWanted=other.gameObject.GetComponent<burgerMaking>();
            ArrayList foodGiven = foodWanted.topFoods;
            ArrayList foodWant = monkey.topfoods;

            bool ans= gameLoop.Compare(foodGiven,foodWant);

            monkey.Result(ans);
            Compared = true;
            other.gameObject.SetActive(false);
            
        }
        if (other.tag == "Food" && Compared == true)
        {
            other.gameObject.SetActive(false);
            Compared = false;
        }
        
    }

    
}
