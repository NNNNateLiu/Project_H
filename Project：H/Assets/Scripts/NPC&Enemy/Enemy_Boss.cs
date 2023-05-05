using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : MonoBehaviour
{
    [Header("basic")]
    public Animator Anim;
    public GameObject bulletPrefab;
    public float bossHP;
    public float currentHP;
    public float Timer;

    [Header("state")]
    public int state;
    public GameObject bulletAttack_1;
    public GameObject bulletAttack_2;

    [Header("vine")]
    public GameObject plantsPrefab_R;
    public GameObject plantsPrefab_L;
    public Transform minPos_L, maxPos_L;
    public Transform minPos_R, maxPos_R;
    public float GrowRate;

    [Header("bullet")]
    public Transform bulletPoint_01;
    public Transform bulletPoint_02;
    public Transform bulletPoint_03;
    public Transform bulletPoint_04;
    public Transform bulletPoint_05;
    public float FireRate;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        bulletAttack_1.SetActive(false);
        bulletAttack_2.SetActive(false);
        currentHP = bossHP;
        state = 0;
        Timer = FireRate;
    }

    void Update()
    {
        StateDetermine();
        BossState();

    }

    public void StateDetermine()
    {
        if (currentHP < bossHP && currentHP >= bossHP* 4 / 5)
        {
            state = 1;
        }

        if (currentHP < bossHP * 4 / 5 && currentHP >= bossHP * 3 / 5)
        {
            state = 3;
            bulletAttack_1.SetActive(true);
        }

        if (currentHP < bossHP * 3 / 5 && currentHP >= bossHP * 2 / 5)
        {
            state = 3;
            bulletAttack_1.SetActive(false);
            bulletAttack_2.SetActive(true);
        }

        if (currentHP < bossHP * 2 / 5 && currentHP >= bossHP * 1 / 5)
        {
            state = 1;
        }

        if (currentHP < bossHP * 1 / 5)
        {
            bulletAttack_2.SetActive(false);
            state = 2;
        }
    }


    public void BossState()
    {
        if (state == 3)
        {
            Anim.SetInteger("state", 3);
            if (bulletAttack_1.activeSelf is true)
            {
                //Generate 2 bullet
                Timer -= Time.deltaTime;
                if (Timer < 0)
                {
                    Timer = FireRate;
                    Instantiate(bulletPrefab, bulletPoint_02.position, Quaternion.identity);
                    Instantiate(bulletPrefab, bulletPoint_03.position, Quaternion.identity);
                }
                //
            }

            if (bulletAttack_2.activeSelf is true)
            {
                //Generate 3 bullets
                Timer -= Time.deltaTime;
                if (Timer < 0)
                {
                    Timer = FireRate;
                    Instantiate(bulletPrefab, bulletPoint_01.position, Quaternion.identity);
                    Instantiate(bulletPrefab, bulletPoint_04.position, Quaternion.identity);
                    Instantiate(bulletPrefab, bulletPoint_05.position, Quaternion.identity);
                }
                //
            }
        }

        if (state == 2)
        {
            Anim.SetInteger("state", 2);
        }

        if (state == 1)
        {
            Anim.SetInteger("state", 1);
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Timer = GrowRate;
                Instantiate(plantsPrefab_R, new Vector3(Random.Range(minPos_R.position.x, maxPos_R.position.x), Random.Range(minPos_R.position.y, maxPos_R.position.y), 0), Quaternion.identity);
                Instantiate(plantsPrefab_L, new Vector3(Random.Range(maxPos_L.position.x, minPos_L.position.x), Random.Range(minPos_L.position.y, maxPos_L.position.y), 0), Quaternion.identity);
                Debug.Log("generate");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player_attack")
        {
            currentHP--;
            Destroy(col.gameObject);
        }

    }
}