using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Slider HPBar;
    public delegate void EnemyDeadHandler(Transform enemy);
    public EnemyDeadHandler EnemyDead;
    public int maxHP = 100, curHP = 100;
    public int reward = 50;

    private UnityEngine.AI.NavMeshAgent agent;
    protected float freezeTime = 0;
    protected bool isFreezed = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HPBar.GetComponent<RectTransform>().localScale = new Vector3(HPBar.GetComponent<RectTransform>().localScale.x * ((float)maxHP/100), HPBar.GetComponent<RectTransform>().localScale.y, HPBar.GetComponent<RectTransform>().localScale.z);
        HPBar.value = (float)curHP / (float)maxHP;
        if(GetComponentInChildren<UnityEngine.AI.NavMeshAgent>())
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.transform.LookAt(Camera.main.transform.position);
        if (isFreezed)
            if (freezeTime > 0)
                freezeTime -= Time.deltaTime;
            else
                thaw();

        if (Input.GetKey(KeyCode.Space))
            freeze(3);
    }

    private void OnDestroy()
    {
        EnemyDead?.Invoke(transform);
    }

    public void takeDamage(int damage)
    {
        curHP -= damage;
        if (curHP > 0)
            HPBar.value = (float)curHP / (float)maxHP;
        else
        {
            GameObject.Find("GameManager").GetComponent<UIDataManager>().gainGold(reward);
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage, GameObject bullet)
    {
        curHP -= damage;
        if (curHP > 0)
            HPBar.value = (float)curHP / (float)maxHP;
        else
        {
            if (bullet.name == "KillerBullet(Clone)")
                bullet.GetComponent<KillerBullet>().parent.GetComponent<KillerShooting>().RefreshAttack();
            GameObject.Find("GameManager").GetComponent<UIDataManager>().gainGold(reward);
            Destroy(gameObject);
        }
    }

    virtual public void freeze(float second)
    {
        freezeTime = second;
        isFreezed = true;
        agent.enabled = false;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().enabled = false;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        animator.enabled = false;
        Destroy(GetComponent<Rigidbody>());
        transform.position = new Vector3(transform.position.x, 0,transform.position.z);
    }

    void thaw()
    {
        freezeTime = 0;
        isFreezed = false;
        gameObject.AddComponent<Rigidbody>();
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_Rigidbody = GetComponent<Rigidbody>();
        agent.enabled = true;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().enabled = true;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        animator.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Base")
        {
            Destroy(gameObject);
            GameObject.Find("GameManager").GetComponent<UIDataManager>().loseHP(1);
        }
    }
}
