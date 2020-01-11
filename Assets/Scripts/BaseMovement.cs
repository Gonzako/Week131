using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Vector2 inputVector;

    private void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        transform.Translate(inputVector * speed * Time.fixedDeltaTime);
    }



}
