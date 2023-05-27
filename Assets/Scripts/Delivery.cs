using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.5f;
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);
    
    private bool hasPackage = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision!!!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
            Debug.Log(other.name + "Picked Up!");
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
            Debug.Log("Delivered to " + other.name);
        }
    }
}
