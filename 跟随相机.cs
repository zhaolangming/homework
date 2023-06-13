using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 跟随相机 : MonoBehaviour

{
    public Transform mubiao;
    public Vector2 maxposition;
    public Vector2 minposition;

    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        if(mubiao != null)
        {
            if(transform.position != mubiao.position)
            {
                Vector3 targetPos = mubiao.position;
                //targetPos.x = Mathf.Clamp(targetPos.x, minposition.x, maxposition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minposition.y, maxposition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

            }
        }
    }
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minposition = minPos;
        maxposition = maxPos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
