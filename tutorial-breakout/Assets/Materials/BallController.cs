using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float maxVelocity = 1f;
    private float minY = -2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (transform.position.y < minY)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector2.zero;
        }
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick") ) {
            Destroy(collision.gameObject);
        }
    }
}
