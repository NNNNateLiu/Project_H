using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject bagPanel;
    public GameObject canMove;
    public bool isBagPanelActive;

    // Update is called once per frame
    void Start()
    {
        bagPanel.SetActive(false);
        isBagPanelActive = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isBagPanelActive)
            {
                bagPanel.SetActive(false);
                isBagPanelActive = false;
                canMove.SetActive(true);
            }
            else
            {
                bagPanel.SetActive(true);
                isBagPanelActive = true;
                canMove.SetActive(false);
            }
        }

    }
}
