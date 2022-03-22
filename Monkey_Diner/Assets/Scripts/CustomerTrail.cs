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
    CustomerSpawner thing;

    private int whereTo;
    Transform[] movespot;

    public GameObject chatbubble;
    public GameObject ResultBubble;
    public Transform bubblePoint;
    ChatB bubble;
    //Resultbubble rbubble;
    
    [SerializeField]
    GameObject check;
    [SerializeField]
    GameObject cross;
    
    
    

    public int orderNumber;
    public  ArrayList topfoods=new ArrayList();
    public string[] foodGiven;
    GameLoop gameManager;

    float time;


    GameLoop gameLoop;
    NavMeshAgent agent;
    #endregion

  
    void Start()
    {
        thing = GetComponentInParent<CustomerSpawner>();
        movespot = thing.movespots;
        whereTo = thing.randomSpot;

        agent = GetComponent<NavMeshAgent>();
      
        goAway = false;
        time = 120;

        gameLoop = GameLoop.Instance;

        chatbubble=Instantiate(chatbubble, bubblePoint);
        bubble = chatbubble.GetComponent<ChatB>();

       // ResultBubble = Instantiate(ResultBubble, bubblePoint);
       // Resultbubble rbubble = ResultBubble.GetComponent<Resultbubble>();
       // ResultBubble.SetActive(false);


        // int food = UnityEngine.Random.Range(1, 3);
       // int food = 1;

        

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
            Instantiate(check,bubblePoint);
            /*rbubble.SetUp(Resultbubble.RightWrong.Right);*/
        }
        else{
            Instantiate(cross, bubblePoint);
            /*rbubble.SetUp(Resultbubble.RightWrong.Wrong);*/
        }
        
         goAway = true;
        


    }
    #endregion
  

    void Burger()
    {
        orderNumber = UnityEngine.Random.Range(4, 6);

        bubble.CreateOrderSheet(orderNumber);


    }
    

     public void selfDestruct()
    {
        if(goAway==true){
            
            Destroy(this);
        }
        
    }
}

