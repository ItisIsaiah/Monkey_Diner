using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public Object customer;
    Transform spawnPoint;
    int customerCount;
    float TimetillSpawn = 5f;
    float curTime;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<Transform>();
        Instantiate(customer,spawnPoint);
        customerCount = 1;
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime == TimetillSpawn)
        {
            Instantiate(customer, spawnPoint);
            curTime = 0;
        }
    }
}
