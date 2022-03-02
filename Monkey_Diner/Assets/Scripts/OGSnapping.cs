using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OGSnapping : MonoBehaviour
{
    Transform snapPoint;
    bool isSnapping;
    public Collider snapCollider;
    public ArrayList snapped=new ArrayList();
    Rigidbody rb;
    Rigidbody otherRb;
    // Start is called before the first frame update
    public void Start()
    {
        isSnapping = false;
        
        rb = GetComponent<Rigidbody>();
        if (snapCollider == null)
        {
            Debug.LogError(name+" DOES NOT HAVE A SNAP COLLIDER");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject parent = transform.parent.gameObject;
        if (parent != null)
        {
           OGSnapping pSnap= parent.GetComponent<OGSnapping>();
            if (snapped != null)
            {
                pSnap.snapped.Add(snapped);
                snapped = new ArrayList();
            }
        }
    }

     public void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Snapped"))
        {

        }
        if (other.CompareTag("Food"))
        {
            GameObject food = other.gameObject;
            food.transform.position = new Vector3(transform.position.x,transform.position.y+.05f,transform.position.z);
            other.transform.parent = gameObject.transform;
            XRGrabInteractable grab= food.GetComponent<XRGrabInteractable>();

            grab.enabled = false;
            other.tag = "Snapped";

            otherRb = food.GetComponent<Rigidbody>();
            otherRb.freezeRotation=true;
            otherRb.constraints= RigidbodyConstraints.FreezePosition;
            snapped.Add(food.name);
        }
        

    }
    public void Snap(Transform snap)
    {
        isSnapping = true;
        snapPoint = snap;
        Destroy(snapCollider);
        rb.freezeRotation = true;
    }
}
