using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    Transform snapPoint;
    bool isSnapping;
    Collider boxCollider;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isSnapping = false;
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {/*
        if (isSnapping)
        {
            
            transform.position = snapPoint.position;
        }
        */
    }

    public void Snap(Transform snap)
    {
        isSnapping = true;
        snapPoint = snap;
        Destroy(boxCollider);
        rb.freezeRotation = true;
    }
}
