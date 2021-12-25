using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerMaking:Snapping 
{
    
    
   
    public ArrayList topFoods = new ArrayList();
    ArrayList redundancy = new ArrayList();
   // int stuffCount;

   
    void Start()
    {
        base.Start();
        
        
      //  stuffCount = 0;
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public override void SnapCheck(Collider other)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        base.SnapCheck(other);

        
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

}

