using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRB2D;
    public float bulletSpeed;
    private void Start()
    {
        bulletRB2D = gameObject .GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        bulletRB2D.AddForce(Vector2.down * bulletSpeed);
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        //destry bullet when hit the border
        if (col.gameObject.tag == "AirWall" || col.gameObject.tag == "determine")
        {
            Destroy(gameObject);
        }
        //
    }
}
