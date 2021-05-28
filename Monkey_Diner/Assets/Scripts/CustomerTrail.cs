using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrail : MonoBehaviour
{
    public float speed;
    public bool goAway;
    public CustomerSpawner thing;
   
    private int whereTo;
    public Object chatbubble;
    public float waitTIme;
    public float startWaitTime;
    Transform[]  movespot;
    public Transform bubblePoint;
    ChatB bubble;

    public int orderNumber;



    



    void Start()
    {
        thing = GetComponentInParent<CustomerSpawner>();
        movespot = thing.movespots;
        whereTo = thing.randomSpot;
        orderNumber = thing.orderNumber;

        //  randomSpot = Random.Range(0, movespots.Length);
        waitTIme = startWaitTime;
        goAway = false;




        Instantiate(chatbubble, bubblePoint);
        bubble = GetComponentInChildren<ChatB>();

        Debug.Log(orderNumber);
        if (orderNumber != 0)
        {
            bubble.SetUp(ChatB.IconType.Lettuce);
        }
        else
        {
            bubble.SetUp(ChatB.IconType.Cheese);
        }

    }

    // Update is called once per frame
    void Update()
    {
        


        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movespot[whereTo].position.x,transform.position.y,movespot[whereTo].position.z), speed*Time.deltaTime);
        //Debug.Log("I AM GOING "+ whereTo );
        if (Vector3.Distance(transform.position, movespot[whereTo].position) < 5f)
        {
            if (goAway)
            {
                
                whereTo = thing.movespots.Length-1;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    
}
