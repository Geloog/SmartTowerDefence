using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBGM : MonoBehaviour
{

    public GameObject MenuBGM;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find("MenuBGM(Clone)"))
            Instantiate(MenuBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
