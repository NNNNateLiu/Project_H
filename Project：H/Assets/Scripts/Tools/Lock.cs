using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    //1，使用上下左右键调整数字
    //2，使用F键确认输入；使用Esc键退出输入

    public int correctCombination = 1234;

    //public int TestInt = 0;
    private int myInt;
    public int[] digitValues;
    public List<Text> digitText;
    public List<RectTransform> digitPointerTransform;
    public Text tips;

    private int currentDigit = 0;
    public GameObject digitPointer;

    public GameObject canmove;
    public GameObject door;
    public GameObject UI_Lock;
    public GameObject mask_layer;


    private void Start()
    {
        canmove.SetActive(false);
    }
    void Update()
    {
        if (gameObject.activeSelf is true)
        {
            canmove.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canmove.SetActive(true);
            gameObject.SetActive(false);

            tips.text = "enter the password...";
            tips.color = Color.white;

            digitText[0].text = "0";
            digitText[1].text = "0";
            digitText[2].text = "0";
            digitText[3].text = "0";
            digitValues[0] = 0;
            digitValues[1] = 0;
            digitValues[2] = 0;
            digitValues[3] = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentDigit == 0)
            {
                
            }
            else
            {
                currentDigit--;
                digitPointer.GetComponent<RectTransform>().position =
                    digitPointerTransform[currentDigit].GetComponent<RectTransform>().position;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentDigit == 3)
            {
                
            }
            else
            {
                currentDigit++;
                digitPointer.GetComponent<RectTransform>().position =
                    digitPointerTransform[currentDigit].GetComponent<RectTransform>().position;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (digitValues[currentDigit] == 9)
            {
                digitValues[currentDigit] = 0;
            }
            else
            {
                digitValues[currentDigit]++;
            }
            digitText[currentDigit].text = digitValues[currentDigit].ToString();
        }
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (digitValues[currentDigit] == 0)
            {
                digitValues[currentDigit] = 9;
            }
            else
            {
                digitValues[currentDigit]--;
            }
            digitText[currentDigit].text = digitValues[currentDigit].ToString();
        }

        //check the password
        if (Input.GetKeyDown(KeyCode.F))
        {
            myInt = digitValues[0]*1000+ digitValues[1] * 100+ digitValues[2] * 10+ digitValues[3];
            if(myInt == correctCombination)
            {
                //Debug.Log("correct!!!!!!");

                tips.text = "door is opened.";
                tips.color = Color.green;
                Destroy(UI_Lock);
                Destroy(door);
                Destroy(mask_layer);
}
            else 
            {
                tips.text = "wrong password!";
                tips.color = Color.red;
               // Debug.Log("no");
            }
        }
    }
    
}
