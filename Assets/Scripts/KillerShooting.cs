using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerShooting : Shooting
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastShotTime > shootingSpace && enemiesInRange.Count > 0)
        {
            if (Shoot(enemiesInRange, mode))
            {
                LastShotTime = Time.time;
                transform.Find("CoolDown").gameObject.SetActive(true);
            }
        }
    }

    new protected bool Shoot(List<Transform> enemies, attackMode mo)
    {
        //Debug.Log(enemy);
        GameObject bullet;
        switch (mo)
        {
            case attackMode.firstIn:
                bullet = Instantiate(arrow, shootingPoint.position, Quaternion.identity);
                bullet.GetComponent<FlyingArrow>().target = enemies[0];
                bullet.GetComponent<KillerBullet>().parent = gameObject;
                return true;
            case attackMode.leastHP:
                Transform tempEnemy = enemies[0];
                foreach (Transform enemy in enemies)
                    if (enemy.GetComponent<Enemy>().curHP < tempEnemy.GetComponent<Enemy>().curHP)
                        tempEnemy = enemy;
                bullet = Instantiate(arrow, shootingPoint.position, Quaternion.identity);
                bullet.GetComponent<FlyingArrow>().target = tempEnemy;
                bullet.GetComponent<KillerBullet>().parent = gameObject;
                return true;
            case attackMode.canKillOnly:
                foreach (Transform enemy in enemies)
                    if (enemy.GetComponent<Enemy>().curHP <= arrow.GetComponent<FlyingArrow>().demage)
                    {
                        bullet = Instantiate(arrow, shootingPoint.position, Quaternion.identity);
                        bullet.GetComponent<FlyingArrow>().target = enemy;
                        bullet.GetComponent<KillerBullet>().parent = gameObject;
                        return true;
                    }
                return false;
            case attackMode.random:
                bullet = Instantiate(arrow, shootingPoint.position, Quaternion.identity);
                bullet.GetComponent<FlyingArrow>().target = enemies[(int)(Random.value * enemies.Count) >= enemies.Count ? enemies.Count - 1 : (int)(Random.value * enemies.Count)];
                bullet.GetComponent<KillerBullet>().parent = gameObject;
                return true;
            case attackMode.mostHPPercent:
                Transform tempEnemy2 = enemies[0];
                foreach (Transform enemy in enemies)
                    if (enemy.GetComponent<Enemy>().curHP * tempEnemy2.GetComponent<Enemy>().maxHP > tempEnemy2.GetComponent<Enemy>().curHP * enemy.GetComponent<Enemy>().maxHP)
                        tempEnemy2 = enemy;
                bullet = Instantiate(arrow, shootingPoint.position, Quaternion.identity);
                bullet.GetComponent<FlyingArrow>().target = tempEnemy2;
                bullet.GetComponent<KillerBullet>().parent = gameObject;
                return true;
            default:
                return false;
        }
    }

    public void RefreshAttack()
    {
        LastShotTime -= shootingSpace;
    }

}
