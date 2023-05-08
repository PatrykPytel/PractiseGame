using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthmanager : MonoBehaviour
{
    void Start()
    {
        
    }
    public int health;
    public Image[] hearts;
    public Sprite pelneserce;
    public Sprite pusteserce;
    public bool enemyIsClose;
    public GameObject Huj1;
    public GameObject Huj2;
    


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
        if (enemyIsClose)
        {
            Debug.Log(health);
            health-=2;
            Physics2D.IgnoreCollision(Huj1.GetComponent<Collider2D>(), Huj2.GetComponent<Collider2D>());
            

            
            
            
        }

         

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            enemyIsClose = true;
            
        }
    }   

    
}
