using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : MonoBehaviour
{
    public Image Img_HP_Icon;
    public Image[] Img_HP_Bars;
    public RectTransform Img_HP_Bar_BG;
    
    public Sprite HP_Icon_Blue;
    public Sprite HP_Icon_Yellow;
    public Sprite HP_Icon_Red;
    public Sprite HP_Bar_Blue;
    public Sprite HP_Bar_Yellow;
    public Sprite HP_Bar_Red;
    
    public GameObject player;

    private void Start()
    {
    }

    public void OnHPChange()
    {
        for (int i = 0; i < Img_HP_Bars.Length; i++)
        {
            if (i >= player.GetComponent<Player_HP>().CurrentHP)
            {
                Img_HP_Bars[i].gameObject.SetActive(false);
            }
            else
            {
                Img_HP_Bars[i].gameObject.SetActive(true);
            }
        }
        
        //修改生命值背景条长度
        float tempX = 1 - (6 - player.GetComponent<Player_HP>().CurrentHP) * 0.15f;
        Img_HP_Bar_BG.localScale = new Vector3(tempX, 1, 1);
        
        //当玩家生命值 > 3
        if (player.GetComponent<Player_HP>().CurrentHP > 3)
        {
            Img_HP_Icon.sprite = HP_Icon_Blue;
            foreach (var bar in Img_HP_Bars)
            {
                bar.sprite = HP_Bar_Blue;
            }
        }
        else
        {
            //当玩家生命值 = 3
            if (player.GetComponent<Player_HP>().CurrentHP == 3)
            {
                Img_HP_Icon.sprite = HP_Icon_Yellow;
                foreach (var bar in Img_HP_Bars)
                {
                    bar.sprite = HP_Bar_Yellow;
                }
            }
            //当玩家生命值 < 3
            else
            {
                Img_HP_Icon.sprite = HP_Icon_Red;
                foreach (var bar in Img_HP_Bars)
                {
                    bar.sprite = HP_Bar_Red;
                }
            }
        }
    }
}
