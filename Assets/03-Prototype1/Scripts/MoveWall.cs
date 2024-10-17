using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move ri
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move l
        }
    }
}
