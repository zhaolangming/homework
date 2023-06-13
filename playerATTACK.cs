using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerATTACK : MonoBehaviour
{
    public float damage;
    public float startime;
    private Animator anim;
    private PolygonCollider2D coll2D;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attcak();
    }
    void Attcak()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            anim.SetTrigger("ISATTACK");
            StartCoroutine(StarAttack());
        }
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }
    IEnumerator StarAttack()
    {
        yield return new WaitForSeconds(startime);
        coll2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("diren"))
        {
            other.GetComponent<diren>().takedamage(damage);
        }
    }
}
