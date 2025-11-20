using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D rb;

    private float MoveH;
    private float MoveV;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveH = Input.GetAxisRaw("Horizontal");
        MoveV = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(MoveH * speed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, MoveV * speed);

    }
}
