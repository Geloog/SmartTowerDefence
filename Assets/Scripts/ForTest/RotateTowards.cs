using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{

    public Transform t1, t2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t1.localEulerAngles = Vector3.RotateTowards(t1.localEulerAngles, t2.localEulerAngles, 10 * Mathf.Deg2Rad, 0);
        Debug.Log(t1.localEulerAngles);
    }
}
