using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    public Animator _animator;

    void Start()
    {
        CloseDoor();
    }

    void Update()
    {

    }


    //close the door after player leaving
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            CloseDoor();
        }
    }


    public void OpenDoor()
    {
        _animator.SetBool("isOpen", true);
    }

    public void CloseDoor()
    {
        _animator.SetBool("isOpen", false);
    }

}
