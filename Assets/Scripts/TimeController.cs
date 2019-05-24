using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    float[] speeds = { 0, 1, 1.5f, 2 };

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = speeds[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGameSpeed(int i)
    {
        Time.timeScale = speeds[i];
    }
}
