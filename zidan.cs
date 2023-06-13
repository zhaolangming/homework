using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zidan : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage3;
    private PolygonCollider2D coll2D;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    void Start()
    {
        coll2D = GetComponent<PolygonCollider2D>();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = direction * speed * Time.deltaTime + transform.position;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("diren"))
        {
            other.GetComponent<diren>().takedamage(damage3);
        }
    }
}
