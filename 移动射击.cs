using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class 移动射击 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Triangle1;
    public Transform muzzleTransform;
    private Vector3 mousPos;
    private Vector2 gunDirection;
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        gunDirection = (mousPos - transform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Triangle1, muzzleTransform.position, Quaternion.Euler(transform.eulerAngles));
                
        }
    }
}
