using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    
    private bool isSetting;
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

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isSetting)
            {
                isSetting = false;
                foreach (Transform child in movingTower.transform)  //放置，颜色回复（为白）
                {
                    if(child.gameObject.GetComponent<Renderer>())
                        child.gameObject.GetComponent<Renderer>().material.color = Color.white;
                }
                movingTower.GetComponent<Shooting>().enabled = true;
                movingTower.GetComponent<SphereCollider>().enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)&&isSetting)
        {
            isSetting = false;
            Destroy(movingTower);                               //取消放置
        }

        if (isSetting)
        {
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                movingTower.transform.position = new Vector3(hit.point.x, movingTower.transform.position.y, hit.point.z);
        }
        
    }

    public void Set(GameObject tower)
    {

        if (!isSetting)
        {

            if (!GetComponent<UIDataManager>().spendGold(tower.GetComponent<TowerData>().price))
                return;

            isSetting = true;

            movingTower = Instantiate(tower, new Vector3(0, tower.transform.position.y, 0), Quaternion.identity);

            foreach (Transform child in movingTower.transform)   //未放置时设置其颜色为绿 TODO:不能放置时显示为红
            {
                if (child.gameObject.GetComponent<Renderer>())
                    child.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
