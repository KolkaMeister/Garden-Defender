using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    HealthDisplay healthDisplay;
    void Start()
    {
        healthDisplay = FindObjectOfType<HealthDisplay>();
    }
    private void OnTriggerEnter2D(Collider2D collison)
    {
        healthDisplay.GetDamage();
        Destroy(collison.gameObject);
    }
    
}
