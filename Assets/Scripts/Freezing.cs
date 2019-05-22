using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezing : MonoBehaviour
{

    int max = 20;
    float step = 0.3f;
    float colorAStep;

    // Start is called before the first frame update
    void Start()
    {
        colorAStep = 0.75f * step / (max - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= max)
        {
            transform.localScale += new Vector3(step * Time.deltaTime * 60, step * Time.deltaTime * 60, step * Time.deltaTime * 60);
            gameObject.GetComponent<Renderer>().material.color -= (Color)new Vector4(0, 0, 0, colorAStep) * Time.deltaTime * 60;
        }
        else
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Enemy>().freeze(1.5f);
    }
}
