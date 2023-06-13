using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 玩家受伤 : MonoBehaviour
{
    public float health;
    private Renderer myRenderer;
    public int Blink;
    public float time;
    public float dieTime;
    private Animator myanim;
    private ScreemFlash sf;
    // Start is called before the first frame update
    void Start()
    {
        血条控制.HealthMax = (int)health;
        血条控制.HealthCurrent = (int)health;
        myRenderer = GetComponent<Renderer>();
        sf = GetComponent<ScreemFlash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DemeagePlay(float damage)
    {
        sf.Flash();
        health = health - damage;
        血条控制.HealthCurrent = (int)health;
        if (health <= 0)
        {
           
            Destroy(gameObject);
        }
        blinkPlayer(Blink, time);
    }
    void KillPlay()
    {

    }
    void blinkPlayer(int nuBlink,float seconds)
    {
        StartCoroutine(Doblinks(nuBlink, seconds));
    }
    IEnumerator Doblinks(int numBlink, float seconds)
    {
        for (int i = 0;i<numBlink*2;i++)
        {
            myRenderer.enabled = !myRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }
}
