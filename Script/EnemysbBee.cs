using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemysbBee : Enemy
{
    public float speed;
    public float radius;
    private Transform playerTranform;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        playerTranform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
   public  void Update()
    {
        base.Update();
        if(playerTranform != null)
        {
            float distance = (transform.position - playerTranform.position).sqrMagnitude;
            if(distance <radius)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTranform.position, speed * Time.deltaTime);
            }
        }
    }
}
