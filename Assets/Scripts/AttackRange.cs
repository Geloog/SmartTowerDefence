using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{

    private LineRenderer lr;
    public float radius = 20;

    // Start is called before the first frame update
    void Start()
    {
        lr = transform.GetComponent<LineRenderer>();
        int pointAmount = 100;
        lr.positionCount = pointAmount + 1;

        for (int i=0;i<lr.positionCount;i++)
        {
            lr.SetPosition(i, new Vector3(Mathf.Sin((float)i/ pointAmount * Mathf.PI * 2), 0, Mathf.Cos((float)i / pointAmount * Mathf.PI * 2)) * radius / transform.parent.localScale.x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
