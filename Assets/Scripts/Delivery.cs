using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool _hasVaccine;
    [SerializeField] private Color32 hasPackageColor = new Color32(243, 104, 26, 255);
    [SerializeField] private Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] private float destructionDelay = 0.05f;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("Ouch");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Vaccine") && !_hasVaccine)
        {
            _hasVaccine = true;
            Destroy(col.gameObject, destructionDelay);
            Debug.Log("Vaccine picked up!");
            _spriteRenderer.color = hasPackageColor;
        }
        else if (col.CompareTag("Patient") && _hasVaccine)
        {
            _hasVaccine = false;
            Debug.Log("Vaccine delivered to patient");
            _spriteRenderer.color = noPackageColor;
        }
    }
}