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
    public Transform moveHere;
    #endregion

  
    void Start()
    {
   
        
        agent = GetComponent<NavMeshAgent>();
      
        goAway = false;
        time = 120;

        gameLoop = GameLoop.Instance;

        chatbubble=Instantiate(chatbubble,bubblePoint);
        bubble = chatbubble.GetComponent<ChatB>();

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
    }

    #region Movement for Customer
    public void goTo(int whereTo)
    {    
        if (Vector2.Distance(transform.position, moveHere.position) < .05f)
         {
            transform.LookAt(moveHere);     
         }
        else {         
            agent.SetDestination(moveHere.position);
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
               }
        else{
            Instantiate(cross, bubblePoint);          
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

