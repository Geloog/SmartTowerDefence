using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quick : Enemy
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        HPBar.transform.LookAt(Camera.main.transform.position);
        if (isFreezed)
            if (freezeTime > 0)
                freezeTime -= Time.deltaTime;
            else
                thaw();
    }

    override public void freeze(float second)
    {
        freezeTime = second;
        isFreezed = true;
        GetComponent<ManualMove>().speed = 0;
    }

    void thaw()
    {
        freezeTime = 0;
        isFreezed = false;
        GetComponent<ManualMove>().speed = 20;
    }
}
