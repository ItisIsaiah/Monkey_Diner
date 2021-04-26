using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barstools : MonoBehaviour
{
    public Transform[] allchildren;
    // Start is called before the first frame update
    void Start()
    {
        allchildren = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
