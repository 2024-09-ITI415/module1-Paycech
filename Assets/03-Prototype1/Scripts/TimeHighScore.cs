using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHighScore : MonoBehaviour
{
    static public int score = 0;

    void Awake()
    { // a
        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        { // b
            score = PlayerPrefs.GetInt("HighScore");
        }
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", score); // c
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Fastest Time: " + score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        { // d
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
