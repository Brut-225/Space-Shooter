using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed = 5.0f;
    public float Acceleration = 25.0f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = rb.velocity;
        velocity.y += Acceleration * Time.deltaTime;
        rb.velocity = velocity;
    }
}
