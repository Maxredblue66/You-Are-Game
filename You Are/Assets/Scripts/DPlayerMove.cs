using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DPlayerMove : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private float MoveH;

    public float speed;

    private bool isFacingRight;

    public Canvas myCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        MoveH = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(MoveH * speed, rb.velocity.y);


        if (MoveH != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (!isFacingRight && MoveH > 0)
        {
            Flip();
        }
        else if (isFacingRight && MoveH < 0)
        {
            Flip();
        }

    }

    void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {

        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}