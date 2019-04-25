using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    private CharacterController controller;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            controller.SimpleMove(new Vector3(1 * speed, 0,0));
        if (Input.GetKey(KeyCode.LeftArrow))
            controller.SimpleMove(new Vector3(-1 * speed, 0, 0));
        if (Input.GetKey(KeyCode.UpArrow))
            controller.SimpleMove(new Vector3(0, 0, 1 * speed));
        if (Input.GetKey(KeyCode.DownArrow))
            controller.SimpleMove(new Vector3(0, 0, -1 * speed));
    }
}
