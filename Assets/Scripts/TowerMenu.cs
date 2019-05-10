using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{
    
    public Dropdown attackMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        transform.parent.Find("AttackRange").gameObject.SetActive(true);
        foreach (Transform child in transform.parent)  //鼠标在上时颜色变为黄
        {
            if (child.gameObject.GetComponent<Renderer>())
                child.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        transform.parent.Find("AttackRange").gameObject.SetActive(false);
        foreach (Transform child in transform.parent)  //移开时恢复为白
        {
            if (child.gameObject.GetComponent<Renderer>())
                child.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        Instantiate(attackMode, GameObject.Find("CanvasForAttackMode").transform).transform.position = Input.mousePosition;
    }
}
