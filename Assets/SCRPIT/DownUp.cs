using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownUp : MonoBehaviour
{
    // To elevate the plataforms

    float speed = 0.4f;
    float height = 2f;
    float startY = 5f;

    void Update()
    {
        var pos = transform.position;
        var newY = startY + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
