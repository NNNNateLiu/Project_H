using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite itemSprite;
    public string itemName;
    public int itemValue;
    
    public bool canBePickedUp;
    public GameObject pickedUpIcon;

    public GameObject slotInBag;
    
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemSprite;
        pickedUpIcon.SetActive(false);
    }

    public void OnItemPickedUp()
    {
        Debug.Log(itemName + " Picked Up!");
        slotInBag.GetComponent<Image>().sprite = itemSprite;
        slotInBag.transform.GetChild(0).GetComponent<Text>().text = itemName;
        Destroy(gameObject);
    }
}
