using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingArrow : MonoBehaviour
{

    private Vector3 preLoc;
    private Vector3 reference;
    //private bool roFlag = true;
    protected float StarttingTime;
    protected Vector3 StarttingPosition;

    public int demage = 20;
    public Transform target;
    public float speed = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        preLoc = transform.position;
        StarttingTime = Time.time;
        StarttingPosition = transform.position;
        reference = new Vector3(Random.Range(-1.0f, 1.0f), -1.0f, Random.Range(-1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            Vector3 eye = target.position + new Vector3(0, 1, 0);
            transform.position = StarttingPosition;
            Vector3 midpoint = (StarttingPosition + eye)/2;
            Vector3 axis = Vector3.Cross((eye - StarttingPosition), reference);
            transform.LookAt(midpoint, reference);
            //transform.right = midpoint - transform.position;
            transform.RotateAround(midpoint, axis, (Time.time - StarttingTime) * speed * 180);

            /*transform.up = preLoc - transform.position;
            preLoc = transform.position;*/

            /*float alpha = (1 - (Time.time - StarttingTime) * speed) * 180;
            float height = ((target.position - transform.position).magnitude) / 2 * Mathf.Tan(Mathf.Deg2Rad * (1 - alpha/2));
            Vector3 axis = Vector3.Cross(target.position - StarttingPosition, Vector3.down);
            Vector3 vertical = Vector3.Cross(axis, target.position - transform.position);
            Vector3 centre = (target.position + transform.position)/2 + vertical.normalized * height;
            transform.RotateAround(centre, axis, speed * 180*Time.deltaTime);
            transform.up = preLoc - transform.position;
            preLoc = transform.position;*/

            /*if (roFlag)
            {
                transform.RotateAround((StarttingPosition + target.position + new Vector3(0, 1, 0)) / 2, Vector3.Cross(target.position - StarttingPosition, Vector3.down), speed * 180 * Time.deltaTime);
                transform.up = preLoc - transform.position;
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(0, 1, 0), 0.1f);
            
            preLoc = transform.position;
            roFlag = !roFlag;*/

            /*transform.position = StarttingPosition + (new Vector3(0,1,0) + target.position - StarttingPosition) * (Time.time - StarttingTime) * speed;
            transform.up = transform.position - target.position - new Vector3(0, 1, 0);*/
        }
        else
            Destroy(gameObject);

        if( (Time.time - StarttingTime) * speed >= 1)
        {
            if(target)
                target.GetComponent<Enemy>().takeDamage(demage, gameObject);
            //Debug.Log(eye - transform.position);
            Destroy(gameObject);
        }
    }
}
