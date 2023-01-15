using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("basic")]
    private Rigidbody2D rb2d;
    public float speed;
    public Animator animator;

    [Header("status")]
    public GameObject canMove;

    [Header("items")] 
    public bool isHaveTicket;
   

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        canMove.SetActive(true);
        rb2d.simulated = true;
    }
    
    private void Update()
    {
        if (canMove.activeSelf is true)
        {
            rb2d.simulated = true;
            speed = 0.5f ;

            //character running
            if (Input.GetKey(KeyCode.LeftShift ))
            {
                speed = 1f;
            }

            //activate animation
            animator.enabled = true;

            Move();
        }
        else //freeze character during interaction
        {
            rb2d.simulated = false;
            //disable animation
            animator.enabled = false;


        }
    }


    private void Move()
    {
        //player move function
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        //Debug.Log("horizontalInput: " +horizontalInput + "  " + "verticalInput: " + verticalInput);
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        rb2d.velocity = moveDirection * speed;

        // move animation
        //Left move
        if (horizontalInput < 0)
        {
            animator.SetBool("Left", true);
        }
        else 
        {
            animator.SetBool("Left", false);
        }

        //Right move
        if (horizontalInput > 0)
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }

        //Front move
        if (verticalInput < 0)
        {
            animator.SetBool("Front", true);
        }
        else
        {
            animator.SetBool("Front", false);
        }

        //Back move
        if (verticalInput > 0)
        {
            animator.SetBool("Back", true);
        }
        else
        {
            animator.SetBool("Back", false);
        }


        /*
        //play back animation
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Back", true); 
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Back", false);
        }


        //play right animation
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Right", true); 
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
        }
        */
    }
}

