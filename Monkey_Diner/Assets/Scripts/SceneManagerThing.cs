﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerThing : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //loads the main menu and eventually will hold the load screen aswell into the game that is chosesn
    public void LLoadMainScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }
    //Loads the game over screen and will hold the things for you.
    public void LoadLosingScreen()
    {
        SceneManager.LoadScene("Game Over");
    }

    //Why is this project even open source I should really lock this up so no one steals my game

}
