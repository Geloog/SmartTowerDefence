﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Slider HPBar;
    public delegate void EnemyDeadHandler(Transform enemy);
    public EnemyDeadHandler EnemyDead;
    public int maxHP = 100, curHP = 100;
    public int reward = 50;

    // Start is called before the first frame update
    void Start()
    {
        HPBar.GetComponent<RectTransform>().localScale = new Vector3(HPBar.GetComponent<RectTransform>().localScale.x * ((float)maxHP/100), HPBar.GetComponent<RectTransform>().localScale.y, HPBar.GetComponent<RectTransform>().localScale.z);
        HPBar.value = (float)curHP / (float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.transform.LookAt(Camera.main.transform.position);
    }

    private void OnDestroy()
    {
        EnemyDead?.Invoke(transform);
    }

    public void takeDamage(int damage)
    {
        curHP -= damage;
        if (curHP > 0)
            HPBar.value = (float)curHP / (float)maxHP;
        else
        {
            GameObject.Find("GameManager").GetComponent<UIDataManager>().gainGold(reward);
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage, GameObject bullet)
    {
        curHP -= damage;
        if (curHP > 0)
            HPBar.value = (float)curHP / (float)maxHP;
        else
        {
            if (bullet.name == "KillerBullet(Clone)")
                bullet.GetComponent<KillerBullet>().parent.GetComponent<KillerShooting>().RefreshAttack();
            GameObject.Find("GameManager").GetComponent<UIDataManager>().gainGold(reward);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Base")
        {
            Destroy(gameObject);
            GameObject.Find("GameManager").GetComponent<UIDataManager>().loseHP(1);
        }
    }
}
