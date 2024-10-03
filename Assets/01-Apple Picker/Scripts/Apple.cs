using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static float bottomY = -20f; // a
    void Update () {
        if ( transform.position.y < bottomY ) {
        Destroy( this.gameObject ); // b

        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); // b
        // Call the public AppleDestroyed() method of apScript
        apScript.AppleDestroyed(); // c
        }
    }
}
