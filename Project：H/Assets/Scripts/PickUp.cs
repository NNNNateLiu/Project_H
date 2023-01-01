using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PickUp : MonoBehaviour
{
    public GameObject dialogIcon;
    public GameObject flowchart;

    public int scriptIntVar;
    public Flowchart flowchartTest;

    public GameObject currentTouchingItem;

    private bool canTalk;

    private void Start()
    {
        flowchartTest = flowchart.GetComponent<Flowchart>();
        //scriptIntVar = flowchartTest.GetIntegerVariable("flowchartIntVar");
        flowchartTest.SetIntegerVariable("flowchartIntVar", scriptIntVar);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //dialogIcon.SetActive(true);
        //canTalk = true;
        if (other.CompareTag("item"))
        {
            Debug.Log("Touch " + other.GetComponent<Item>().itemName);
            other.GetComponent<Item>().canBePickedUp = true;
            other.GetComponent<Item>().pickedUpIcon.SetActive(true);
            currentTouchingItem = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //dialogIcon.SetActive(false);
        //canTalk = false;
        if (other.CompareTag("item"))
        {
            Debug.Log("Not Touch " + other.GetComponent<Item>().itemName);
            other.GetComponent<Item>().canBePickedUp = false;
            other.GetComponent<Item>().pickedUpIcon.SetActive(false);
            currentTouchingItem = null;
        }
    }

    private void Update()
    {
        /*
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            flowchart.SetActive(true);
        }
        */
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTouchingItem == null)
            {
                
            }
            else
            {
                if (currentTouchingItem.GetComponent<Item>().canBePickedUp)
                {
                    currentTouchingItem.GetComponent<Item>().OnItemPickedUp();
                }
            }
        }
        
    }
}
