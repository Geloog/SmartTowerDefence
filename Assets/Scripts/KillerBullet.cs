﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBullet : FlyingArrow
{

    public GameObject parent;

    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = StarttingPosition + (new Vector3(0,1,0) + target.position - StarttingPosition) * (Time.time - StarttingTime) * speed;
            transform.up = transform.position - target.position - new Vector3(0, 1, 0);
        }
        else
            Destroy(gameObject);

        if( (Time.time - StarttingTime) * speed >= 1)
        {
            if(target)
                target.GetComponent<Enemy>().takeDamage(demage, gameObject);
            Destroy(gameObject);
        }
    }

}
