using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagerThing : MonoBehaviour
{

#region singleton
    public static SceneManagerThing instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public int sceneSelection { get; set; } = 0;
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressBar;

    // Start is called before the first frame update
    private void Start()
    {
        loadingScreen.SetActive(false);
    }
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

    public void LoadSelectedScene()
    {
        LoadLevel(sceneSelection);

    }


    public void LoadSceneDropdown(int val)
    {
        SceneManager.LoadScene(val);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsyncron(sceneIndex));
       
    }
    IEnumerator LoadAsyncron(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneSelection+1);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressBar.text =progress*100f+"%";
            yield return null;
        }
    }
    
}
