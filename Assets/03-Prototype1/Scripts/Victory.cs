using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject winTextObject;
    public GameObject Lava;

    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        winTextObject.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        // when the trigger is hit by something
        // check to see if it's a Projectile 
        if (other.gameObject.tag == "Player")
        {
            // if so, set goalMet = true
            winTextObject.SetActive(true);

            // also set the alpha of the color of higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;

            Destroy(Lava);

            //SceneManager.LoadScene("SceneMain");
        }
    }
}
