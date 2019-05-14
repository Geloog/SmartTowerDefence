using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    List<wave> waves = new List<wave>();

    bool ready = false;

    float lastCreateTime;
    int enemyCreated = 0;
    int count = 0;
    wave curWave;

    public Button startButton;
    public Transform enemyBase;
    public Transform Base;
    public GameObject Enemy;
    public Image levelClear;

    class wave
    {
        public int amount = 5;
        public float space = 1;
        //GameObject enemy;     //TODO
        public wave(int am,float sp)
        {
            amount = am;
            space = sp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastCreateTime = Time.time;
        waves.Add(new wave(5, 1));
        waves.Add(new wave(10, 1));
        waves.Add(new wave(15, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if(ready)
        {
            if(enemyCreated < curWave.amount && Time.time - lastCreateTime > curWave.space)
            {
                CreateEnemy();
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

    void CreateEnemy()
    {
        Instantiate(Enemy, enemyBase.transform.position, Quaternion.identity).GetComponent<Enemy>().EnemyDead += OnEnemyDead;
        count++;
    }

    void OnEnemyDead(Transform tr)
    {
        count--;
    }
}
