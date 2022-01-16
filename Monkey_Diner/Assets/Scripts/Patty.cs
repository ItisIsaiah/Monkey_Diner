using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty : MonoBehaviour
{
    Material material;
    public bool isCooking = false;
    public float cookedPercentage=0f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Cooking();
    }
    void Cooking()
    {
        while (isCooking == true)
        {
           
            Debug.Log("WE got to this point");
            float time = 0;
            cookedPercentage = time * 10;
            Debug.Log("IM COOKING");
            time += Time.deltaTime / 10;
            material.SetFloat("Color Value", time);
        }
    }
}
//