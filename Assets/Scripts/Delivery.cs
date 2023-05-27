using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision!!!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            Debug.Log(other.name + "Picked Up!");
        }
        else if (other.CompareTag("Customer"))
        {
            Debug.Log("Delivered to " + other.name);
        }
    }
}
