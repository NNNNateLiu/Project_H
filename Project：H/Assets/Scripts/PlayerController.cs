using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("basic")]
    private Rigidbody2D rb2d;
    public float speed;

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
            speed = 1;
            if(Input.GetKey(KeyCode.LeftShift )) //character running
            {
                speed = 1.5f;
            }
            Move();
        }
        else //freeze character during interaction
        {
            rb2d.simulated = false;
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
    }
}

