using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public int MaxHP = 6;
    public int CurrentHP = 6;
    public GameObject UIHPBar;
    public GameObject activateHP;

    private void Start()
    {
        UIHPBar.SetActive(false);
    }
    private void Update()
    {
        if (activateHP.activeSelf is true)
        {
            UIHPBar.SetActive(true);
        }
        else
        {
            UIHPBar.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy_hurt")
        {
            CurrentHP--;
            UIHPBar.GetComponent<UIHPBar>().OnHPChange();
        }
    }
}
