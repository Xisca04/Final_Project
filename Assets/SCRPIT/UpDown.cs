using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    // To elevate the plataforms

    float speed = 0.1f;
    float height = 2f;
    float startY = 2f;

    void Update()
    {
        var pos = transform.position;
        var newY = startY + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
