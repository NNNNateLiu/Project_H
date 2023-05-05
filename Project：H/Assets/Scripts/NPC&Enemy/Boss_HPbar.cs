using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HPbar : MonoBehaviour
{
    public Slider HP;
    public GameObject boss;
    private void Start()
    {
        HP.maxValue = boss.GetComponent<Enemy_Boss>().bossHP;
        HP.value = HP.maxValue;
    }

    void Update()
    {
        HP.value = boss.GetComponent<Enemy_Boss>().currentHP;
    }
}
