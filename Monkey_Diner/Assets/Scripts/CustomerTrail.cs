using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrail : MonoBehaviour
{
    #region Shit ton Of variables
    public float speed;
    public bool goAway;
    public CustomerSpawner thing;
   
    private int whereTo;
    public GameObject chatbubble;
    public float waitTIme;
    public float startWaitTime;
    Transform[]  movespot;
    public Transform bubblePoint;
    ChatB bubble;

    public GameObject ResultBubble;
    

    public int orderNumber;
    public  string[] topfoods=new string[3];
    public string[] foodGiven;

    float time;


    GameLoop gameLoop;
    #endregion

    void Start()
    {
        thing = GetComponentInParent<CustomerSpawner>();
        movespot = thing.movespots;
        whereTo = thing.randomSpot;
        orderNumber = thing.orderNumber;

        waitTIme = startWaitTime;
        goAway = false;
        time = 120;

        gameLoop = GameLoop.Instance;

        chatbubble=Instantiate(chatbubble, bubblePoint);
        bubble = GetComponentInChildren<ChatB>();



        Debug.Log(orderNumber);
        if (orderNumber != 0)
        {
            bubble.SetUp(ChatB.IconType.Lettuce);
            topfoods[0] = "patty";
            topfoods[1] = "lettuce";
            topfoods[2] = "TopBun";
        }
        else
        {
            bubble.SetUp(ChatB.IconType.Cheese);
            topfoods[0] = "patty";
            topfoods[1] = "Cheese";
            topfoods[2] = "TopBun";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (time<=0)
        {
            goTo(movespot.Length-1);
        }
        else if(time>0)
        {
            goTo(whereTo);
            time -= Time.deltaTime;
        }
        
        
        

        
    }
    #region Movement for Customer
    public void goTo(int whereTo)
    {
        if (goAway)
        {
            whereTo =movespot.Length-1;
        }
        //Debug.Log("I AM GOING "+ whereTo );
        if (Vector2.Distance(transform.position, movespot[whereTo].position) < .05f)
        {
            
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movespot[whereTo].position.x, transform.position.y, movespot[whereTo].position.z), speed * Time.deltaTime);
        }
    }
    #endregion

    #region Compare function
    public bool Compare(string[] foodGave)
    {
        Debug.Log("THE COMPARE PART WORKS");
        for(int i=0;i<3;i++){

            Array.Sort(topfoods);
            Array.Sort(foodGave);
            Debug.Log(topfoods);
            Debug.Log(foodGave);
            if (topfoods[i]==foodGave[i])
            {
                
                continue;
            }
            else
            {

                chatbubble.SetActive(false);
                ResultBubble = Instantiate(ResultBubble, bubblePoint);


                gameLoop.UpdateUI(gameLoop.score, gameLoop.customerCount--);
                thing.customerCount--;
                goAway = true;
                return false;
            }
        }
        goAway = true;
        gameLoop.UpdateUI(gameLoop.score + 500, gameLoop.customerCount--);
        thing.customerCount--;
        ResultBubble = Instantiate(ResultBubble, bubblePoint);
        chatbubble.SetActive(false);
        return true;
    }
    #endregion
}

