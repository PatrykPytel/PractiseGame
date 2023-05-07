using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIsOver : MonoBehaviour
{
    public static bool YouDied= false;
    public GameObject GameOverUI;
    public Healthmanager script;
    void Start()
    {
    
    }
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (script.health==0)
        {
            Pause();
          //  if (YouDied==true)
            //{
              //  Resume();
            //}
            //el/se
            //{
              //  Pause();
            //}
            
        }

    }
    void Resume()
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        YouDied = false;


    }
    void Pause()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        YouDied = true;

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
