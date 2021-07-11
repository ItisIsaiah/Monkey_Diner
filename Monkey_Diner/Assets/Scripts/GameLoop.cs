using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class GameLoop : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Text customerText;
    public TextMeshProUGUI endText;
    public SceneManagerThing sceneManagerThing;
    //The actual trackers
    public int score;
    public float time = 60f;
    public int customerCount;


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
