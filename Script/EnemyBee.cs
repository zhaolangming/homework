using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBee : Enemy
{
    

    private Rigidbody2D myRigidbody;
    public float speed;
    public float startWaitTime;
    public float waitTime;
    //定一下一次移动的坐标
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        
        waitTime = startWaitTime;
        movePos.position =GetRandomPos();
    }


    // Update is called once per frame
    public void Update()
    {
        base.Update();//调用了父类enemy里的update方法
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);//这段代码使用了Unity中的Transform组件和Vector2结构体来进行移动。
                                                                                                              

        //其中，GetRandomPos()是一个自定义的方法，用于生成随机目标位置。startWaitTime和waitTime变量用来控制等待时间。
        if (Vector2.Distance(transform .position ,movePos .position) < 0.2f) //其中，transform.position表示游戏对象当前所在的位置，movePos.position表示游戏对象要移动到的目标位置。
                                                                             //Vector2.MoveTowards方法用于让游戏对象从当前位置移动到目标位置， 移动的速度由speed变量控制。
                                                                             //判断游戏对象是否到达目标位置的方法是通过计算游戏对象当前位置和目标位置之间的距离，
                                                                             //如果距离小于0.2f则认为已经到达，此时会随机生成一个新的目标位置并等待一段时间后再次移动。

        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }


    }
    Vector2 GetRandomPos()
    {//定义一个初始的坐标（x，y)
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position .y,rightUpPos.position .y));
        return randomPos;
    }
   
}
 