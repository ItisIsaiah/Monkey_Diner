using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrail : MonoBehaviour
{
    public float speed;
    public bool goAway;
    public CustomerSpawner thing;
    // private int randomSpot;
    private int whereTo;

    public float waitTIme;
    public float startWaitTime;
    Transform[]  movespot;
    // Start is called before the first frame update
    void Start()
    {
        thing = GetComponentInParent<CustomerSpawner>();
        movespot = thing.movespots;
        whereTo = thing.randomSpot;


        //  randomSpot = Random.Range(0, movespots.Length);
        waitTIme = startWaitTime;
        goAway = false;
        
        Debug.Log(movespot + "THIS IS MY STOOOLS");

        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movespot[whereTo].position.x,transform.position.y,movespot[whereTo].position.z), speed*Time.deltaTime);
        Debug.Log("I AM GOING "+ whereTo );
        if (Vector3.Distance(transform.position, movespot[whereTo].position) < 5f)
        {
            if (goAway)
            {
                
                whereTo = thing.movespots.Length-1;
            }
        }
    }
}
