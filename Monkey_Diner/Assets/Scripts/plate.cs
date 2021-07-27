using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    burgerMaking foodWanted;
    chair getit;
    CustomerTrail monkey;
    
    // Start is called before the first frame update
    void Start()
    {
        getit=GetComponentInParent<chair>();
        monkey = getit.monkeyScript;
        Debug.Log(monkey.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Substring(0,other.name.Length-3)=="bottbun")
        {
            foodWanted=other.gameObject.GetComponent<burgerMaking>();
            string[] foodGiven = foodWanted.typeFoods;
            monkey.Compare(foodGiven);

            
        }
    }
}
