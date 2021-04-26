using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorPoint;

    // Start is called before the first frame update
    void Start()
    {
        doorPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
