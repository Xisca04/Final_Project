using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    // Sword detect enemies

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slime") || other.gameObject.CompareTag("Turtle Shell"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage();
        }

    }
}
