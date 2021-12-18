using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Snapping : MonoBehaviour
{

    public GameObject UpperDropZone;
    public Collider UpperCollider;
   
  
     public GameObject LowerDropZone;
     public Collider lowerCollider;
    
    GameObject daParent;
   
    // Start is called before the first frame update
    public void Start()
    {

        UpperDropZone.SetActive(false);
        LowerDropZone.SetActive(false);
        
      }

   
    
 



    private void OnTriggerEnter(Collider other)
    {
        SnapCheck(other);
    }

    public virtual void SnapCheck(Collider other)
    {
       // Debug.Log(name + "is  grabbing" + other.name);
        if (other.CompareTag("Food"))
        {
                other.gameObject.tag = "Snapped";
                UpperDropZone.SetActive(true);
                LowerDropZone.SetActive(true);
                other.gameObject.layer = 9;
                

        }

    }

    


}
