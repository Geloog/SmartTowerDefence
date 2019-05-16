﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager1 : MonoBehaviour
{

    protected List<wave> waves = new List<wave>();

    bool ready = false;

    protected float lastCreateTime;
    int enemyCreated = 0;
    int count = 0;
    wave curWave;

    public Button startButton;
    public Transform enemyBase;
    public Transform Base;
    public GameObject Enemy;
    public GameObject Quick;
    public Image levelClear;

    protected class wave
    {
        public int amount = 5;
        public float space = 1;
        public GameObject enemy;
        public wave(int am, float sp, GameObject en)
        {
            amount = am;
            space = sp;
            enemy = en;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastCreateTime = Time.time;
        waves.Add(new wave(5, 1, Enemy));
        waves.Add(new wave(10, 1, Enemy));
        waves.Add(new wave(15, 1, Enemy));
    }

    // Update is called once per frame
    void Update()
    {
        if(ready)
        {
            if(enemyCreated < curWave.amount && Time.time - lastCreateTime > curWave.space)
            {
                CreateEnemy(curWave.enemy);
                lastCreateTime = Time.time;
                enemyCreated++;
            }
            else if(enemyCreated >= curWave.amount && count == 0)
            {
                startButton.gameObject.SetActive(true);
                ready = false;
                waves.RemoveAt(0);
                enemyCreated = 0;
            }
        }

        if (count == 0 && waves.Count == 0)
            levelClear.gameObject.SetActive(true);
    }

    public void Ready()
    {
        if (waves.Count>0)
        {
            ready = true;
            startButton.gameObject.SetActive(false);
            curWave = waves[0];
        }
    }

    void CreateEnemy(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(enemyBase.transform.position.x, enemy.transform.position.y, enemyBase.transform.position.z), Quaternion.identity).GetComponent<Enemy>().EnemyDead += OnEnemyDead;
        count++;
    }

    void OnEnemyDead(Transform tr)
    {
        count--;
    }
}