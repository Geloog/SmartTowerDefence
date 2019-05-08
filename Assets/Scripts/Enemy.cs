using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Slider HPBar;
    public delegate void EnemyDeadHandler(Transform enemy);
    public EnemyDeadHandler EnemyDead;
    public int maxHP = 100, curHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.transform.LookAt(Camera.main.transform.position);
    }

    private void OnDestroy()
    {
        if (EnemyDead != null)
            EnemyDead(transform);
    }

    public void takeDamage(int damage)
    {
        //Debug.Log(HPBar.value);
        curHP -= damage;
        if (curHP > 0)
            HPBar.value = (float)curHP / (float)maxHP;
        else
            Destroy(gameObject);
    }
}
