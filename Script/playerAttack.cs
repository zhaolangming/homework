using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float startTime;
    public int damage;
    public float time;
    private Animator anim;//����һ�����ﶯ��
    //���ڽ�����Ϸ�������ײ���,���Ҫ������Ϸ�������ײ��⣬ͨ������Ҫ����Ӧ����Ϸ��������Ӿ�����Ӧ��״�� Collider ������������� PolygonCollider2D ������й�����
    private PolygonCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player"). GetComponent<Animator>();//��δ������Ȼ�ͨ�� GameObject.FindWithTag() ������ȡ���� ��Player�� ��ǩ����Ϸ����
                                                                                    //Ȼ��������� GetComponent<Animator>() ��������ȡ Animator �����ʵ����
                                                                                    //��󣬽���ȡ���� Animator ʵ������ anim ���ԣ��Ա����������п��ơ�

        collider2D = GetComponent<PolygonCollider2D>();//��δ���ͨ����������Ϸ��������� PolygonCollider2D �����Ϊ��ǰ�����еĲ������á�
                                                       //ͨ����ȡ�����ʵ�������Խ���һϵ����������ײ����صĲ����������������εĶ������ꡢ��ȡ��ײ�������������ײ����Ӧ�ȵ�
                                                       //COllider2D����ײ������
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
            collider2D.enabled = true;//collider2D.enabled = true ����������ʱ���� collider2D ������Ա�����Ϸ�����ڼ������ײ���,
                                      //�� enabled ����Ϊ true ʱ����ʾ��ǰ collider2D ��������ã�������������Ϸ���������ײ��⡣��֮���� enabled ����Ϊ false ʱ�����ʾ��ǰ collider2D ����ѽ��ã���������ײ���
            anim.SetTrigger("Attack");
            StartCoroutine(disableHitBox()); 
        }
    }

    IEnumerator StartAttack()//ʹ����Ĺ��������м��ʱ�䣬һ�㶼Ҫ�õ�yield�ؼ���ȥʵ��
    {
        yield return new WaitForSeconds(startTime);//����һ�������ļ��ʱ��
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());//StartCoroutine(disableHitBox()) ��һ�������� disableHitBox() ��ӵ�Э�̶����У���ʵ����һ��ʱ�����ù��� hitbox �Ĺ���

    }



    IEnumerator disableHitBox()//IEnumerator disableHitBox() ��һ��Э�̷�����������һ��ʱ�����ù��� hitbox���Ա��⹥������Ƶ����������ɽ�ɫ�����ٶȹ��������
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

   void OnTriggerEnter2D(Collider2D other)//�ú���ͨ�� other.gameObject.CompareTag("Enemy") ���жϽ���������Ƿ�Ϊ��ǩΪ ��Enemy�� �ĵ��˶���
                                          //����ǵ��˶�����ͨ�� other.GetComponent<Enemy>().TakeDamage(damage) ����ȡ�õ��˶���� Enemy �����
                                          //�����ø������ TakeDamage ���������������ָ�����˺� damage��
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }







}
