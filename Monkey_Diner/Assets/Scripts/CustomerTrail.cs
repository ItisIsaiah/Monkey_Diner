using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrail : MonoBehaviour
{
    public float speed;

    public Transform[] movespots;
    public Door door;
    public Transform doorTransform;
    public Barstools barstools;
    public bool goAway;
    private int randomSpot;

    public float waitTIme;
    public float startWaitTime;

    // Start is called before the first frame update
    void Start()
    {
      


        movespots= barstools.allchildren;
        doorTransform = door.doorPoint;
        randomSpot = Random.Range(0, movespots.Length);
        waitTIme = startWaitTime;
        goAway = false;
        movespots[movespots.Length - 1] = doorTransform;
        Debug.Log(movespots.Length + "THIS IS MY STOOOLS");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movespots[randomSpot].position.x,transform.position.y, movespots[randomSpot].position.z), speed*Time.deltaTime);
        Debug.Log("I AM GOING "+ randomSpot );
        if (Vector3.Distance(transform.position, movespots[randomSpot].position) < 5f)
        {
            if (goAway)
            {
                
                randomSpot = movespots.Length-1;
            }
        }
    }
}
