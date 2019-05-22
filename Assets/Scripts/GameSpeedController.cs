using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedController : MonoBehaviour
{

    public Button[] Buttons = new Button[4];
    int cur = 1, last = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            SetSpeed(cur - 1);
        else if (Input.GetKeyDown(KeyCode.E))
            SetSpeed(cur + 1);
        else if (Input.GetKeyDown(KeyCode.Space))
            if (cur == 0)
                SetSpeed(last == 0 ? 1 : last);
            else
                SetSpeed(0);
    }

    public void SetSpeed(int i)
    {
        if (i < 0 || i > 3)
            return;
        last = cur;
        Buttons[cur].interactable = true;
        Buttons[i].interactable = false;
        GameObject.Find("GameManager").GetComponent<TimeController>().setGameSpeed(i);
        cur = i;
    }
}
