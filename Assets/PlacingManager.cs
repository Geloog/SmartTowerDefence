using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{

    private Ray ray;
    private bool isSetting; 
    public GameObject tower;
    private GameObject movingTower;

    // Start is called before the first frame update
    void Start()
    {
        isSetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Space)&&!isSetting)
        {
            isSetting = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                movingTower = Instantiate(tower, new Vector3(hit.point.x, tower.transform.position.y, hit.point.z), Quaternion.identity);

            foreach(Transform child in movingTower.transform)   //未放置时设置其颜色为绿 TODO:不能放置时显示为红
                child.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            isSetting = false;
            foreach (Transform child in movingTower.transform)  //放置，颜色回复（为白）
                child.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isSetting = false;
            Destroy(movingTower);                               //取消放置
        }

        if (isSetting)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                movingTower.transform.position = new Vector3(hit.point.x, tower.transform.position.y, hit.point.z);
        }
        
    }
}
