using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openchest : MonoBehaviour
{
    public bool isclose;
    public bool opened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((isclose == true) && (Input.GetKeyDown(KeyCode.E))) {
            opened = true;
        }else if(opened == true && Input.GetKeyDown(KeyCode.E)) {
            opened = false;
        } else if(isclose == false) {
           opened = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            isclose = true;
    }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isclose = false;
        }
    }
    
}
