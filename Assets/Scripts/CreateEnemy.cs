using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{

    public Transform enemyBase;
    public Transform Base;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameObject enemy = Instantiate(Enemy, enemyBase.transform.position, Quaternion.identity);
        }
    }
}
