using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public int damage;

    public GameObject Top;
    public GameObject Left;
    public GameObject Right;

    private CircleCollider2D poly2D;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //rb2d.AddForce(Vector2.down * speed);
        rb2d.velocity = Vector2.down * speed;
        if ( Top.activeSelf is true )
        {
            rb2d.velocity = Vector2.up * speed;
        }

        if (Left.activeSelf is true)
        {
            rb2d.velocity = Vector2.left * speed;
        }

        if (Right.activeSelf is true)
        {
            rb2d.velocity = Vector2.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "AirWall")
        {
            Debug.Log("hit the wall");
            //destry bullet
            Destroy(gameObject);
        }

        //bullet hit the enemy
        {
            if (col.gameObject.tag == "Enemy")
            {
                Debug.Log("hit the enemy");
                //destry bullet & enemy
                Destroy(gameObject);
                Destroy(col.gameObject);
            }

        }
    }
}
