using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class 移动射击子弹 : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage3;
    private PolygonCollider2D coll2D;
  public float speed2;
    private Rigidbody2D myRigidbody;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<PolygonCollider2D>();
        Vector2 jumpVel = new Vector2(speed2,0);
        myRigidbody.velocity = Vector2.up * jumpVel;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        MoveRigth();
    }
    public void MoveRigth()
    {
        Vector3 pos = gameObject.transform.localPosition;
       
        pos += Vector3.forward * Time.deltaTime;
        
        gameObject.transform.localPosition = pos;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("diren"))
        {
            other.GetComponent<diren>().takedamage(damage3);
        }
    }
}
