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
    
    public float recoilForce;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        
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

        AddRecoilImpulse();
    }


    void Update()
    {
        
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
    
    void AddRecoilImpulse()
    {
        Rigidbody2D playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        
        Vector2 recoilDirection = Vector2.up;
        if (Top.activeSelf)
        {
            recoilDirection = Vector2.down;
        }
        else if (Left.activeSelf)
        {
            recoilDirection = Vector2.right;
        }
        else if (Right.activeSelf)
        {
            recoilDirection = Vector2.left;
        }

        playerRB.AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);
    }
}
