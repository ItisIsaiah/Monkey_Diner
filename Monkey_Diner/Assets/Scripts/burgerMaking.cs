using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerMaking:OGSnapping 
{
    public ArrayList topFoods = new ArrayList();
    ArrayList redundancy = new ArrayList();
   

    GameObject child;
    new void Start()
    {
        base.Start();
    }
       private new void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        
        if (other.CompareTag("Snapped")) {   
            for (int i = 0; i <redundancy.Count; i++)
            {
                if (topFoods.Contains(redundancy[i]))
                {
                    return;
                }
            }
            topFoods.Add(other.transform.root.gameObject.name);
            redundancy.Add(other.transform.root.gameObject.name);
            other.transform.root.gameObject.layer = LayerMask.NameToLayer("Default");
            Debug.Log(other.transform.root.gameObject.name);
        }
        
    }
    ArrayList ComputefoodStack()
    {
        
            int children = transform.childCount;
            
        for (int i = 0; i < children; ++i)
        {
            child = transform.GetChild(i).gameObject;
           
            if (child.CompareTag("Snapped")) {
                OGSnapping childSnap= child.GetComponent<OGSnapping>();
                topFoods.Add(snapped);
            }
        }


        return topFoods;
    }

}

