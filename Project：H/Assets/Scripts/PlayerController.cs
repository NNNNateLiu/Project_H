using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        Move();
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

