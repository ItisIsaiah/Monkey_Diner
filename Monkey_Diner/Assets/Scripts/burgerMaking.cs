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

        if (this.gameObject.layer==9)
        {
            this.gameObject.layer = 8;
        }
    }
    public override void SnapCheck(Collider other)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        base.SnapCheck(other);
        if (other.CompareTag("Snapped")) {
            

            for (int i = 0; i <redundancy.Count; i++)
            {
                if (topFoods.Contains(redundancy[i]))
                {
                  //  Debug.Log("checked"+redundancy[i]);
                    return;
                }
            }
            topFoods.Add(other.transform.root.gameObject.name);
            redundancy.Add(other.transform.root.gameObject.name);
           Debug.Log(other.transform.root.gameObject.name);
        }
        
    }

}

