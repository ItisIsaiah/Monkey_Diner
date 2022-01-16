using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorPoint;
    CustomerTrail customer;
    // Start is called before the first frame update
    void Start()
    {
        doorPoint = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            customer=other.GetComponent<CustomerTrail>();
            if (customer.goAway==true)
            {
                customer.selfDestruct();
            }
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
