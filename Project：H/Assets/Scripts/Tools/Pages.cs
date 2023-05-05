using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pages : MonoBehaviour
{
    public int currentDigit = 0;
    public List<Image> pageImage;
    public Image current_page;

    public GameObject canmove;
    public GameObject pages;
    public GameObject tips; 
    void Start()
    {
        current_page = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pages.activeSelf is true)
        {
            canmove.SetActive(false);
        }
        else
        {
            tips.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(tips);
            if (currentDigit == 2)
            {
                currentDigit = 0;
            }
            else
            {
                currentDigit++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Destroy(tips);
            if (currentDigit == 0)
            {
                currentDigit = 2;

            }
            else
            {
                currentDigit--;
            }
        }


        //show curentDigit image
        current_page.sprite = pageImage[currentDigit].sprite;

    }
}
