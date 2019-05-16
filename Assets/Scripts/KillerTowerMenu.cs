using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTowerMenu : TowerMenu
{

    //new public string Name = "斩杀塔";
    //new public string Description = "伤害略高，弹速较快，但攻击范围较小且攻击间隔极长.\n拥有特殊能力：斩杀敌人可重置发射CD.";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseExit()
    {
        transform.parent.Find("AttackRange").gameObject.SetActive(false);
        foreach (Transform child in transform.parent.GetComponent<TowerData>().models)  //移开时恢复为黑
            child.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

}
