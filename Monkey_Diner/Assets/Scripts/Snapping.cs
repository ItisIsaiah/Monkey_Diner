using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Snapping : MonoBehaviour
{
    public GameObject CubeDropZone;
    
    Transform snapPoint;
    bool isSnapping;
    Collider boxCollider;
    Rigidbody rb;
    GameObject daParent;
    XRSocketInteractor CubeScript;
    // Start is called before the first frame update
    void Start()
    {
        isSnapping = false;
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        CubeDropZone.SetActive(false);
        CubeScript =CubeDropZone.gameObject.GetComponent<XRSocketInteractor>();
      //  CubeScript.socketActive = false;
    }

   
    
    public void Snap( GameObject Parent)
    {
        
        daParent = Parent;
        CubeDropZone.SetActive(true);
        //CubeScript.socketActive = true;
        
     
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Snapping script = other.gameObject.GetComponent<Snapping>();
            script.Snap(daParent);
            other.gameObject.layer = 9;
        }
    }

    


}
