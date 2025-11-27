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
    private float MoveV;

    public float speed;
    public float jump;

    private bool isFacingRight;
    private bool isGrounded;

    public Canvas myCanvas;
    public BoxCollider2D Door;
    public SpriteRenderer Book;
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
        MoveV = rb.velocity.y;

       


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

    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            anim.SetFloat("MoveV", 1);
            
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gob = collision.gameObject;

        if (gob.tag == "Hole")
        {

        }

        if (gob.tag == "Memory")
        {
            Debug.Log("Memory Acquired");
            Door.enabled = true;
            Book.enabled = false;
        }

        if (gob.tag == "Return")
        {
            Debug.Log("Time to go back");
        }
    }
}