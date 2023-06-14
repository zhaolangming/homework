using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public int damage;
    public int health;
    private PlayerHealth playerHealth;
    private SpriteRenderer sr;
    private Color originalColor;
    public float flashTime;
    public GameObject bloodEffect;

    // Start is called before the first frame update
    public void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.material.color;
    
    playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }
    // Update is called once per frame
  public  void Update()
    {
        Flip();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        bool enemyHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > 0;
        if (enemyHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    public void TakeDamage(int damage)//这里是对于敌人在受到攻击时的一个逻辑编写
    {
        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    void FlashColor(float time)
    {
        sr.material.color = Color.red;
        Invoke("ResetColor",time);
    }
    void ResetColor()
    {
        sr.material.color = originalColor;
    }
 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null) {
                playerHealth.DamagePlayer(damage);
            }
        }

    }

}
