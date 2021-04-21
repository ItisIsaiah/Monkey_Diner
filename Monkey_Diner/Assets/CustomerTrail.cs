using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrail : MonoBehaviour
{
    public float speed;

    public Transform[] movespots;
    public Transform door;
    public bool goAway;
    private int randomSpot;

    public float waitTIme;
    public float startWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, movespots.Length);
        waitTIme = startWaitTime;
        goAway = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movespots[randomSpot].position.x,transform.position.y, movespots[randomSpot].position.z), speed*Time.deltaTime);
        if(Vector3.Distance(transform.position, movespots[randomSpot].position) < 0.2f)
        {
            if (goAway)
            {
                
                randomSpot = movespots.Length-1;
            }
        }
    }
}
