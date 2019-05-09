using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        transform.Find("AttackRange").gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        transform.Find("AttackRange").gameObject.SetActive(false);
    }

}
