using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager3 : LevelManager1
{
    // Start is called before the first frame update
    void Start()
    {
        lastCreateTime = Time.time;
        waves.Add(new wave(15, 0.3f, Enemy));
        waves.Add(new wave(30, 0.2f, Quick));
        waves.Add(new wave(50, 0.08f, Enemy));
        UpdateInfomation();
    }
}
