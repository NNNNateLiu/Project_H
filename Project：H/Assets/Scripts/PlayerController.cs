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
    private bool canAutoRightmove;
    private bool canAutoLeftmove;
    private bool canAutoFrontmove;
    private bool canAutoBackmove;
    private int automove;
    private float timer;

    [Header("items")] 
    public bool isHaveTicket;
   

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        canMove.SetActive(true);
        rb2d.simulated = true;
        animator.SetBool("isrunning", false);
        timer = 1f;
        canAutoRightmove = false;
        canAutoLeftmove = false;
        canAutoFrontmove = false;
        canAutoBackmove = false;
    }

    private void Update()
    {
        //Player Move
        if (canMove.activeSelf is true)
        {
            rb2d.simulated = true;
            speed = 0.5f;

            //character running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isrunning", true);
                speed = 1f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool("isrunning", false);
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



        //Player Auto Move    
        if (canAutoRightmove)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                automove = 4;
               // Debug.Log("havetime");
            }
            if (timer <= 0)
            {
                canAutoRightmove = false;
                timer = 1f;
                automove = 0;
                //Debug.Log("Timesup!");
            }
        }
        if (canAutoLeftmove)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                automove = 3;
               // Debug.Log("havetime");
            }
            if (timer <= 0)
            {
                canAutoLeftmove = false;
                timer = 1f;
                automove = 0;
               // Debug.Log("Timesup!");
            }
        }
        if (canAutoFrontmove)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                automove = 1;
               // Debug.Log("havetime");
            }
            if (timer <= 0)
            {
                canAutoFrontmove = false;
                timer = 1f;
                automove = 0;
                //Debug.Log("Timesup!");
            }
        }
        if (canAutoBackmove)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                automove = 2;
                //Debug.Log("havetime");
            }
            if (timer <= 0)
            {
                canAutoBackmove = false;
                timer = 1f;
                automove = 0;
                //Debug.Log("Timesup!");
            }
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
        //still
        if (horizontalInput == 0|| verticalInput==0 || automove == 0) ;
        {
            animator.SetInteger("MoveInt", 0);
        }

        //Left move
        if (horizontalInput < 0 || automove==3)
        {
            animator.SetInteger("MoveInt", 3);
        }
        

        //Right move
        if (horizontalInput > 0 || automove == 4)
        {
            animator.SetInteger("MoveInt", 4);
        }
        /*
        if (horizontalInput > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("MoveInt", -4);
        }*/

        //Front move
        if (verticalInput < 0 || automove == 1)
        {
            animator.SetInteger("MoveInt", 1);
        }
        /*
        if (verticalInput < 0 && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("MoveInt", -1);
        }*/

        //Back move
        if (verticalInput > 0 || automove == 2)
        {
            animator.SetInteger("MoveInt", 2);
        }
        /*
        if (verticalInput > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("MoveInt", -2);
        }*/
    }

    //automove method(conbined with area_noExplore function)
    public void Auto_right_move()
    {
        canAutoRightmove = true;
    }
    public void Auto_left_move()
    {
        canAutoLeftmove = true;
    }
    public void Auto_front_move()
    {
        canAutoFrontmove = true;
    }
    public void Auto_back_move()
    {
        canAutoBackmove = true;
    }

}

