using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(new Vector3(0, transform.position.y, 0), Vector3.up, 1);
            transform.forward = -transform.position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(new Vector3(0, transform.position.y, 0), Vector3.up, -1);
            transform.forward = -transform.position;
        }
    }
}
