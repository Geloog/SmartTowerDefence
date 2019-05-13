using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{

    public Dropdown dropdown;
    [SerializeField]
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = dropdown.value;
    }
}
