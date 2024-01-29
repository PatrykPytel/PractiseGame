using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }
    public void Score() {
        score +=1;
        scoreText.text = score.ToString() + " POINTS";
    }

    // Update is called once per frame

  //  private void Awake() { 
     //   scoreText = GetComponent<TMP_Text>();
  //  }
    
    
}
