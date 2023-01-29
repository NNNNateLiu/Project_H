using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("basic")]
    public Sprite itemSprite;
    public string itemName;
    public int itemValue;
    
    [Header("logic")]
    public bool canBePickedUp;
    
    [Header("UI")]
    public GameObject pickedUpIcon;
    public GameObject slotInBag;
    public string description;
    public Sprite thumbnail;
    
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemSprite;
        pickedUpIcon.SetActive(false);
    }

    public void OnItemPickedUp()
    {
        //把item放到UI里
        Debug.Log(itemName + " Picked Up!");
        slotInBag.GetComponent<Image>().sprite = itemSprite;
        slotInBag.transform.GetChild(0).GetComponent<Text>().text = itemName;
        slotInBag.GetComponent<UIBagSlot>().isHaveItem = true;
        slotInBag.GetComponent<UIBagSlot>().itemInSlot = gameObject.GetComponent<Item>();
        //把item储存在玩家身上
        
        
        //销毁在地图上的item
        if (canBePickedUp)
        {
            Destroy(gameObject);
        }
    }
}
