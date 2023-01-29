using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_noExplore : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public Vector2 Velocity;
    private float speed=9f;
    private float timer = 1f;
    public bool isLeft;
    public bool isRight;
    public bool isUp;
    public bool isDown;
    private bool invoke;

    void Start()
    {
        invoke = false;
    }

    void Update()
    {
        Velocity = rb2D.velocity;
        if (invoke)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                invoke = false;
                timer = 1f; //count down & reset timer
            }
            if (isLeft)
            {
                //area is on the left
                rb2D.AddForce(Vector2.right * speed);
                animator.SetInteger("MoveInt", 4);
            }
            if (isRight)
            {
                //area is on the right
                rb2D.AddForce(Vector2.left * speed);
            }
            if (isUp)
            {
                //area is on the upside
                rb2D.AddForce(Vector2.down * speed);

            }
            if (isDown)
            {
                //area is on the downside
                rb2D.AddForce(Vector2.up * speed);
            }
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Player detected
        if (col.gameObject.tag == "Player")
        {
            invoke = true;
            

        }
    }

}

