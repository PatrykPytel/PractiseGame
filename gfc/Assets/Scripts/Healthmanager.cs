using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthmanager : MonoBehaviour
{
    public int health;
    public Image[] hearts;
    public Sprite pelneserce;
    public Sprite pusteserce;

    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = pusteserce;
        }
        for (int i=0; i<health;i++)
        {
            hearts[i].sprite = pelneserce;
        }

    }
}
