using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slime"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage();
        }

        if (other.gameObject.CompareTag("Turtle Shell"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamageTurtle();
        }
    }
}
