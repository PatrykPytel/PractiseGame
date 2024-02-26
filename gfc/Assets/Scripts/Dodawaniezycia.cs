using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodawaniezycia : MonoBehaviour
{
    public GameObject heart;
    [SerializeField] private Healthmanager health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            Destroy(heart);
            health.health +=1;
        }
    }
}
