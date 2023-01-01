using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject bagPanel;
    public bool isBagPanelActive;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isBagPanelActive)
            {
                bagPanel.SetActive(false);
                isBagPanelActive = false;
            }
            else
            {
                bagPanel.SetActive(true);
                isBagPanelActive = true;
            }
        }

    }
}
