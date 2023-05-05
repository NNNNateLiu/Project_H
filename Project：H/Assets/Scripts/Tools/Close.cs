using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject Flowchat;
    public GameObject canMove;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Flowchat.SetActive(false);
            canMove.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
