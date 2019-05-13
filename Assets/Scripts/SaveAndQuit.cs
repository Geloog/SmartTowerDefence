using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndQuit : MonoBehaviour
{

    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save_Quit()
    {
        tower.GetComponent<Shooting>().setMode(transform.Find("AttackMode").GetComponent<Dropdown>().value);
        Destroy(gameObject);
    }
}
