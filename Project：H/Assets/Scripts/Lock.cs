using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    //1，使用上下左右键调整数字
    //2，使用F键确认输入；使用Esc键退出输入

    public int correctCombination = 1234;
    
    public int TestInt = 0;
    public int[] digitValues;
    public List<Text> digitText;
    public List<RectTransform> digitPointerTransform;

    private int currentDigit = 0;
    public GameObject digitPointer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
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
        
        if(Input.GetKeyDown(KeyCode.DownArrow))
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
    }
    
}
