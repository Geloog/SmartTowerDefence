using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager4 : LevelManager1
{
    // Start is called before the first frame update
    void Start()
    {
        lastCreateTime = Time.time;
        waves.Add(new wave(5, 0.5f, Enemy));
        waves.Add(new wave(1, 1f, Boss));
        waves.Add(new wave(2, 5f, Boss));
        UpdateInfomation();
    }
}
