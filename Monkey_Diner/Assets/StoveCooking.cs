using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCooking : MonoBehaviour
{
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        Patty patty= other.GetComponent<Patty>();
        patty.cookedPercentage = time * 100;
        Material mat= other.GetComponentInChildren<MeshRenderer>().material;
         
        

        Debug.Log(time);
        time += Time.deltaTime/10;
        mat.SetFloat("_ColorValue", time);
        
    }

}
