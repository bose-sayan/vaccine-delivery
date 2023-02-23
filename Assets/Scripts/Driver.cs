using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] private float slowSpeed = 20f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float rotateSpeed = 200f;

    void Start()
    {
        moveSpeed = 30f;
        rotateSpeed = 300f;
    }

    void Update()
    {
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotateAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Boost"))
        {
            Debug.Log("Zoooom!");
            moveSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Ouch!");
        moveSpeed = slowSpeed;
    }
}