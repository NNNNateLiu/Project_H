using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    public Transform topRightBorder;
    public Transform bottomLeftBorder;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 nextFrameCamPos = new Vector3();
        nextFrameCamPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        if (nextFrameCamPos.x > topRightBorder.position.x)
        {
            nextFrameCamPos.x = topRightBorder.position.x;
        }

        if (nextFrameCamPos.y > topRightBorder.position.y)
        {
            nextFrameCamPos.y = topRightBorder.position.y;
        }
        
        if (nextFrameCamPos.x < bottomLeftBorder.position.x)
        {
            nextFrameCamPos.x = bottomLeftBorder.position.x;
        }

        if (nextFrameCamPos.y < bottomLeftBorder.position.y)
        {
            nextFrameCamPos.y = bottomLeftBorder.position.y;
        }

        transform.position = nextFrameCamPos;


    }
}
