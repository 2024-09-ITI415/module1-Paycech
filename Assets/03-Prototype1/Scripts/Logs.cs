using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
 }