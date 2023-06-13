using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheji : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject projectile;
    [SerializeField] float maxFireIntervl;
    [SerializeField] float currentFireInterval;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (currentFireInterval == maxFireIntervl)
            {
                currentFireInterval = 0;
                Instantiate(projectile, muzzle.position, Quaternion.identity);
            }
            else
                currentFireInterval = Mathf.Clamp(currentFireInterval+Time.deltaTime, 0, maxFireIntervl);
        }

    }
}