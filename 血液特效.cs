using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 血液特效 : MonoBehaviour
{
    public float timetoxiaomie;
    // Start is called before the first frame update
    void Start()
    { 
        Destroy(gameObject, timetoxiaomie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
