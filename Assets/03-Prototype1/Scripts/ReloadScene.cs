using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadScene : MonoBehaviour
{
    public float speed = 1f;

    [Header("Set Dynamically")]
    public Text deathCount; // a
    void Start()
    {

        GameObject scoreGO = GameObject.Find("DeathCounter");

        deathCount = scoreGO.GetComponent<Text>();

        deathCount.text = "0";

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Heart"))
        {
            SceneManager.LoadScene("Main-Prototype 1");
            
            int score = int.Parse(deathCount.text); 
                                                 
            score += 1;
            // Convert the score back to a string and display it
            deathCount.text = score.ToString();
        }
    }

    void Update()
    {
        // Lava rises up
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
    }

}