using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCooking : MonoBehaviour
{
    float time=0;

    public GameObject fireParticles;
    // Start is called before the first frame update
    void Start()
    {
        fireParticles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        fireParticles.SetActive(true);
        Patty patty= other.GetComponent<Patty>();
        patty.cookedPercentage = time * 100;
        Material mat= other.GetComponentInChildren<MeshRenderer>().material;
         
        

      
        time += Time.deltaTime/10;
        mat.SetFloat("_ColorValue", time);
        
    }

    private void OnTriggerExit(Collider other)
    {
        fireParticles.SetActive(false);
    }
}
