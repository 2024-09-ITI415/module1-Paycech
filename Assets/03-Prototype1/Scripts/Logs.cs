using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleEnemy : MonoBehaviour
{
    public static float bottomY = 48f; // a
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject); // b
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Main-Prototype 1");
        }
    }
 }