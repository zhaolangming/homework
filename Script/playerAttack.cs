using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float startTime;
    public int damage;
    public float time;
    private Animator anim;//定义一个人物动画
    //用于进行游戏对象的碰撞检测,如果要进行游戏对象的碰撞检测，通常还需要在相应的游戏对象上添加具有相应形状的 Collider 组件，并将其与 PolygonCollider2D 组件进行关联。
    private PolygonCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player"). GetComponent<Animator>();//这段代码首先会通过 GameObject.FindWithTag() 方法获取具有 “Player” 标签的游戏对象，
                                                                                    //然后调用它的 GetComponent<Animator>() 方法来获取 Animator 组件的实例。
                                                                                    //最后，将获取到的 Animator 实例赋给 anim 属性，以便后续对其进行控制。

        collider2D = GetComponent<PolygonCollider2D>();//这段代码通常用于在游戏对象上添加 PolygonCollider2D 组件后，为当前代码中的操作所用。
                                                       //通过获取组件的实例，可以进行一系列与多边形碰撞体相关的操作，例如调整多边形的顶点坐标、获取碰撞体的面积、添加碰撞的响应等等
                                                       //COllider2D是碰撞检测组件
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
             {
            collider2D.enabled = true;//collider2D.enabled = true 用于在运行时启用 collider2D 组件，以便在游戏运行期间进行碰撞检测,
                                      //当 enabled 设置为 true 时，表示当前 collider2D 组件已启用，可以与其他游戏对象进行碰撞检测。反之，当 enabled 设置为 false 时，则表示当前 collider2D 组件已禁用，不参与碰撞检测
            anim.SetTrigger("Attack");
            StartCoroutine(disableHitBox()); 
        }
    }

    IEnumerator StartAttack()//使人物的攻击可以有间隔时间，一般都要用到yield关键字去实现
    {
        yield return new WaitForSeconds(startTime);//定义一个攻击的间隔时间
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());//StartCoroutine(disableHitBox()) 是一个将方法 disableHitBox() 添加到协程队列中，以实现在一定时间后禁用攻击 hitbox 的功能

    }



    IEnumerator disableHitBox()//IEnumerator disableHitBox() 是一个协程方法，用于在一定时间后禁用攻击 hitbox，以避免攻击过于频繁和连续造成角色攻击速度过快的问题
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

   void OnTriggerEnter2D(Collider2D other)//该函数通过 other.gameObject.CompareTag("Enemy") 来判断进入的物体是否为标签为 “Enemy” 的敌人对象。
                                          //如果是敌人对象，则通过 other.GetComponent<Enemy>().TakeDamage(damage) 来获取该敌人对象的 Enemy 组件，
                                          //并调用该组件的 TakeDamage 方法来给敌人造成指定的伤害 damage。
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }







}
