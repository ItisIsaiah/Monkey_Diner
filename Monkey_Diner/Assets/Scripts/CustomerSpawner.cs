using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public Transform door;
    public Transform[] movespots;
    public int[] prevSpots = new int[5];
    public int randomSpot;
    public int orderNumber;
    public Object customer;
    Transform spawnPoint;
    int customerCount;
    float TimetillSpawn = 5f;
    float curTime;
    int increment = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, movespots.Length-2);
        prevSpots[0] = randomSpot;
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
            randomSpot = Random.Range(0, movespots.Length-2);
            for (int i =0; i<5;i++)
            {
                if (prevSpots[i] == randomSpot)
                {
                    randomSpot++;
                    break;
                }
                
            }
            prevSpots[increment]= randomSpot;
            increment++;
            if (increment>=5){
                increment = 0;
            }
            orderNumber = Random.Range(0, 2);
            Instantiate(customer, spawnPoint);
            customerCount++;
            
            curTime = 0;

            
        }
    }
}
