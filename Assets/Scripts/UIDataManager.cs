using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDataManager : MonoBehaviour
{

    public int gold = 500;
    public Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "金币数：" + gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool spendGold(int number)
    {
        if (gold < number)
            return false;
        else
        {
            gold -= number;
            goldText.text = "金币数：" + gold.ToString();
        }
        return true;
    }
}
