using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;




public class GameLoop : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI scoreText,timeText,customerText,endText;
    public CustomerSpawner spawner;
    public SceneManagerThing sceneManagerThing;
    //The actual trackers
    public int score;
    public float time = 60f;
    public int customerCount;
    public GameObject[] monkays;
    public Transform[] movespots;
    ArrayList occupied;
    
    #endregion

    #region SingleTon
    public static GameLoop Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        occupied.Add(-1);
        customerCount = 0;
        spawner = GetComponentInChildren<CustomerSpawner>();
        endText = FindObjectOfType<TextMeshProUGUI>();
        endText.text = "";
        StartCoroutine(StartOfGame());
        movespots = spawner.movespots;
    }

    // Update is called once per frame
    void Update()
    {
        if(time>0){
            time -= Time.deltaTime;
            timeText.text = "Time: " + (int)time / 60 + ":" + (int)time % 60;
        }
        else
        {
            StartCoroutine(EndOfGame());
            
        }
        #region monkeyMove
        if (time % 5 == 0&&customerCount<5)
        {
            spawnMonkay();
           
        }
        #endregion
    }

    public void UpdateUI(double score, double customerCount)
    {
        scoreText.text = "Score:" + score;

        customerText.text = "Customers:" + customerCount;
    }
    
        public IEnumerator StartOfGame()
        {
        Debug.Log("Started");
            yield return new WaitForSeconds(3f);
        spawnMonkay();
        Debug.Log("Should be Spawning");
        }
      
    public bool Compare(ArrayList foodGave,ArrayList foodhave)
    {
        Debug.Log("THE COMPARE PART WORKS");

        object[] obj1 = foodhave.ToArray();
        object[] obj2 = foodGave.ToArray();
        Array.Sort(obj1);
        Array.Sort(obj2);
        for (int i = 0; i < obj1.Length; i++)
        {
            if (foodhave[i] != foodGave[i])
            {
              UpdateUI(score-=100, customerCount--); 
                return false;
            }

        }
       UpdateUI(score += 500, customerCount--);
        return true;
    }



    public IEnumerator EndOfGame()
    {
        if (time <= 0) {
            endText.text = "TIMES UP";
            yield return new WaitForSeconds(2f);
            sceneManagerThing.LoadLosingScreen();
        }
        else
        {
            endText.text = "THE MONKEYS HAVE LEFT!";
            yield return new WaitForSeconds(2f);
            
        }
           

    }
    void spawnMonkay()
    {
        int randomSpot = UnityEngine.Random.Range(0, movespots.Length - 2);
        while (occupied.Contains(randomSpot))
        {
            randomSpot = UnityEngine.Random.Range(0, movespots.Length - 2);
        }
        occupied.Add(randomSpot);
        customerCount++;
        monkays[customerCount] = spawner.spawnMonkey();
        GameObject tempMonkey = monkays[customerCount];
        CustomerTrail tempMonkeyScript = tempMonkey.GetComponent<CustomerTrail>();
        tempMonkeyScript.moveHere = movespots[randomSpot];
    }

    
}
