using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public Transform door;
    public Transform[] movespots;
    public int randomSpot;
    public int orderNumber;
    public Object customer;
    Transform spawnPoint;
    int customerCount;
    float TimetillSpawn = 5f;
    float curTime;
    
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, movespots.Length-2);
        orderNumber = Random.Range(0, 2);
        spawnPoint = GetComponent<Transform>();
        movespots[movespots.Length - 1] = door;
        Instantiate(customer,spawnPoint);
        customerCount = 1;
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        //Debug.Log(curTime);
        if (curTime >= TimetillSpawn && customerCount <=5)
        {
            randomSpot = Random.Range(0, movespots.Length);
            orderNumber = Random.Range(0, 2);
            Instantiate(customer, spawnPoint);
            customerCount++;
            
            curTime = 0;
        }
    }
}
