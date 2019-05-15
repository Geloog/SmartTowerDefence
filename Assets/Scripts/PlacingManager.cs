using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    
    private bool isSetting;
    private GameObject movingTower;
    private bool canBeSet;

    // Start is called before the first frame update
    void Start()
    {
        isSetting = false;
        canBeSet = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1)&&isSetting)
        {
            isSetting = false;
            GetComponent<UIDataManager>().gainGold(movingTower.GetComponent<TowerData>().price);
            Destroy(movingTower);                               //取消放置
        }

        if (isSetting)
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                

                if (hit.collider.tag == "PlacingPoint")
                {
                    
                    movingTower.transform.position = new Vector3(hit.transform.position.x, movingTower.transform.position.y, hit.transform.position.z);
                    foreach (Transform child in movingTower.GetComponent<TowerData>().models)   //可放置时显示其颜色为绿
                        child.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    canBeSet = true;
                }
                else
                {
                    movingTower.transform.position = new Vector3(hit.point.x, movingTower.transform.position.y, hit.point.z);
                    foreach (Transform child in movingTower.GetComponent<TowerData>().models)   //不能放置时显示为红
                        child.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    canBeSet = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (isSetting && canBeSet && hit.transform.GetComponent<Obstacle>().place())
                {
                    isSetting = false;
                    foreach (Transform child in movingTower.GetComponent<TowerData>().models)  //放置，颜色回复（为白）
                        child.gameObject.GetComponent<Renderer>().material.color = Color.white;
                    movingTower.GetComponent<Shooting>().enabled = true;
                    movingTower.GetComponent<SphereCollider>().enabled = true;
                    movingTower.transform.Find("AttackRange").gameObject.SetActive(false);
                    movingTower.transform.Find("TowerMenu").gameObject.SetActive(true);
                }

                
            }
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

        }
    }
}
