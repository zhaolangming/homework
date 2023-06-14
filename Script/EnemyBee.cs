using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBee : Enemy
{
    

    private Rigidbody2D myRigidbody;
    public float speed;
    public float startWaitTime;
    public float waitTime;
    //��һ��һ���ƶ�������
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
        base.Update();//�����˸���enemy���update����
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);//��δ���ʹ����Unity�е�Transform�����Vector2�ṹ���������ƶ���
                                                                                                              

        //���У�GetRandomPos()��һ���Զ���ķ����������������Ŀ��λ�á�startWaitTime��waitTime�����������Ƶȴ�ʱ�䡣
        if (Vector2.Distance(transform .position ,movePos .position) < 0.2f) //���У�transform.position��ʾ��Ϸ����ǰ���ڵ�λ�ã�movePos.position��ʾ��Ϸ����Ҫ�ƶ�����Ŀ��λ�á�
                                                                             //Vector2.MoveTowards������������Ϸ����ӵ�ǰλ���ƶ���Ŀ��λ�ã� �ƶ����ٶ���speed�������ơ�
                                                                             //�ж���Ϸ�����Ƿ񵽴�Ŀ��λ�õķ�����ͨ��������Ϸ����ǰλ�ú�Ŀ��λ��֮��ľ��룬
                                                                             //�������С��0.2f����Ϊ�Ѿ������ʱ���������һ���µ�Ŀ��λ�ò��ȴ�һ��ʱ����ٴ��ƶ���

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
    {//����һ����ʼ�����꣨x��y)
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position .y,rightUpPos.position .y));
        return randomPos;
    }
   
}
 