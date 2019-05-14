using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerMenu : MonoBehaviour
{

    public GameObject TowerData;

    private string Name = "箭塔";
    private string Description = "最普通的箭塔，攻击间隔为1秒，伤害为20.";

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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameObject canvas = GameObject.Find("CanvasAuto");
            GameObject towerdata = Instantiate(TowerData, canvas.transform);
            towerdata.GetComponent<SaveAndQuit>().tower = transform.parent.gameObject;
            towerdata.transform.Find("Name").GetComponent<Text>().text = Name;
            towerdata.transform.Find("Description").GetComponent<Text>().text = Description;
            towerdata.transform.Find("AttackMode").GetComponent<Dropdown>().value = (int)transform.parent.GetComponent<Shooting>().mode;
        }
    }
}
