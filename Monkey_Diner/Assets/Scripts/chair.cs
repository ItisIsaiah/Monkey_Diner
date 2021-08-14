using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    GameObject monkey;
    public CustomerTrail monkeyScript;
    string[] monkeyChoice;

    [SerializeField]
    GameObject plate;
    GameObject paperplate;
    plate plateScript;
    string[] plateChoice;

    public Transform platepoint;
    // Start is called before the first frame update
    void Start()
    {
        paperplate= Instantiate(plate,platepoint);
        paperplate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            monkey = other.gameObject;
            monkeyScript = monkey.GetComponent<CustomerTrail>();
            monkeyChoice = monkeyScript.topfoods;
            paperplate.SetActive(true);
            Debug.Log("I WORKED");
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Customer")
        {
            paperplate.SetActive(false);
        }
    }


}
