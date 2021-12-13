using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerMaking : MonoBehaviour
{
    public Transform snapPoint;
    GameObject food;
    Rigidbody foodRB;
    bool isfood;
    Snapping script;
    public string[] typeFoods=new string[3];
    int stuffCount;

    public GameObject cubeDropZone;
    void Start()
    {
        isfood = false;
        stuffCount = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            typeFoods[stuffCount]=other.gameObject.name;
            stuffCount++;
           other.gameObject.layer = 9;
           script=other.gameObject.GetComponent<Snapping>();
           script.Snap(gameObject);
           // transform.position = new Vector3(transform.position.x, transform.position.y + .2f, transform.position.z);





        }
    }
}
