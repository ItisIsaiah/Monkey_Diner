using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
     XRController pause;
    float pressThreshold=0f;
    public InputHelpers.Button pauseButton;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pause)
            {
            this.gameObject.SetActive(CheckIfActivated());
        }
        
    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void ButtonHandler()
    {

        InputHelpers.IsPressed(pause.inputDevice, pauseButton, out bool isPressed, pressThreshold);
        
        //
        if (isPressed)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        
    }
    bool CheckIfActivated()
    {
        InputHelpers.IsPressed(pause.inputDevice, pauseButton, out bool isPressed, pressThreshold);
        return isPressed;
    }
}
