using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool YouDied= false;
    public GameObject GameOverUI;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (YouDied)
            Resume();
        }
        else
        {
            Pause();
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
}
