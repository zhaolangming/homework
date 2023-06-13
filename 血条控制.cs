using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class 血条控制 : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI healthText;
    public static int HealthCurrent;
    public static int HealthMax;
    public Image HealthBar;
    void Start()
    {
        HealthBar = GetComponent<Image>();
        //HealthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
        healthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}
