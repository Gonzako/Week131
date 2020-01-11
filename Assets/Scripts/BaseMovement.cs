using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;


    private Rigidbody2D rb;
    private Vector2 inputVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        if (inputVector.magnitude == 0) rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb.velocity = inputVector * speed;
        
    }



}
