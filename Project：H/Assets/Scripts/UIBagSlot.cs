using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBagSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite defaultSpriteBG;
    public bool isHaveItem;
    public Item itemInSlot;

    private Image img_Thumbnail;
    private Text txt_Name;
    private Text txt_Description;
    public GameObject intro_BG;

    private void Start()
    {
        img_Thumbnail = GameObject.Find("Img_Thumbnail").GetComponent<Image>();
        txt_Name = GameObject.Find("Txt_Name").GetComponent<Text>();
        txt_Description = GameObject.Find("Txt_Description").GetComponent<Text>();
        intro_BG.SetActive(false);

    }

    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        Debug.Log(name + "Game Object Click in Progress");
        
        if(isHaveItem)
        {
            img_Thumbnail.sprite = itemInSlot.thumbnail;
            txt_Name.text = itemInSlot.name;
            txt_Description.text = itemInSlot.description;
            intro_BG.SetActive(true);
        }
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log(name + "No longer being clicked");
    }

    public void RemoveItemFromSlot()
    {
        GetComponent<Image>().sprite = defaultSpriteBG;
        transform.GetChild(0).GetComponent<Text>().text = "";
        isHaveItem = false;
        itemInSlot = null;
    }
}
