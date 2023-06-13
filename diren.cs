using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class diren : MonoBehaviour

{
    public float health;
    public float damage2;
    public float FlashTime;
    public float speed;
    public float waitTime;
    public float StarWaitTime;
    public Transform movePos;
    public Transform leftdowmPos;
    public Transform rightupPos;
    private SpriteRenderer sr;
    private Color originalColor;
    public GameObject blood;
    private 玩家受伤 playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<玩家受伤>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        waitTime = StarWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
   
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = StarWaitTime;
            }
            else
                waitTime -= Time.deltaTime; 
        }
    }
    public void takedamage(float damage)
    {
        health= health-damage;
        Flash(FlashTime);
        Instantiate(blood, transform.position, Quaternion.identity);
    }
    void Flash(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        sr.color = originalColor;
    }
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftdowmPos.position.x, rightupPos.position.x), Random.Range(leftdowmPos.position.y, rightupPos.position.y));
        return rndPos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DemeagePlay(damage2);
            }
        }
    }
}
 