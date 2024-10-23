using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject winTextObject;
    public GameObject instructionsObect;
    public GameObject Lava;
    public float highscore = 0;
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countUp;

    [Header("HighScore")]
    public TextMeshProUGUI highscoreTime;



    void Start()
    {
        //Reset();
        // Get and store the Rigidbody component attached to the player.
        winTextObject.SetActive(false);
        instructionsObect.SetActive(false);
    }

    void Awake()
    {
        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        { 
            highscore = PlayerPrefs.GetFloat("HighScore");
        }
        // Assign the high score to HighScore
        PlayerPrefs.SetFloat("HighScore", highscore);
    }

    void Update()
    {
        currentTime = countUp ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");
        highscoreTime.text = "Fastest Time: " + highscore.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        // when the trigger is hit by something
        // check to see if it's a Projectile 
        if (other.gameObject.tag == "Player")
        {
            enabled = false;
            if (currentTime < highscore)
            {
                PlayerPrefs.SetFloat("HighScore", currentTime);
            }
            else if (highscore == 0)
            {
                PlayerPrefs.SetFloat("HighScore", currentTime);
            }
            highscoreTime.text = "Fastest Time: " + highscore.ToString();
            // if so, set goalMet = true
            winTextObject.SetActive(true);
            instructionsObect.SetActive(true);

            // also set the alpha of the color of higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;

            Destroy(Lava);

            //SceneManager.LoadScene("SceneMain");
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscore = 0;
    }
}
