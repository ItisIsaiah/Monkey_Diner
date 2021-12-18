using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class GameLoop : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI customerText;
    public TextMeshProUGUI endText;
    
    public SceneManagerThing sceneManagerThing;
    //The actual trackers
    public int score;
    public float time = 60f;
    public int customerCount;
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
       
        endText = FindObjectOfType<TextMeshProUGUI>();
        endText.text = "";
        
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
        
    }

    public void UpdateUI(double score, double customerCount)
    {
        scoreText.text = "Score:" +score;

        customerText.text = "Customers:" + customerCount;
    }
/*
    public IEnumerator StartOfGame()
    {
        float countdown = 3;
        while (countdown>0) {
            countdown -= Time.deltaTime;
            scoreText.text = "READY?"+countdown;
                }
        
        yield return new WaitForSeconds(3f);

    }
  */
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

    
}
