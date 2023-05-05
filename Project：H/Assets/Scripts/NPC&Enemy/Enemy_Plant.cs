using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Plant : MonoBehaviour
{
    public Collider2D area;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        area = gameObject.GetComponent<Collider2D>();
        Anim.SetBool("isAttack", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "determine")
        {
            Debug.Log("start attack");
            Anim.SetBool("isAttack", true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "determine")
        {
            Debug.Log("stop");
            Anim.SetBool("isAttack", false);
        }
    }
}
