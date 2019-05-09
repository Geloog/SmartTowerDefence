using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDataManager : MonoBehaviour
{

    public int gold = 600;
    public Text goldText;

    public int HP = 10;
    public Text HPText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "金币数：" + gold.ToString();
        HPText.text = "剩余生命：" + HP.ToString();
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

    public void gainGold(int number)
    {
        gold += number;
        goldText.text = "金币数：" + gold.ToString();
    }

    public bool loseHP(int number)
    {
        if (HP < number)
        {
            HP = 0;
            HPText.text = "剩余生命：" + HP.ToString();
            return false;
        }
        else
        {
            HP -= number;
            HPText.text = "剩余生命：" + HP.ToString();
        }
        return true;
    }
}
