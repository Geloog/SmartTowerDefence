using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingArrow : MonoBehaviour
{

    private float StarttingTime;
    private Vector3 StarttingPosition;

    public Transform target;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        StarttingTime = Time.time;
        StarttingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = StarttingPosition + (target.position - StarttingPosition) * (Time.time - StarttingTime) * speed;
            transform.up = transform.position - target.position;
        }
        else
            Destroy(gameObject);

        if( (Time.time - StarttingTime) * speed >= 1)
        {
            Destroy(gameObject);
            //TODO : 扣血
        }
    }
}
