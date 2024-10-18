using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadScene : MonoBehaviour
{
    public float speed = 1f;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Heart"))
        {
            SceneManager.LoadScene("Main-Prototype 1");
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