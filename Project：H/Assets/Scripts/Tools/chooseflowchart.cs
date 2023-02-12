using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseflowchart : MonoBehaviour
{
    public GameObject choose2;
    public GameObject flowchart1;
    public GameObject flowchart2;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(choose2.activeSelf is true)
        {
            flowchart1.SetActive(false);
            flowchart2.SetActive(true);
        }
        else
        {
            flowchart1.SetActive(true);
            flowchart2.SetActive(false);
        }
    }
}
