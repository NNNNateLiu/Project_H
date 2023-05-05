using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletposition : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Animator bulletAnim;

    public Transform bulletPoint_T;
    public Transform bulletPoint_B;
    public Transform bulletPoint_L;
    public Transform bulletPoint_R;
    public GameObject Top;
    public GameObject Left;
    public GameObject Right;

    public Rigidbody2D rb2d;
    public float speed=3f;


    void Start()
    {
        rb2d = bulletPrefab.GetComponent<Rigidbody2D>();
    }


    public void Topbullet()
    {
        Top.SetActive(true);
        Instantiate(bulletPrefab, bulletPoint_T.position, Quaternion.identity);
    }
    public void Bottombullet()
    {
        Instantiate(bulletPrefab, bulletPoint_B.position, Quaternion.identity);
    }
    public void Leftbullet()
    {
        Left.SetActive(true);
        Instantiate(bulletPrefab, bulletPoint_L.position, Quaternion.identity);
    }
    public void Rightbullet()
    {
        Right.SetActive(true);
        Instantiate(bulletPrefab, bulletPoint_R.position, Quaternion.identity);
    }

    public void Rest()
    {
        Top.SetActive(false);
        Right.SetActive(false);
        Left.SetActive(false);
    }
}
