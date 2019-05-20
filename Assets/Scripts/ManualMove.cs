using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMove : MonoBehaviour
{

    public Transform targets;
    public Transform Base;
    public int speed = 20;
    List<Vector3> poss;

    // Start is called before the first frame update
    void Start()
    {
        poss = new List<Vector3>();
        foreach (Transform tr in targets)
            poss.Add(tr.position);
        poss.Add(Base.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(poss.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, poss[0], speed * Time.deltaTime);

            if ((transform.position - poss[0]).sqrMagnitude < 0.01f)
                poss.RemoveAt(0);
            
        }
    }
}
