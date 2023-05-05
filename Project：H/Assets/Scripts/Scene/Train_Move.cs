using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Move : MonoBehaviour
{
    public GameObject stop_position;
    private Rigidbody2D rb2d;
    private float speed;
    public Animator animator;
    public GameObject isCome;
    public GameObject isAddforce;
    private float timer;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        speed = 0.6f;
        isCome.SetActive(false);
        isAddforce.SetActive(false);
        timer = 7f;
    }
    void Update()
    {
        if (isCome.activeSelf is true)
        {
            Train_MovetoStop();
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                animator.SetBool("isMove", false);
                animator.SetBool("isOpendoor", true);
            }
        }

        if (isAddforce.activeSelf is true)
        {
            speed = 6f;
            Train_Addforce();
        }
    }


    public void Train_MovetoStop()
    {
        animator.SetBool("isOpendoor", false);
        //train start moving&animation
        animator.SetBool("isMove", true);
        Vector3 change = new Vector3(stop_position.transform.position.x - transform.position.x, stop_position.transform.position.y - transform.position.y, 0);
        transform.position = change * speed * Time.deltaTime + transform.position;
        //open the train door after 3s
       // Invoke(nameof(Train_OpenDoor), 3f);
    }

    public void Train_OpenDoor()
    {
        //Open the door
        animator.SetBool("isOpendoor", true);
    }

    public void Train_Addforce()
    {
        rb2d.velocity = Vector2.right * speed;
    }
}
