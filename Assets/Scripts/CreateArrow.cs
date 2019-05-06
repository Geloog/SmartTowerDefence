using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArrow : MonoBehaviour
{

    public GameObject arrow;
    public Transform shootingPoint;
    public List<Transform> enemiesInRange;
    public float shootingSpace;           //射击间隔时间

    private float LastShotTime;

    // Start is called before the first frame update
    void Start()
    {
        LastShotTime = Time.time;
        shootingSpace = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastShotTime > shootingSpace && enemiesInRange.Count > 0)
        {
            LastShotTime = Time.time;
            ShootAt(enemiesInRange[0]);
        }
    }

    void ShootAt(Transform enemy)
    {
        Instantiate(arrow, shootingPoint.position, Quaternion.identity);
        arrow.GetComponent<FlyingArrow>().target = enemy;
    }
}
