using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public bool haveSpace = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool place()
    {
        if (!haveSpace)
            return false;
        else
        {
            haveSpace = false;
            return true;
        }
    }
}
