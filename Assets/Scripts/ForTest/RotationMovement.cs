using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{

    Vector3 preLoc;

    // Start is called before the first frame update
    void Start()
    {
        preLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(0,10,0), Vector3.up, 90 * Time.deltaTime);
        transform.up = preLoc - transform.position;
        preLoc = transform.position;
    }
}
