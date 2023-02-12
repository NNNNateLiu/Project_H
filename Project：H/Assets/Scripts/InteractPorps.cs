using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPorps : MonoBehaviour
{
    public GameObject interactFlowchart;
    //public GameObject interactObject;
    private bool isWitninInteractRange;
    
    //靠近一定范围的时候，按F与物体交互，显示对话框，禁用移动

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("show tips");
            isWitninInteractRange = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("show tips");
            isWitninInteractRange = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isWitninInteractRange)
        {
            interactFlowchart.SetActive(true);
            //interactObject.SetActive(true);
        }
    }
}
