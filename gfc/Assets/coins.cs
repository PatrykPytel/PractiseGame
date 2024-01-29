using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    public GameObject coin;
    public GameObject canvas;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            canvas.GetComponent<ScoreManager>().Score();
            Destroy(coin);
        }
    }
}
