using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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
    Resultbubble rbubble;

    public GameObject ResultBubble;
    

    public int orderNumber;
    public  ArrayList topfoods=new ArrayList();
    public string[] foodGiven;
    GameLoop gameManager;

    float time;


    GameLoop gameLoop;
    NavMeshAgent agent;
    #endregion

    public enum Food
    {
        Burger,Pizza,Salad
    }
    void Start()
    {
        thing = GetComponentInParent<CustomerSpawner>();
        movespot = thing.movespots;
        whereTo = thing.randomSpot;

        agent = GetComponent<NavMeshAgent>();
        waitTIme = startWaitTime;
        goAway = false;
        time = 120;

        gameLoop = GameLoop.Instance;

        chatbubble=Instantiate(chatbubble, bubblePoint);
        bubble = chatbubble.GetComponent<ChatB>();

        ResultBubble = Instantiate(ResultBubble, bubblePoint);
        Resultbubble rbubble = ResultBubble.GetComponent<Resultbubble>();
        ResultBubble.SetActive(false);


        // int food = UnityEngine.Random.Range(1, 3);
        int food = 1;

        switch (food)
        {
            case 1:
                foodSelection(Food.Burger);
                break;
            case 2:
                foodSelection(Food.Pizza);
                break;
            case 3:
                foodSelection(Food.Salad);
                break;
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
            thing.prevSpots.Dequeue();
            whereTo =movespot.Length-1;
        }
        //Debug.Log("I AM GOING "+ whereTo );
        if (Vector2.Distance(transform.position, movespot[whereTo].position) < .05f)
         {

             return;
         }
         else
         {
            agent.SetDestination(movespot[whereTo].position);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(movespot[whereTo].position.x, transform.position.y, movespot[whereTo].position.z), speed * Time.deltaTime);
        }
        
    }
    #endregion

    #region Compare function
    public void Result(bool result)
    {
        chatbubble.SetActive(false);
        ResultBubble.SetActive(true);
        if (result==true)
        {
            rbubble.SetUp(Resultbubble.RightWrong.Right);
        }
        else{
            rbubble.SetUp(Resultbubble.RightWrong.Wrong);
        }
        
         goAway = true;



    }
    #endregion
   void foodSelection(Food selection) {
        switch (selection)
        {
            default:
            case Food.Burger: 
                Burger();
                break;

            case Food.Pizza:
                Pizza();
                break;
            case Food.Salad:
                Salad();
                break;
        }

    }
    
void Burger()
    {
        orderNumber = UnityEngine.Random.Range(0, 2);
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
void Pizza()
    {

    }
void Salad()
    {

    }
    public void selfDestruct()
    {
        if(goAway==true){
            
            Destroy(this);
        }
        
    }
}

