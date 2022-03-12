using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public Transform door;
    public Transform[] movespots;
    public GameLoop gl;


    public Queue prevSpots;
    public int randomSpot;
    public int orderNumber;
    public Object customer;
    Transform spawnPoint;
    bool started;
    [SerializeField]
    int maxCustomers;

    public int customerCount;
    float TimetillSpawn = 5f;
    float curTime;
    int increment = 0;
    // Start is called before the first frame update
    void Start()
    {
        prevSpots = new Queue();
        started = false;

    }

   public void  StartSpawning()
    {
        Debug.Log("IM SPAWNING!");
        randomSpot = Random.Range(0, movespots.Length - 2);
        prevSpots.Enqueue(randomSpot);
   
        spawnPoint = GetComponent<Transform>();
        movespots[movespots.Length - 1] = door;
        Instantiate(customer, spawnPoint);
        customerCount = 1;
        curTime = 0;
        started = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (started) {
            curTime += Time.deltaTime;
            //Debug.Log(curTime);
            if (curTime >= TimetillSpawn && customerCount <= maxCustomers)
            {
                if (prevSpots.Contains(randomSpot))
                {
                    randomSpot = Random.Range(0, movespots.Length - 2);
                    prevSpots.Enqueue(randomSpot);
                }


                Instantiate(customer, spawnPoint);
                customerCount++;

                gl.UpdateUI(0, customerCount);

                curTime = 0;


            }
        }
    }
}
