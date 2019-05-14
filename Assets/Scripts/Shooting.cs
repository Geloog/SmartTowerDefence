using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public enum attackMode { firstIn, random, leastHP, canKillOnly, mostHPPercent }

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
            if(Shoot(enemiesInRange, mode))
                LastShotTime = Time.time;
        }
    }

    bool Shoot(List<Transform> enemies, attackMode mo)
    {
        //Debug.Log(enemy);
        switch (mo)
        {
            case attackMode.firstIn :
                Instantiate(arrow, shootingPoint.position, Quaternion.identity).GetComponent<FlyingArrow>().target = enemies[0];
                return true;
            case attackMode.leastHP:
                Transform tempEnemy = enemies[0];
                foreach (Transform enemy in enemies)
                    if (enemy.GetComponent<Enemy>().curHP < tempEnemy.GetComponent<Enemy>().curHP)
                        tempEnemy = enemy;
                Instantiate(arrow, shootingPoint.position, Quaternion.identity).GetComponent<FlyingArrow>().target = tempEnemy;
                return true;
            case attackMode.canKillOnly:
                foreach (Transform enemy in enemies)
                    if (enemy.GetComponent<Enemy>().curHP <= arrow.GetComponent<FlyingArrow>().demage)
                    {
                        Instantiate(arrow, shootingPoint.position, Quaternion.identity).GetComponent<FlyingArrow>().target = enemy;
                        return true;
                    }
                return false;
            case attackMode.random:
                Instantiate(arrow, shootingPoint.position, Quaternion.identity).GetComponent<FlyingArrow>().target = enemies[(int)(Random.value*enemies.Count) >= enemies.Count ? enemies.Count-1 : (int)(Random.value * enemies.Count)];
                return true;
            case attackMode.mostHPPercent:
                Transform tempEnemy2 = enemies[0];
                foreach (Transform enemy in enemies)
                    if (enemy.GetComponent<Enemy>().curHP * tempEnemy2.GetComponent<Enemy>().maxHP > tempEnemy2.GetComponent<Enemy>().curHP * enemy.GetComponent<Enemy>().maxHP)
                        tempEnemy2 = enemy;
                Instantiate(arrow, shootingPoint.position, Quaternion.identity).GetComponent<FlyingArrow>().target = tempEnemy2;
                return true;
            default:
                return false;
        }
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
