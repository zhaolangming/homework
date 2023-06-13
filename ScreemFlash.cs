using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreemFlash: MonoBehaviour
{
    public Image img;
    public float time;
    public Color FlashColor;
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Flash()
    {
        StartCoroutine(FlashScreem()); 
    }
    IEnumerator FlashScreem()
    {
        img.color = FlashColor;
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
    }
}
