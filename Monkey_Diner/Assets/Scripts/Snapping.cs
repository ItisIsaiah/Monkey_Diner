using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    public GameObject CubeDropZone;
    Transform snapPoint;
    bool isSnapping;
    Collider boxCollider;
    Rigidbody rb;
    GameObject daParent;
    // Start is called before the first frame update
    void Start()
    {
        isSnapping = false;
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        CubeDropZone.SetActive(false);
    }

   
    
    public void Snap( GameObject Parent)
    {

        daParent = Parent;
        if (name!= "Cheese") 
            transform.eulerAngles = new Vector3(0, 0f, 0f);
       //transform.parent = daParent.transform;=-+
       CubeDropZone.SetActive(true);
      // daParent.transform.position = new Vector3(transform.position.x, transform.position.y + .2f, transform.position.z);
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
