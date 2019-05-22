using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager2 : LevelManager1
{
    void Start()
    {
        lastCreateTime = Time.time;
        waves.Add(new wave(20, 0.3f, Quick));
        waves.Add(new wave(40, 0.2f, Quick));
        waves.Add(new wave(80, 0.08f, Quick));
        UpdateInfomation();
    }
}
