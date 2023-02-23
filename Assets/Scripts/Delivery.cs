using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool _hasVaccine; 
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("Ouch");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Vaccine") && !_hasVaccine)
        {
            _hasVaccine = true;
            Debug.Log("Vaccine picked up!");
        }
        else if (col.CompareTag("Patient") && _hasVaccine)
        {
            _hasVaccine = false;
            Debug.Log("Vaccine delivered to patient");
        }
        
    }
}