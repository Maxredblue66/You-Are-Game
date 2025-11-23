using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private float MoveH;
    private float MoveV;

    public float speed;

    private bool isFacingRight;

    public Canvas myCanvas;
    private bool TL;
    private bool TR;
    private bool BL;
    private bool BR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        TR = false;
        TL = false;
        BR = false;
        BL = false;

    }

    // Update is called once per frame
    void Update()
    {

        MoveH = Input.GetAxisRaw("Horizontal");
        MoveV = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(MoveH * speed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, MoveV * speed);

        if (MoveH != 0 || MoveV !=0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if(!isFacingRight && MoveH > 0)
        {
            Flip();
        }else if(isFacingRight && MoveH < 0)
        {
            Flip();
        }

    }

    void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {
            if (TL == true)
            {
                SceneManager.LoadScene(2);
                Debug.Log("Interact TL");
            }
            else if (TR == true)
            {
                SceneManager.LoadScene(3);
                Debug.Log("Interact TR");
            }
            else if (BL == true)
            {
                SceneManager.LoadScene(4);
                Debug.Log("Interact BL");
            }
            else if (BR == true) 
            {
                SceneManager.LoadScene(5);
                Debug.Log("Interact BR");
            }
            else
            {
                Debug.Log("Interacting");
            }
                
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gob = collision.gameObject;

        if (gob.tag == "DoorTL")
        {
            myCanvas.enabled = true;
            TL = true;
            Debug.Log("Active1");
            Debug.Log(TL);
        }

        if (gob.tag == "DoorTR")
        {
            myCanvas.enabled = true;
            TR = true;
            Debug.Log("Active2");
            Debug.Log(TR);
        }

        if (gob.tag == "DoorBL")
        {
            myCanvas.enabled = true;
            BL = true;
            Debug.Log("Active3");
            Debug.Log(BL);
        }

        if (gob.tag == "DoorBR")
        {
            myCanvas.enabled = true;
            BR = true;
            Debug.Log("Active4");
            Debug.Log(BR);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myCanvas.enabled = false;
        TR = false;
        TL = false;
        BR = false;
        BL = false;
        Debug.Log("INActive");
        Debug.Log(TR);
        Debug.Log(TL);
        Debug.Log(BR);
        Debug.Log(BL);
    }
}
