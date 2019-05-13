﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public enum attackMode { firstIn, random, leastHP, canKillOnly }

    public GameObject arrow;
    public Transform shootingPoint;
    public List<Transform> enemiesInRange;
    public float shootingSpace = 1;           //射击间隔时间

    public attackMode mode;

    //测试用
    //int count = 1;

    private float LastShotTime;

    // Start is called before the first frame update
    void Start()
    {
        LastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastShotTime > shootingSpace && enemiesInRange.Count > 0)
        {
            LastShotTime = Time.time;
            ShootAt(enemiesInRange[0]);
        }
    }

    void ShootAt(Transform enemy)
    {
        //Debug.Log(enemy);
        Instantiate(arrow, shootingPoint.position, Quaternion.identity).GetComponent<FlyingArrow>().target = enemy;
    }

    void OnEnemyDead(Transform enemy)
    {
        enemiesInRange.Remove(enemy);
        /*Debug.Log("EnemyDead!");
        Debug.Log(enemiesInRange.Count);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            enemiesInRange.Add(other.transform);
            /*Debug.Log("Enter!");
            Debug.Log(enemiesInRange.Count);*/
            other.gameObject.GetComponent<Enemy>().EnemyDead += OnEnemyDead;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            enemiesInRange.Remove(other.transform);
            /*Debug.Log("Exit!");
            Debug.Log(enemiesInRange.Count);*/
            other.gameObject.GetComponent<Enemy>().EnemyDead -= OnEnemyDead;
        }
    }

    public void setMode(int m)
    {
        mode = (attackMode)m;
    }
}
