using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogtrigger trigger;

    public void OnCollisionEnter2D(Collision2D coll) { 
        if ( coll.gameObject.CompareTag("Player")== true) { 
            trigger.StartDialog();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
