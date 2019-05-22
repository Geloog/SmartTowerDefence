using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeShooting : Shooting
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
            Shoot();
            LastShotTime = Time.time;
            transform.Find("CoolDown").gameObject.SetActive(true);
            Shot.Play();
        }
    }

    void Shoot()
    {
        Instantiate(arrow, transform.position, Quaternion.identity);
    }
}
