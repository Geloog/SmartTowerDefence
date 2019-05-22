using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager5 : LevelManager1
{

    protected List<Randomwave> Randomwaves = new List<Randomwave>();

    Randomwave curWave;

    protected class Randomwave
    {
        public int amount = 5;
        public float space = 1;
        public List<GameObject> enemies;
        public Randomwave(int am, float sp, List<GameObject> en)
        {
            amount = am;
            space = sp;
            enemies = en;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastCreateTime = Time.time;
        List<GameObject> Enemies = new List<GameObject>();
        Enemies.Add(Enemy);
        Enemies.Add(Quick);
        Randomwaves.Add(new Randomwave(20, 0.4f, Enemies));
        Randomwaves.Add(new Randomwave(50, 0.5f, Enemies));
        Randomwaves.Add(new Randomwave(100, 0.5f, Enemies));
        UpdateInfomation();
    }

    void Update()
    {
        if (ready)
        {
            if (enemyCreated < curWave.amount && Time.time - lastCreateTime > curWave.space)
            {
                int ran = (int)(curWave.enemies.Count * Random.value);
                ran = ran >= curWave.enemies.Count ? curWave.enemies.Count - 1 : ran;
                CreateEnemy(curWave.enemies[ran]);
                lastCreateTime = Time.time;
                enemyCreated++;
            }
            else if (enemyCreated >= curWave.amount && count == 0)
            {
                startButton.gameObject.SetActive(true);
                ready = false;
                Randomwaves.RemoveAt(0);
                UpdateInfomation();
                enemyCreated = 0;
            }
        }

        if (count == 0 && Randomwaves.Count == 0)
            levelClear.gameObject.SetActive(true);
    }

    new public void Ready()
    {
        if (Randomwaves.Count > 0)
        {
            ready = true;
            startButton.gameObject.SetActive(false);
            curWave = Randomwaves[0];
        }
    }

    new protected void UpdateInfomation()
    {
        if (Randomwaves.Count > 0)
            GameObject.Find("GameManager").GetComponent<UIDataManager>().SetEnemyInfomation("??? * " + Randomwaves[0].amount.ToString());
    }

}
